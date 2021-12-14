using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    //State�֌W
    [SerializeField] private int m_state;
    private int TRACK;
    private int CHASE;
    private int ATTACK;

    //TRACK�֌W
    [SerializeField] private bool m_flg;
    private float vecX;
    private float vecY;
    private float vecZ;
    [SerializeField] private float m_targetDistance;
    private Vector3 m_targetVec;

    //ATTACK�֌W
    private float m_attackTime;

    //Distance�֐��֌W
    [SerializeField] private float m_distance;

    // Start is called before the first frame update
    void Start()
    {
        TRACK = 0;
        CHASE = 1;
        ATTACK = 2;

        m_state = TRACK;

        m_flg = false;

        m_attackTime = 0;
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
            vecX = Random.Range(-4.5f, 5.0f);
            vecY = Random.Range(0, 15.0f);
            vecZ = Random.Range(-4.5f, 5.0f);

            Vector3 _distance1 = transform.position;
            Vector3 _distance2 = new Vector3(vecX, vecY, vecZ);
            m_targetVec = new Vector3(vecX, vecY, vecZ);

            m_flg = true;
        }

        // �⊮�X�s�[�h�����߂�
        float speed = 0.01f;
        // �^�[�Q�b�g�����̃x�N�g�����擾
        Vector3 relativePos = m_targetVec - transform.position;
        // �������A��]���ɕϊ�
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        // ���݂̉�]���ƁA�^�[�Q�b�g�����̉�]����⊮����
        transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, speed);

        m_targetDistance = Vector3.Distance(transform.position, m_targetVec);

        if (m_targetDistance >= 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, m_targetVec, 0.01f);
        }

        if (m_targetDistance <= 0.01f)
        {
            m_flg = false;
        }

        if (GetDistance() < 10.0f)
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
            if (GetDistance() < 1.0f)
            {
                m_state = ATTACK;
            }
        }

        if (GetDistance() > 10.0f)
        {
            m_state = TRACK;
        }
    }

    void Attack()
    {
        //GameObject.Find("Player").GetComponent<PlayerHP>().Damage();
        m_attackTime = 0;

        m_state = CHASE;
    }

    //�^�[�Q�b�g����v���C���[�܂ł̋����𑪂�֐�
    float GetDistance()
    {
        Vector3 _distance1 = gameObject.transform.position;
        Vector3 _distance2 = GameObject.Find("player").transform.position;

        m_distance = Vector3.Distance(_distance1, _distance2);

        return m_distance;
    }
}