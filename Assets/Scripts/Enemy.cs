using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private bool m_ComeEnemyFlg = false;
    private float moveSpeed = 10.0f;

    //private Player m_Player;
    //private bool m_CollisionFlg = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool MoveEnemy(Vector3 _pos)
    {
        float step = moveSpeed * 10 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _pos, step);

        float len = Vector3.Distance(transform.position, _pos);


        if (len <= 3)
        {
            m_ComeEnemyFlg = false;
        }
        else
        {
            m_ComeEnemyFlg = true;
        }

        return m_ComeEnemyFlg;
    }
}
