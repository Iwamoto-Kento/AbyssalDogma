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
            //Debug.Log("‚Í‚¢");

            m_Hook.m_AttractFlg = true;
            m_Hook.m_HookShotFlg = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            m_Hook.m_ComeEnemyFlg = true;
            m_Hook.m_HookShotFlg = false;
            m_Hook.m_HookReturnFlg = true;
        }

    }
}
