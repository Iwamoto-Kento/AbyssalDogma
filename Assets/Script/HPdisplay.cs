using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPdisplay : MonoBehaviour
{
    public float m_distance;
    public Image m_FillImage;
    public Image m_BackgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        //HP�o�[�̓�����
        m_FillImage.CrossFadeAlpha(0, 0, true);
        m_BackgroundImage.CrossFadeAlpha(0, 0, true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _distance1 = gameObject.transform.position;
        Vector3 _distance2 = GameObject.Find("player").transform.position;

        m_distance = Vector3.Distance(_distance1, _distance2);

        if (m_distance < 30.0f)
        {
            //�U�������HP����������Ԃ̏ꍇ�A�\������
            if (transform.parent.gameObject.GetComponent<EnemyHp>().hp < 10)
            {
                m_FillImage.CrossFadeAlpha(1, 0, true);
                m_BackgroundImage.CrossFadeAlpha(1, 0, true);
            }
        }

        if(m_distance >= 30.0f)
        {
            //HP�o�[�̓�����
            m_FillImage.CrossFadeAlpha(0, 0, true);
            m_BackgroundImage.CrossFadeAlpha(0, 0, true);
        }
    }
}
