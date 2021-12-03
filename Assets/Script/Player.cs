using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;          //�ړ�����
    [SerializeField] private float moveSpeed = 5.0f;    //�ړ����x
    [SerializeField] private float applyspeed = 0.2f;   //��]�̓K�p���x
    [SerializeField] private PlayerFollowCamera refCamera; //�J�����̐�����]���Q�Ƃ���p
    [SerializeField] private bool m_AttractFlg = false;
    private Vector3 m_TargetPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //WASD���͂���AXZ���ʁi�����Ȓn�ʁj���ړ��������(velocity)�𓾂܂�
        velocity = Vector3.zero;
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

        //���x�x�N�g���̒�����1�b��moveSpeed�����i�ނ悤�ɒ������܂�
        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

        //�����ꂩ�̕����Ɉړ����Ă�ꍇ
        if (velocity.magnitude > 0)
        {
            //�v���C���[�̉�](transform.rotation)�̍X�V
            //����]��Ԃ̃v���C���[��z+����(�㓪��)���A�ړ��̔��Ε���(-velocity)�ɉ񂷉�]�ɒi�X�߂Â��܂�
            //�J�����̐�����](refCamera.hRotation)�ŉ񂵂��ړ��̔��Ε���(-velocity)�ɉ񂷉�]�ɒi�X�߂Â��܂�
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera.hRotation * refCamera.vRotation * -velocity), applyspeed);


            //�v���C���[�̉�](transform.rotation)�̍X�V
            //����]��Ԃ̃v���C���\��z+����(�㓪��)���A�ړ��̔��Ε���(-velocity)�ɉ񂷉�]�Ƃ��܂�
            //transform.rotation = Quaternion.LookRotation(-velocity);

            //�v���C���[�̈ʒu�itransform.position�j�̍X�V
            //�J�����̐�����](refCamera.hRotation)�ŉ񂵂��ړ�����(velocity)�𑫂����݂܂�
            transform.position += refCamera.hRotation * refCamera.vRotation * velocity;
        }
    }

    public bool Attract(Vector3 _pos, Ray _ray)
    {
        float step = moveSpeed * 10 * Time.deltaTime;
        m_TargetPos = transform.position + _ray.direction;
        transform.position = Vector3.MoveTowards(transform.position, m_TargetPos, step);

        float len = Vector3.Distance(transform.position, _pos);

        if (len <= 2)
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

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Player : MonoBehaviour
//{
//    [SerializeField] private Vector3 velocity;          //移動方吁E
//    [SerializeField] private float moveSpeed = 5.0f;    //移動速度
//    [SerializeField] private float applyspeed = 0.2f;   //回転の適用速度
//    [SerializeField] private PlayerFollowCamera refCamera; //カメラの水平回転を参照する用
//    [SerializeField]private bool m_AttractFlg = false;
//    private Vector3 m_TargetPos;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        //WASD入力から、XZ平面�E�水平な地面�E�を移動する方吁Evelocity)を得まぁE
//        velocity = Vector3.zero;
//        if(Input.GetKey(KeyCode.W))
//        {
//            velocity.z += 1;
//        }
//        if (Input.GetKey(KeyCode.A))
//        {
//            velocity.x -= 1;
//        }
//        if (Input.GetKey(KeyCode.S))
//        {
//            velocity.z -= 1;
//        }
//        if (Input.GetKey(KeyCode.D))
//        {
//            velocity.x += 1;
//        }

//        //速度ベクトルの長さを1秒でmoveSpeedだけ進むように調整しまぁE
//        velocity = velocity.normalized * moveSpeed * Time.deltaTime;

//        //ぁE��れかの方向に移動してる場吁E
//        if(velocity.magnitude >0)
//        {
//            //プレイヤーの回転(transform.rotation)の更新
//            //無回転状態�Eプレイヤーのz+方吁E後頭部)を、移動�E反対方吁E-velocity)に回す回転に段、E��づけまぁE
//            //カメラの水平回転(refCamera.hRotation)で回した移動�E反対方吁E-velocity)に回す回転に段、E��づけまぁE
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera.hRotation * refCamera.vRotation *  -velocity), applyspeed);

//            //プレイヤーの位置�E�Eransform.position�E��E更新
//            //カメラの水平回転(refCamera.hRotation)で回した移動方吁Evelocity)を足しこみまぁE
//            transform.position += refCamera.hRotation * refCamera.vRotation *  velocity;
//        }
//    }

//    public bool Attract(Vector3 _pos,Ray _ray)
//    {
//        float step = moveSpeed* 10 * Time.deltaTime;
//        m_TargetPos = transform.position + _ray.direction;
//        transform.position = Vector3.MoveTowards(transform.position, m_TargetPos, step);

//        float len = Vector3.Distance(transform.position, _pos);

//        if(len <= 3)
//        {
//            m_AttractFlg = false;
//        }
//        else
//        {
//            m_AttractFlg = true;
//        }

//        return m_AttractFlg;
//    }
//}

