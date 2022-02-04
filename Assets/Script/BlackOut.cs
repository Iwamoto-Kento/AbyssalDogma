using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackOut : MonoBehaviour
{
	float fadeSpeed = 0.01f;        //�����x���ς��X�s�[�h���Ǘ�
	float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�

	public bool isFadeOut = false;  //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
	public bool flg = false;
	public bool GameOverFlg = false;

	Image fadeImage;                //�����x��ύX����p�l���̃C���[�W

	void Start()
	{
		fadeImage = GetComponent<Image>();
		red = fadeImage.color.r;
		green = fadeImage.color.g;
		blue = fadeImage.color.b;
		alfa = fadeImage.color.a;
	}

	void Update()
	{
		if (flg == true)
		{
			StartBlackOut();
		}
	}

	void StartBlackOut()
	{
        fadeImage.enabled = true;  // a)�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed;         // b)�s�����x�����X�ɂ�����
        SetAlpha();               // c)�ύX���������x���p�l���ɔ��f����
        if (alfa >= 1)
        {             // d)���S�ɕs�����ɂȂ����珈���𔲂���
            isFadeOut = false;
			GameOverFlg = true;
		}
    }

    void SetAlpha()
	{
		fadeImage.color = new Color(red, green, blue, alfa);
	}

	void ChangeScene()
	{
		Cursor.visible = true;
		SceneManager.LoadScene("GameOverScene");
	}
}
