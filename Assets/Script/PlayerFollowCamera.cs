using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;          //�����Ώۃv���C���[

    [SerializeField] private float distance = 10.0f;    //�����Ώۃv���C���[����J������b������
    [SerializeField] public Quaternion vRotation;      //�J�����̐�����]�i�����낵��]�j
    [SerializeField] public Quaternion hRotation;       //�J�����̐�����]

    [SerializeField] private float turnspeed = 10.0f;   //��]���x

    // Start is called before the first frame update
    void Start()
    {
        //��]�̏�����
        vRotation = Quaternion.Euler(0, 0, 0);     //������]�iX�������Ƃ����]�j�́A30�x�����낷��]
        hRotation = Quaternion.Euler(0,0,0);            //������]�iY�������Ƃ����]�j�́A����]
        transform.rotation = hRotation * vRotation; //�ŏI�I�ȃJ�����̉�]�́A������]���Ă��琅����]���鍇����]

        //�ʒu�̏�����
        //player�ʒu���狗��distance������O�Ɉ������ʒu��ݒ肵�Ă��܂�
        transform.position = player.position - transform.rotation * Vector3.forward * distance; 
    }

    // Update is called once per frame
    void Update()
    {
        //�J�����̈ʒu�itransform.position�j�̍X�V
        //player�ʒu���狗��distance������O�Ɉ������ʒu��ݒ肵�܂�
    
        transform.position = player.position - transform.rotation * Vector3.forward * distance;
    }

    private void LateUpdate()
    {
        //������]�̍X�V
        //if (Input.GetMouseButton(0))
        hRotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X")* turnspeed,0);

        ////if (Input.GetMouseButton(1))
        vRotation *= Quaternion.Euler(Input.GetAxis("Mouse Y") * -1 * turnspeed,0 , 0);

        //�J�����̉�](transform.rotatin)�̍X�V
        //������]���Ă��琅����]���鍇����]�Ƃ��܂�
        transform.rotation = hRotation * vRotation;

        //�J�����̈ʒu�itransform.position�j�̍X�V
        //player�ʒu���狗��distance������O�Ɉ������ʒu��ݒ肵�܂�
        transform.position = player.position + new Vector3(0,4,0) - transform.rotation * Vector3.forward * distance;
    }
}
