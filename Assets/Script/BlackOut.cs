using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackOut : MonoBehaviour
{
	float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
	float red, green, blue, alfa;   //パネルの色、不透明度を管理

	public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
	public bool flg = false;
	public bool GameOverFlg = false;

	Image fadeImage;                //透明度を変更するパネルのイメージ

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
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alfa += fadeSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        if (alfa >= 1)
        {             // d)完全に不透明になったら処理を抜ける
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
