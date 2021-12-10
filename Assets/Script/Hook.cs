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
    private Player m_Player;
    private Enemy m_Enemy;
    [SerializeField] private GameObject m_Hook;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private int m_Distance = 20;
    [SerializeField] private Vector3 m_HookVec;
    private Vector3 m_TargetPos;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_Hook.SetActive(false);
        this.m_Player = FindObjectOfType<Player>();
        this.m_Enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

        //�N���b�N���̃t�b�N���΂�����
        if (m_HookFlg != true)
        {
            if (Input.GetMouseButton(1))
            {
                ray = m_Camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(m_Camera.transform.position, ray.direction, out hit))
                {
                    float len;
                    len= Vector3.Distance(hit.point, m_Player.transform.position);
                    //if (len > 2)
                    //{
                        m_Hook.SetActive(true);
                        m_Hook.transform.position = m_Player.transform.position;
                        m_HookFlg = true;
                        m_HookShotFlg = true;
                   // }
                }
            }
        }

        m_Hook.transform.LookAt(m_Player.transform.position);

        //�t�b�N���΂�����
        if (m_HookShotFlg == true)
        {
            float step = speed * Time.deltaTime;
            m_TargetPos = m_Hook.transform.position + ray.direction;
            m_Hook.transform.position = Vector3.MoveTowards(m_Hook.transform.position, m_TargetPos, step);


            //�v���C���[����t�b�N�̋����v�Z
            float length = Vector3.Distance(m_Hook.transform.position, m_Player.transform.position);


            Debug.Log(length);
            if (length >= m_Distance)
            {
                m_HookShotFlg = false;
                m_HookReturnFlg = true;
                m_HookVec.Normalize();
                m_Distance = 2;
            }


        }

        //����������Ƀv���C���[���߂Â�
        if (m_AttractFlg == true)
        {
            m_HookFlg = m_Player.Attract(hit.point, ray);

            if (m_HookFlg == false)
            {
                m_Hook.SetActive(false);
                m_AttractFlg = false;
            }
        }

        //�G�ɓ���������G�������̂Ƃ���ɗ���
        if (m_ComeEnemyFlg == true)
        {
            m_HookFlg = m_Enemy.MoveEnemy(m_Player.transform.position);

            if (m_HookFlg == false)
            {
                m_Hook.SetActive(false);
                m_ComeEnemyFlg = false;
            }
        }

        //�t�b�N�������̏��ɖ߂��Ă���
        if (m_HookReturnFlg == true)
        {
            float step = speed * Time.deltaTime;
            var pos = m_Player.transform.position - m_Hook.transform.position;
            pos.Normalize();
            m_TargetPos = m_Hook.transform.position + pos;
            m_Hook.transform.position = Vector3.MoveTowards(m_Hook.transform.position, m_TargetPos, step);

            //�v���C���[����t�b�N�̋����v�Z
            float length = Vector3.Distance(m_Hook.transform.position, m_Player.transform.position);



            if (length <= m_Distance)
            {
                m_Hook.SetActive(false);
                m_HookShotFlg = false;
                m_HookReturnFlg = false;
                m_HookFlg = false;
                m_Distance = 50;
            }
        }
    }

}
