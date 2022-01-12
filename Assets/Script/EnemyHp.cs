using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour, hidame, death
{
    //MonoBehavior�̂��ƂɁu�A�v��t����
    //hidame(�����ō�����C���^�[�t�F�[�X�̖��O�t�@�C����
    //��������ƃC���^�[�t�F�[�X�̒��̂���g����
    public int hp = 10;                   //�G�̗̑�
    public Slider slider;

    void hidame.hidame_01(int damage)    //hidame�Ƃ����t�@�C���̒���
    {                                  //hidame_01�Ƃ����@�\���g�������ĈӖ��ł�
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
