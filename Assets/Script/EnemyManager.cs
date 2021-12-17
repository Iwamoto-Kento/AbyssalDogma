using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int count = 0;
    float span = 5f;
    public float time = 0f;
    public GameObject EnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > span && count < 4)
        {
            GameObject enemy = (GameObject)Instantiate(EnemyPrefab, new Vector3(Random.Range(gameObject.transform.position.x + 10, gameObject.transform.position.x + 30), 5, Random.Range(gameObject.transform.position.z + 10, gameObject.transform.position.z + 30)), Quaternion.identity);
            count++;
            time = 0;
        }

    }
}

//public interface hidame
//{
//    void hidame_01(int damage);
//}

//public interface death
//{
//    void death_01();
//}

//public interface Move
//{
//    bool MoveEnemy(Vector3 _pos);
//}

