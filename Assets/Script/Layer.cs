using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField] private bool m_flg = false;
    [SerializeField] private float m_seconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_flg == true)
        {
                         //最後のフレームからの経過時間
            m_seconds += Time.deltaTime;
        }

        //3秒後にアウトライン削除
        if (m_seconds >= 3)
        {
            gameObject.layer = 0;
            m_flg = false;
            m_seconds = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //ソナーに判定した場合、アウトライン表示
        if (collision.gameObject.tag == "Sonar")
        {
            gameObject.layer = 8;
            m_flg = true;
        }
    }

}
