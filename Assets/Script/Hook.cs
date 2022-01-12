using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Vector3 m_TargetPos;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private float speed = 5.0f;
    public Move EnemyHook;
    // Start is called before the first frame update
    void Start()
    {
        m_Hook.SetActive(false);
        m_Rope.SetActive(false);
        m_ModelHook.SetActive(true);
        
        this.m_Player = FindObjectOfType<Player>();
        this.m_Enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

        //クリック時のフックを飛ばす準備
        if (m_HookFlg != true)
        {
            if (Input.GetMouseButton(1))
            {
                int layer = LayerMask.NameToLayer("Player");
                int layer_mask = 1 << layer;
                ray = m_Camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(m_Camera.transform.position, ray.direction, out hit))
                {
                    Debug.Log(hit.point);
                    float len;
                    //len = Vector3.Distance(hit.point, m_Player.transform.position);
                    len = Vector3.Distance(hit.point, m_Arm.transform.position);

                    Vector3 front = ray.direction.normalized * 5;
                    m_Hook.SetActive(true);
                    m_Rope.SetActive(true);
                    m_ModelHook.SetActive(false);
                    // m_Hook.transform.position = m_Player.transform.position + front;
                    m_Rope.transform.position = m_Arm.transform.position;
                    m_RopeBorn[0].transform.position = m_Arm.transform.position;
                    m_RopeBorn[1].transform.position = m_HookBorn.transform.position;

                    m_Hook.transform.position = m_Arm.transform.position + front;
                    m_HookFlg = true;
                    m_HookShotFlg = true;

                }
            }

        }
        else
        {
            m_Hook.transform.LookAt(m_Arm.transform.position);
           // m_Rope.transform.LookAt(m_Arm.transform.position);
        }
        

        //フックを飛ばす処理
        if (m_HookShotFlg == true)
        {
            float step = speed * Time.deltaTime;
            m_TargetPos = m_Hook.transform.position + ray.direction;
            m_Hook.transform.position = Vector3.MoveTowards(m_Hook.transform.position, m_TargetPos, step);
            //m_TargetPos = m_Rope.transform.position + ray.direction;
            //m_Rope.transform.position = Vector3.MoveTowards(m_Rope.transform.position, m_TargetPos, step);

            

            //プレイヤーからフックの距離計算
            //float length = Vector3.Distance(m_Hook.transform.position, m_Player.transform.position);
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
    }

}
