using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreatorController : MonoBehaviour
{

    public GameObject[] prefabsEnemys;
    public Enemys[] spwnedEnemy = {Enemys.bat, Enemys.crab, Enemys.pebble, Enemys.rat, Enemys.skull, Enemys.spikedSlime};
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("spwnEnemy", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spwnEnemy() {
        int spwnEnemyNumber = Random.Range(0, prefabsEnemys.Length);
        EnemyController enemyController = prefabsEnemys[spwnEnemyNumber].GetComponent<EnemyController>();
        if(!EnemyController.isMoving) {Debug.Log("Enemy is not moving"); return;}
        switch (spwnedEnemy[spwnEnemyNumber]) {
            case Enemys.bat:
                enemyController.enemy = new Bat();
                Instantiate(prefabsEnemys[spwnEnemyNumber], this.transform.position, this.transform.rotation);
                return;
            case Enemys.crab:
                enemyController.enemy = new Crab();
                Instantiate(prefabsEnemys[spwnEnemyNumber], this.transform.position, this.transform.rotation);
                return;
            case Enemys.pebble:
                enemyController.enemy = new Pebble();
                Instantiate(prefabsEnemys[spwnEnemyNumber], this.transform.position, this.transform.rotation);
                return;
            case Enemys.rat:
                enemyController.enemy = new Rat();
                Instantiate(prefabsEnemys[spwnEnemyNumber], this.transform.position, this.transform.rotation);
                return;
            case Enemys.skull:
                enemyController.enemy = new Skull();
                Instantiate(prefabsEnemys[spwnEnemyNumber], this.transform.position, this.transform.rotation);
                return;
            case Enemys.spikedSlime:
                enemyController.enemy = new SpikedSlime();
                Instantiate(prefabsEnemys[spwnEnemyNumber], this.transform.position, this.transform.rotation);
                return;
            default:
                Debug.Log("Invailed enum...");
                return;
        }
    }
}

public enum Enemys {
    bat,
    crab,
    pebble,
    rat,
    skull,
    spikedSlime
}
