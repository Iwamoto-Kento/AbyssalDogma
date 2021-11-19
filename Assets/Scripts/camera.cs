using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public GameObject aimObject;

    private Vector3 offset;
    private Vector3 setPosition;

    private float r = 5;

    private float deg = 0;

    float horizonal;

    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

        transform.position += offset;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        horizonal = Input.GetAxis("Mouse X") * 3f;

        vertical = Input.GetAxis("Mouse Y");

        if(horizonal != 0)
        {
            deg -= horizonal;
        }

        setPosition.x = player.transform.position.x + r * Mathf.Cos(Mathf.Deg2Rad * deg);
        setPosition.y = player.transform.position.y + offset.y;
        setPosition.z = player.transform.position.z + r * Mathf.Sin(Mathf.Deg2Rad * deg);

        transform.position = setPosition;

        transform.LookAt(aimObject.transform);
    }
}
