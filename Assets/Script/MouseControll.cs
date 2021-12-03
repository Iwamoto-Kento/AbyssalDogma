using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControll : MonoBehaviour
{
    private Vector3 lastMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        // マウスポインターが中央から離れすぎた場合
        if (Mathf.Abs(Screen.width / 2 - Input.mousePosition.x) > 50 || Mathf.Abs(Screen.height / 2 - Input.mousePosition.y) > 50)
        {
            Cursor.lockState = CursorLockMode.Locked;
            lastMousePosition = Input.mousePosition;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            lastMousePosition = Input.mousePosition;
        }
    }
}
