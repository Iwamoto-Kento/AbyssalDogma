using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    //State関係
    [SerializeField] private int m_state;
    private int TRACK;
    private int CHASE;
    private int ATTACK;

    //TRACK関係
    [SerializeField] private bool m_flg;
    private float vecX;
    [SerializeField] private float vecXRandomMIN = -20.0f;
    [SerializeField] private float vecXRandomMAX = 20.0f;
    private float vecY;
    [SerializeField] private float vecYRandomMIN = 0;
    [SerializeField] private float vecYRandomMAX = 35.0f;
    private float vecZ;
    [SerializeField] private float vecZRandomMIN = -20.0f;
    [SerializeField] private float vecZRandomMAX = 20.0f;
    [SerializeField] private float m_targetDistance;
    private Vector3 m_targetVec;

    [SerializeField] GameObject EnemyObject;

    //ATTACK関係
    private float m_attackTime;

    //Distance関数関係
    [SerializeField]private float m_distance;

    //サウンド関係
    [SerializeField] public AudioClip sound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        TRACK = 0;
        CHASE = 1;
        ATTACK = 2;

        m_state = TRACK;

        m_flg = false;

        m_attackTime = 0;
        
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_state == TRACK)
        {
            Track();
        }
        if (m_state == CHASE)
        {
            Chase();
        }
        if (m_state == ATTACK)
        {
            Attack();
        }

    }

    void Track()
    {
        if (m_flg == false)
        {
            vecX = Random.Range(EnemyObject.transform.position.x + vecXRandomMIN, EnemyObject.transform.position.x + vecXRandomMAX);
            vecY = Random.Range(EnemyObject.transform.position.y + vecYRandomMIN, EnemyObject.transform.position.y + vecYRandomMAX);
            vecZ = Random.Range(EnemyObject.transform.position.z + vecZRandomMIN, EnemyObject.transform.position.z + vecZRandomMAX);
            //vecX = Random.Range(vecXRandomMIN, vecXRandomMAX);
            //vecY = Random.Range(vecYRandomMIN, vecYRandomMAX);
            //vecZ = Random.Range(vecZRandomMIN, vecZRandomMAX);

            Vector3 _distance1 = transform.position;
            Vector3 _distance2 = new Vector3(vecX, vecY, vecZ);
            m_targetVec = new Vector3(vecX, vecY, vecZ);

            m_flg = true;
        }

        // 補完スピードを決める
        float speed = 0.01f;
        // ターゲット方向のベクトルを取得
        Vector3 relativePos = m_targetVec - transform.position;
        // 方向を、回転情報に変換
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        // 現在の回転情報と、ターゲット方向の回転情報を補完する
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);

        m_targetDistance = Vector3.Distance(transform.position, m_targetVec);

        if (m_targetDistance >= 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_targetVec, 0.005f);
        }

        if (m_targetDistance <= 0.01f)
        {
            m_flg = false;
        }

        if (GetDistance() < 15.0f)
        {
            m_state = CHASE;
        }
    }

    void Chase()
    {
        Vector3 target = GameObject.Find("player").transform.position;
        gameObject.transform.LookAt(target);

        transform.position = Vector3.MoveTowards(transform.position, target, 0.01f);

        m_attackTime += Time.deltaTime;

        if (m_attackTime >= 1)
        {
            if (GetDistance() < 8.0f)
            {
                m_state = ATTACK;
            }
        }

        if (GetDistance() > 15.0f)
        {
            m_state = TRACK;
        }
    }

    void Attack()
    {
        GameObject.Find("player").GetComponent<PlayerHP>().Damage();
        m_attackTime = 0;

        m_state = CHASE;

        //サウンド
        if (GameObject.Find("player").GetComponent<PlayerHP>().hp >= 0)
        {
            audioSource.PlayOneShot(sound);
        }
    }

    //ターゲットからプレイヤーまでの距離を測る関数
    float GetDistance()
    {
        Vector3 _distance1 = gameObject.transform.position;
        Vector3 _distance2 = GameObject.Find("player").transform.position;

        m_distance = Vector3.Distance(_distance1, _distance2);
        
        return m_distance;
    }
}
