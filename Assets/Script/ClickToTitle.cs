using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToTitle : MonoBehaviour
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
        flg = GameObject.Find("BlackPanel").GetComponent<BlackOut>().GameOverFlg;

        if (flg == true)
        {
            image.enabled = true;
        }
    }
}
