using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Effekseer;

public class Hook : MonoBehaviour
{
    public bool m_HookFlg = false;
    public bool m_HookReturnFlg = false;
    public bool m_HookShotFlg = false;
    public bool m_AttractFlg = false;
    public bool m_ComeEnemyFlg = false;
    [SerializeField] GameObject m_Arm;
    private Player m_Player;
    private Enemy m_Enemy;
    [SerializeField] private GameObject m_Hook;
    [SerializeField] private GameObject m_ModelHook;
    [SerializeField] private GameObject m_HookBorn;
    [SerializeField] private GameObject m_Rope;
    [SerializeField] private GameObject[] m_RopeBorn;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private int m_Distance = 20;
    [SerializeField] private Vector3 m_HookVec;
    [SerializeField] private GameObject AttackCollision;
    private Vector3 m_TargetPos;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private float speed = 5.0f;
    public Move EnemyHook;

    private Animator anime;

    [SerializeField] private GameObject m_AttackEffect;
    [SerializeField] private Vector3[] m_AttackEffectPos;
    [SerializeField] private EffekseerEffectAsset effect;
    [SerializeField] private EffekseerEffectAsset hitEffect;
    public bool m_hitFlg = false;
    public Vector3 m_hitPos;

    //サウンド関係
    [SerializeField] public AudioClip sound;
    AudioSource audioSource;

    bool GameClearFlg = false;
    bool GameOverFlg = false;
    bool HookStopFlg = false;
    // Start is called before the first frame update
    void Start()
    {
        m_Hook.SetActive(false);
        m_Rope.SetActive(false);
        AttackCollision.SetActive(false);
        m_ModelHook.SetActive(true);
        
        this.m_Player = FindObjectOfType<Player>();
        this.m_Enemy = FindObjectOfType<Enemy>();

        anime = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        GameClearFlg = GameObject.Find("Panel").GetComponent<FadeController>().GameClearFlg;
        GameOverFlg = GameObject.Find("BlackPanel").GetComponent<BlackOut>().GameOverFlg;
        if(GameClearFlg == true || GameOverFlg == true)
        {
            HookStopFlg = true;
        }
        //クリック時のフックを飛ばす準備
        if (m_HookFlg != true)
        {
            if (Input.GetMouseButton(1))
            {
                ray = m_Camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(m_Camera.transform.position, ray.direction, out hit))
                {
                    Debug.Log(hit.point);
                    //サウンド
                    audioSource.PlayOneShot(sound);

                    Vector3 front = ray.direction.normalized * 5;
                    m_Hook.SetActive(true);
                    m_Rope.SetActive(true);
                    m_ModelHook.SetActive(false);
                    m_Rope.transform.position = m_Arm.transform.position;
                    m_RopeBorn[0].transform.position = m_Arm.transform.position;
                    m_RopeBorn[1].transform.position = m_HookBorn.transform.position;

                    m_Hook.transform.position = m_Arm.transform.position + front;
                    m_HookFlg = true;
                    m_HookShotFlg = true;

                    m_Player.transform.LookAt(m_Camera.transform.position);

                }
            }

            if (Input.GetMouseButton(0))
            {
                anime.SetTrigger("ATK");
                m_HookFlg = true;
            }

        }
        else
        {
            m_Hook.transform.LookAt(m_Arm.transform.position);

        }


        //フックを飛ばす処理
        if (m_HookShotFlg == true)
        {
            float step = speed * Time.deltaTime;
            m_TargetPos = m_Hook.transform.position + ray.direction;
            m_Hook.transform.position = Vector3.MoveTowards(m_Hook.transform.position, m_TargetPos, step);

            //プレイヤーからフックの距離計算
            float length = Vector3.Distance(m_Hook.transform.position, m_Arm.transform.position);
            m_RopeBorn[0].transform.position = m_Arm.transform.position;
            m_RopeBorn[1].transform.position = m_HookBorn.transform.position;

            if (length >= m_Distance)
            {
                m_HookShotFlg = false;
                m_HookReturnFlg = true;
                m_HookVec.Normalize();
                m_Distance = 2;
            }
        }

        //当たった先にプレイヤーが近づく
        if (m_AttractFlg == true)
        {
            m_HookFlg = m_Player.Attract(hit.point, ray);
            m_RopeBorn[0].transform.position = m_Arm.transform.position;
            m_RopeBorn[1].transform.position = m_HookBorn.transform.position;
            m_hitPos = hit.point;
            if (m_HookFlg == false)
            {
                m_Hook.SetActive(false);
                m_Rope.SetActive(false);
                m_ModelHook.SetActive(true);
                m_AttractFlg = false;
            }
        }

        //敵に当たったら敵が自分のところに来る
        if (m_ComeEnemyFlg == true)
        {


            // m_HookFlg = EnemyHook.MoveEnemy(m_Player.transform.position);
            m_HookFlg = EnemyHook.MoveEnemy(m_Arm.transform.position);
            m_RopeBorn[0].transform.position = m_Arm.transform.position;
            m_RopeBorn[1].transform.position = m_HookBorn.transform.position;

            if (m_HookFlg == false)
            {
                m_Hook.SetActive(false);
                m_Rope.SetActive(false);
                m_ModelHook.SetActive(true);
                m_ComeEnemyFlg = false;
            }
        }

        //フックが自分の所に戻ってくる
        if (m_HookReturnFlg == true)
        {
            float step = speed * Time.deltaTime;
            //var pos = m_Player.transform.position - m_Hook.transform.position;
            var pos = m_Arm.transform.position - m_Hook.transform.position;
            pos.Normalize();
            m_TargetPos = m_Hook.transform.position + pos;
            m_Hook.transform.position = Vector3.MoveTowards(m_Hook.transform.position, m_TargetPos, step);
           

            //プレイヤーからフックの距離計算
            //float length = Vector3.Distance(m_Hook.transform.position, m_Player.transform.position);
            float length = Vector3.Distance(m_Hook.transform.position, m_Arm.transform.position);

            m_RopeBorn[0].transform.position = m_Arm.transform.position;
            m_RopeBorn[1].transform.position = m_HookBorn.transform.position;

            if (length <= m_Distance)
            {
                m_Hook.SetActive(false);
                m_Rope.SetActive(false);
                m_ModelHook.SetActive(true);
                m_HookShotFlg = false;
                m_HookReturnFlg = false;
                m_HookFlg = false;
                m_Distance = 50;
            }
        }

        if(m_hitFlg == true)
        {
            m_hitFlg = false;
            EffekseerHandle handle = EffekseerSystem.PlayEffect(hitEffect,m_hitPos);
        }
    }

    void AttackStart()
    {
        AttackCollision.SetActive(true);
        // transformの位置でエフェクトを再生する
        for (int i = 0; i < 3; i++)
        {
            EffekseerHandle handle = EffekseerSystem.PlayEffect(effect, m_AttackEffect.transform.position + m_AttackEffectPos[i]);
            // transformの回転を設定する。
            handle.SetRotation(m_AttackEffect.transform.rotation);
        }
    }

    void AttackEnd()
    {
        AttackCollision.SetActive(false);
        m_HookFlg = false;
        anime.SetBool("Attack", m_HookFlg);

    }

}
