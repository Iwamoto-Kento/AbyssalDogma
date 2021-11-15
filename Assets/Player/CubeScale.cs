using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScale : MonoBehaviour
{
    [SerializeField] private Transform player;
    float m_pos;
    [SerializeField] private bool m_clickBotton = false;
    [Range(0, 10)] public float m_speed = 0;
    [Range(1000, 10000)] public float m_max = 1000;

    void Start()
    {
        m_pos = 0;
        transform.localScale = new Vector3(0, 0, 0);
        transform.position = player.position + new Vector3(0, 0.5f, 0);
    }

    void Update()
    {
        if (m_clickBotton == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_clickBotton = true;
            }
        }
        else
        {
            m_pos += m_speed;
            if (m_pos >= m_max)
            {
                m_pos = 0;
                m_clickBotton = false;
            }
            
        }
        transform.position = player.position + new Vector3(0, 0.5f, 0);

        transform.localScale = new Vector3(m_pos, m_pos, m_pos);
    }
}

