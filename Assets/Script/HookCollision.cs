using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollision : MonoBehaviour
{
    Hook m_Hook;


    private void Start()
    {
        this.m_Hook = FindObjectOfType<Hook>();
    }


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.tag == "Object")
        {
            Debug.Log("はい");

            m_Hook.m_AttractFlg = true;
            m_Hook.m_HookShotFlg = false;
        }

        if(m_Hook.m_HookShotFlg != false)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                m_Hook.EnemyHook = collision.gameObject.GetComponent<Move>();
                var enemyHP = collision.gameObject.GetComponent<EnemyHp>();
                var enemyHidame = collision.gameObject.GetComponent<hidame>();
                var enemyDeath = collision.gameObject.GetComponent<death>();

                //敵を攻撃する
                if (enemyHidame != null)
                {
                    enemyHidame.hidame_01(1);
                }

                //敵が死ぬ
                if (enemyHP.hp <= 0)
                {
                    enemyDeath.death_01();
                }
                m_Hook.m_ComeEnemyFlg = true;
                m_Hook.m_HookShotFlg = false;
                m_Hook.m_HookReturnFlg = true;
            }
        }
    }
}
