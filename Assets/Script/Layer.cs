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
                         //�Ō�̃t���[������̌o�ߎ���
            m_seconds += Time.deltaTime;
        }

        //3�b��ɃA�E�g���C���폜
        if (m_seconds >= 3)
        {
            gameObject.layer = 0;
            m_flg = false;
            m_seconds = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //�\�i�[�ɔ��肵���ꍇ�A�A�E�g���C���\��
        if (collision.gameObject.tag == "Sonar")
        {
            gameObject.layer = 8;
            m_flg = true;
        }
    }

}
