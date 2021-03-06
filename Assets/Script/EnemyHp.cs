using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour, hidame, death
{
    //MonoBehaviorのあとに「、」を付けて
    //hidame(自分で作ったインターフェースの名前ファイル名
    //これをやるとインターフェースの中のやつが使える
    public int hp = 10;                   //敵の体力
    public Slider slider;

    void hidame.hidame_01(int damage)    //hidameというファイルの中の
    {                                  //hidame_01という機能を使うぞって意味です
        hp -= damage;
        if (slider.value > 0)
        {
            slider.value = hp;
        }
    }

    void death.death_01()
    {
        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {
        slider.value = hp;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
