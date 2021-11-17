using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField] float XSpeed =  0.0f;
    [SerializeField] float YSpeed =  0.0f;
    [SerializeField] float ZSpeed =  0.0f;

    private void Start()
    {
        YSpeed = YSpeed == 0f ? 10f : YSpeed;
    }

    private void Update()
    {
        transform.Rotate(
                         XSpeed * Time.deltaTime,
                         YSpeed * Time.deltaTime,
                         ZSpeed * Time.deltaTime
                        );
    }
}
