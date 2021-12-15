using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScale : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject Sphere;
    float m_pos;
    [SerializeField] private bool m_clickBotton = false;
    [Range(0, 10)] public float m_speed = 0;
    [Range(10, 1000)] public float m_max = 100;

    void Start()
    {
        m_pos = 0;
        Sphere.transform.localScale = new Vector3(0, 0, 0);
        Sphere.transform.position = player.position + new Vector3(0, 0.5f, 0);
        Sphere.SetActive(false);
    }

    void Update()
    {
        if (m_clickBotton == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_clickBotton = true;
                Sphere.transform.gameObject.SetActive(true);
            }
        }
        else
        {
            m_pos += m_speed;
            if (m_pos >= m_max)
            {
                m_pos = 0;
                m_clickBotton = false;
                Sphere.SetActive(false);
            }

        }
        Sphere.transform.position = player.position + new Vector3(0, 0.5f, 0);

        Sphere.transform.localScale = new Vector3(m_pos, m_pos, m_pos);
    }
}

