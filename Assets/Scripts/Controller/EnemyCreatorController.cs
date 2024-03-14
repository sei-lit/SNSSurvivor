using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatorController : MonoBehaviour
{

    public GameObject[] prefabsEnemys;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spwnEnemy(int spwnEnemyNumber) {
        Instantiate(prefabsEnemys[spwnEnemyNumber], transform.position, transform.rotation);
    }
}
