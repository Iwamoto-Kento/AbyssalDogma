using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] public int hp = 10;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            GameObject.Find("BlackPanel").GetComponent<BlackOut>().flg = true;
        }

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    //”­•\‰ï—p
        //    if (hp < 50)
        //    {
        //        hp++;
        //        slider.value = hp;
        //    }
        //}
    }

    public void Damage()
    {
        hp--;
        if (slider.value > 0)
        {
            slider.value = hp;
        }
    }
}
