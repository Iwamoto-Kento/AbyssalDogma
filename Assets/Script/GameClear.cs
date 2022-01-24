using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    [SerializeField] private bool flg = false;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        flg = GameObject.Find("Panel").GetComponent<FadeController>().GameClearFlg;

        if (flg == true)
        {
            image.enabled = true;

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("TitleScene");
                Cursor.visible = true;
            }
        }
    }
}
