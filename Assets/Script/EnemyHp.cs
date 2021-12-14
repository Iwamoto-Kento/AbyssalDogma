using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour, hidame, death
{
    //MonoBehaviorのあとに「、」を付けて
    //hidame(自分で作ったインターフェースの名前ファイル名
    //これをやるとインターフェースの中のやつが使える
    public int hp = 10;                   //敵の体力

    void hidame.hidame_01(int damage)    //hidameというファイルの中の
    {                                  //hidame_01という機能を使うぞって意味です
        hp -= damage;
    }

    void death.death_01()
    {
        gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
