using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] private Transform pivot = null;

    // Start is called before the first frame update
    void Start()
    {
        if(pivot == null)
        {
            pivot = transform.parent;
        }
    }

    // Update is called once per frame

    [Range(-0.999f,- 0.5f)] public float minYAngle = -0.5f;
    [Range(0.5f, 0.999f)] public float maxYAngle = 0.5f;
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");

        pivot.transform.Rotate(0, X_Rotation, 0);

        float nowAngle = pivot.transform.localPosition.x;

        if(-Y_Rotation != 0)
        {
            if(0 < Y_Rotation)
            {
                if(minYAngle <= nowAngle)
                {
                    pivot.transform.Rotate(Y_Rotation, 0, 0);
                }
            }
            else
            {
                if(nowAngle <= maxYAngle)
                {
                    pivot.transform.Rotate(Y_Rotation, 0, 0);
                }
            }
        }

        pivot.eulerAngles = new Vector3(pivot.eulerAngles.x, pivot.eulerAngles.y, 0f);
    
    }
}
