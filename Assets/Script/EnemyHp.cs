using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour, hidame, death
{
    //MonoBehavior�̂��ƂɁu�A�v��t����
    //hidame(�����ō�����C���^�[�t�F�[�X�̖��O�t�@�C����
    //��������ƃC���^�[�t�F�[�X�̒��̂���g����
    public int hp = 10;                   //�G�̗̑�

    void hidame.hidame_01(int damage)    //hidame�Ƃ����t�@�C���̒���
    {                                  //hidame_01�Ƃ����@�\���g�������ĈӖ��ł�
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
