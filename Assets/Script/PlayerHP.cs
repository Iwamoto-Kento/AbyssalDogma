using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private int hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void Damage()
    {
        hp--;
    }
}
