using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrustumCulling : MonoBehaviour
{
    [SerializeField]private Bounds[] _boundsList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        System.Array.Resize(ref planes, 4);     // near,far面は要らないので排除。
        foreach (Bounds bounds in _boundsList)
        {
            if (GeometryUtility.TestPlanesAABB(planes, bounds))
            {
                // 内側。
                // Renderer true などとする

                var renderer = gameObject.GetComponent<Renderer>();
                // 非表示
                renderer.enabled = false;

                //a.GetComponent<Render>().RenderFalse();
            }
            else
            {
                // 外側。
                // Renderer false などとする

                var renderer = gameObject.GetComponent<Renderer>();
                // 非表示
                renderer.enabled = false;

                //a.GetComponent<Render>().RenderFalse();
            }
        }
    }

    /// <summary>
    ///  バウンディングボックスによる、視錐台カリング。
    /// </summary>
    //public void Frustum(Bounds[] _boundsList)
    //{
    //    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
    //    System.Array.Resize(ref planes, 4);     // near,far面は要らないので排除。
    //    foreach (Bounds bounds in _boundsList)
    //    {
    //        if (GeometryUtility.TestPlanesAABB(planes, bounds))
    //        {
    //            // 内側。
    //            // Renderer true などとする

    //            var renderer = gameObject.GetComponent<Renderer>();
    //            // 非表示
    //            renderer.enabled = false;

    //            //a.GetComponent<Render>().RenderFalse();
    //        }
    //        else
    //        {
    //            // 外側。
    //            // Renderer false などとする

    //            var renderer = gameObject.GetComponent<Renderer>();
    //            // 非表示
    //            renderer.enabled = false;

    //            //a.GetComponent<Render>().RenderFalse();
    //        }
    //    }
    //}
}
