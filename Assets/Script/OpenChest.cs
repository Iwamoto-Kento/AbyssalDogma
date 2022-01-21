using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private float m_distance;
    private Animator anime;
    [SerializeField] private ParticleSystem particle;
    public bool flg = false;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _distance1 = gameObject.transform.position;
        Vector3 _distance2 = GameObject.Find("player").transform.position;

        m_distance = Vector3.Distance(_distance1, _distance2);

        if(m_distance <= 5.0f)
        {
            anime.SetBool("Bool", true);
        }
    }

    void ParticleShine()
    {
        particle.Play();
        flg = true;
    }
}
