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
        System.Array.Resize(ref planes, 4);     // near,far�ʂ͗v��Ȃ��̂Ŕr���B
        foreach (Bounds bounds in _boundsList)
        {
            if (GeometryUtility.TestPlanesAABB(planes, bounds))
            {
                // �����B
                // Renderer true �ȂǂƂ���

                var renderer = gameObject.GetComponent<Renderer>();
                // ��\��
                renderer.enabled = false;

                //a.GetComponent<Render>().RenderFalse();
            }
            else
            {
                // �O���B
                // Renderer false �ȂǂƂ���

                var renderer = gameObject.GetComponent<Renderer>();
                // ��\��
                renderer.enabled = false;

                //a.GetComponent<Render>().RenderFalse();
            }
        }
    }

    /// <summary>
    ///  �o�E���f�B���O�{�b�N�X�ɂ��A������J�����O�B
    /// </summary>
    //public void Frustum(Bounds[] _boundsList)
    //{
    //    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
    //    System.Array.Resize(ref planes, 4);     // near,far�ʂ͗v��Ȃ��̂Ŕr���B
    //    foreach (Bounds bounds in _boundsList)
    //    {
    //        if (GeometryUtility.TestPlanesAABB(planes, bounds))
    //        {
    //            // �����B
    //            // Renderer true �ȂǂƂ���

    //            var renderer = gameObject.GetComponent<Renderer>();
    //            // ��\��
    //            renderer.enabled = false;

    //            //a.GetComponent<Render>().RenderFalse();
    //        }
    //        else
    //        {
    //            // �O���B
    //            // Renderer false �ȂǂƂ���

    //            var renderer = gameObject.GetComponent<Renderer>();
    //            // ��\��
    //            renderer.enabled = false;

    //            //a.GetComponent<Render>().RenderFalse();
    //        }
    //    }
    //}
}
