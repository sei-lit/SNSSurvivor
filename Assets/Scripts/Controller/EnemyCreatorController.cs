using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCreatorController : MonoBehaviour
{
    public Slider blowUpSlider;
    public BlowUpSliderController blowUpSliderController;
    float swarmSpwnTimer = 0.0f;
    float swarmSpwnSpan = 0.75f;
    public GameObject[] prefabsEnemys;
    public Enemys[] spwnedEnemy = {Enemys.bat, Enemys.crab, Enemys.pebble, Enemys.rat, Enemys.skull, Enemys.spikedSlime};
    // Start is called before the first frame update
    void Start()
    {
        blowUpSliderController = blowUpSlider.GetComponent<BlowUpSliderController>();
       InvokeRepeating("spwnEnemy", 0.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(blowUpSliderController.isUnderBlowUp) {
            EnemySwarm();
        }
    }

    void EnemySwarm() {
        EnemyController.isMoving = true;
        swarmSpwnTimer += Time.deltaTime;
        if (swarmSpwnTimer > swarmSpwnSpan) {
            spwnEnemy();
            swarmSpwnTimer = 0.0f;
        }
    }

    // public void StopSwarm() {
    //     if(IsInvoking()) {
    //         CancelInvoke();
    //         InvokeRepeating("spwnEnemy", 0.0f, 2.0f);
    //     } else {
    //         Debug.Log("error: Invoke is not working properly in swarm...");
    //     }
    // }

    // public void StopSpwn() {
    //     if(IsInvoking()) {
    //         CancelInvoke();
    //     } else {
    //         Debug.Log("Invoke is not working...");
    //     }
    // }

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
                Debug.Log("error: Invailed enum...");
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
