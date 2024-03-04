using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public static bool isMoving = false;
    float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving) {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }
}
