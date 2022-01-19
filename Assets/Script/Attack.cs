using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hai");
        if (other.gameObject.tag == "Enemy")
        {
            var enemyHP = other.gameObject.GetComponent<EnemyHp>();
            var enemyHidame = other.gameObject.GetComponent<hidame>();
            var enemyDeath = other.gameObject.GetComponent<death>();

            //�G���U������
            if (enemyHidame != null)
            {
                enemyHidame.hidame_01(1);
            }

            //�G������
            if (enemyHP.hp <= 0)
            {
                enemyDeath.death_01();
            }
        }
    }
}
