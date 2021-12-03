using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;          //移動方向
    [SerializeField] private float moveSpeed = 5.0f;    //移動速度
    [SerializeField] private float applyspeed = 0.2f;   //回転の適用速度
    [SerializeField] private PlayerFollowCamera refCamera; //カメラの水平回転を参照する用
    [SerializeField]private bool m_AttractFlg = false;
    private Vector3 m_TargetPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //WASD入力から、XZ平面（水平な地面）を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            velocity.z += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.x += 1;
        }

        //速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整します
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        //いずれかの方向に移動してる場合
        if(velocity.magnitude >0)
        {
            //プレイヤーの回転(transform.rotation)の更新
            //無回転状態のプレイヤーのz+方向(後頭部)を、移動の反対方向(-velocity)に回す回転に段々近づけます
            //カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々近づけます
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera.hRotation * refCamera.vRotation *  -velocity), applyspeed);


            //プレイヤーの回転(transform.rotation)の更新
            //無回転状態のプレイヤ―のz+方向(後頭部)を、移動の反対方向(-velocity)に回す回転とします
            //transform.rotation = Quaternion.LookRotation(-velocity);

            //プレイヤーの位置（transform.position）の更新
            //カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足しこみます
            transform.position += refCamera.hRotation * refCamera.vRotation *  velocity;
        }
    }

    public bool Attract(Vector3 _pos,Ray _ray)
    {
        float step = moveSpeed* 10 * Time.deltaTime;
        m_TargetPos = transform.position + _ray.direction;
        transform.position = Vector3.MoveTowards(transform.position, m_TargetPos, step);

        float len = Vector3.Distance(transform.position, _pos);

        if(len <= 2)
        {
            m_AttractFlg = false;
        }
        else
        {
            m_AttractFlg = true;
        }

        return m_AttractFlg;
    }
}
