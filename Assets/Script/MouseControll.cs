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

        // マウスポインターが中央から離れすぎた場吁E
        if (Mathf.Abs(Screen.width / 2 - Input.mousePosition.x) > 10 || Mathf.Abs(Screen.height / 2 - Input.mousePosition.y) > 10)
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