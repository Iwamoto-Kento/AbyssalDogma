using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;          //移動方向
    [SerializeField] private float moveSpeed = 5.0f;    //移動速度
    [SerializeField] private float applyspeed = 0.2f;   //回転の適用速度
    [SerializeField] private PlayerFollowCamera refCamera; //カメラの水平回転を参照する用
    [SerializeField] private bool m_AttractFlg = false;
    [SerializeField] private ParticleSystem particle;   //泡のパーティクル
    private Vector3 m_TargetPos;
    private float dis = 999;
    private bool particleFlg = false;

    private Hook hook;
    private Animator anime;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        particle.Stop();
        this.hook = FindObjectOfType<Hook>();
    }

    // Update is called once per frame
    void Update()
    {
       

        //WASD入力から、XZ平面（水平な地面）を移動する方向(velocity)を得ます
        velocity = Vector3.zero;
        speed = 0.0f;
        if (Input.GetKey(KeyCode.W))
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
        if (velocity.magnitude > 0 || hook.m_AttractFlg == true)
        {
            if (particleFlg == false || m_AttractFlg == false)
            {
                particle.Play();
                particleFlg = true;

            }

            //プレイヤーの回転(transform.rotation)の更新
            //無回転状態のプレイヤーのz+方向(後頭部)を、移動の反対方向(-velocity)に回す回転に段々近づけます
            //カメラの水平回転(refCamera.hRotation)で回した移動の反対方向(-velocity)に回す回転に段々近づけます
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera.hRotation * refCamera.vRotation * -velocity), applyspeed);


            //プレイヤーの回転(transform.rotation)の更新
            //無回転状態のプレイヤ―のz+方向(後頭部)を、移動の反対方向(-velocity)に回す回転とします
            //transform.rotation = Quaternion.LookRotation(-velocity);

            //プレイヤーの位置（transform.position）の更新
            //カメラの水平回転(refCamera.hRotation)で回した移動方向(velocity)を足しこみます
            transform.position += refCamera.hRotation * refCamera.vRotation * velocity;
            speed = 1.0f;
        }
        else{
            //if (particle.isStopped) //パーティクルが終了したか判別
            //{
            if (particleFlg == true)
            {
                particle.Stop();
                particleFlg = false;
            }
            //particle.Pause();
            //} 
        }

        anime.SetFloat("Speed", speed);
    }

    public bool Attract(Vector3 _pos, Ray _ray)
    {
        float step = moveSpeed * 10 * Time.deltaTime;
        m_TargetPos = transform.position + _ray.direction;
        transform.position = Vector3.MoveTowards(transform.position, m_TargetPos, step);
        

        float len = Vector3.Distance(transform.position, _pos);
        Debug.Log(len);
        Debug.Log(transform.position);
        Debug.Log(_pos);
        Debug.Log(m_AttractFlg);

        if (len <= 2)
        {
            m_AttractFlg = false; 
        }
        else
        {
            m_AttractFlg = true;
        }

        if (len > dis)
        {
            m_AttractFlg = false;
            dis = 999;
            return m_AttractFlg;
        }
        dis = len;

        return m_AttractFlg;
    }
}
