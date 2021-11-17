using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Transform pivot;
    // Start is called before the first frame update
    void Start()
    {
        if(character == null)
        {
            character = transform.parent;
        }

        if(pivot == null)
        {
            pivot = transform;
        }
    }

    // Update is called once per frame

    [Range(-0.999f, -0.5f)] public float maxYAngle = -0.5f;
    [Range(0.5f, 0.999f)] public float minYAngle = 0.5f;
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X") * -1;
        float Y_Rotation = Input.GetAxis("Mouse Y");

        character.transform.Rotate(0, X_Rotation, 0);

        float nowAngle = pivot.transform.localRotation.x;

        if(-Y_Rotation != 0)
        {
            if(0 < Y_Rotation)
            {
                if(minYAngle <= nowAngle)
                {
                    pivot.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
            else
            {
                if(nowAngle <= maxYAngle)
                {
                    pivot.transform.Rotate(-Y_Rotation, 0, 0);
                }
            }
        }
    }
}
