using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;          //注視対象プレイヤー

    [SerializeField] private float distance = 10.0f;    //注視対象プレイヤーからカメラを話す距離
    [SerializeField] public Quaternion vRotation;      //カメラの垂直回転（見下ろし回転）
    [SerializeField] public Quaternion hRotation;       //カメラの水平回転

    [SerializeField] private float turnspeed = 10.0f;   //回転速度

    // Start is called before the first frame update
    void Start()
    {
        //回転の初期化
        vRotation = Quaternion.Euler(0, 0, 0);     //垂直回転（X軸を軸とする回転）は、30度見下ろす回転
        hRotation = Quaternion.Euler(0,0,0);            //水平回転（Y軸を軸とする回転）は、無回転
        transform.rotation = hRotation * vRotation; //最終的なカメラの回転は、垂直回転してから水平回転する合成回転

        //位置の初期化
        //player位置から距離distanceだけ手前に引いた位置を設定しています
        transform.position = player.position - transform.rotation * Vector3.forward * distance; 
    }

    // Update is called once per frame
    void Update()
    {
        //カメラの位置（transform.position）の更新
        //player位置から距離distanceだけ手前に引いた位置を設定します
    
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }

    private void LateUpdate()
    {
        //水平回転の更新
        //if (Input.GetMouseButton(0))
        hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X")* turnspeed,0);

        ////if (Input.GetMouseButton(1))
        vRotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * -1 * turnspeed,0 , 0);

        //カメラの回転(transform.rotatin)の更新
        //垂直回転してから水平回転する合成回転とします
        transform.rotation = hRotation * vRotation;

        //カメラの位置（transform.position）の更新
        //player位置から距離distanceだけ手前に引いた位置を設定します
        transform.position = player.position + new Vector3(0,4,0) - transform.rotation * Vector3.forward * distance;
    }
}
