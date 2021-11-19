using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RenderTrue()
    {
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = true;
    }

    public void RenderFalse()
    {
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = false;
    }
}
