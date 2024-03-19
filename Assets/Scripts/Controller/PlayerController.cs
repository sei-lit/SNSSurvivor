using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    public Player player = Player.Current;
    public Animator playerAnimator;
    BoxCollider2D enemyBoxCollider2D;
    public bool isRunning = false;
    // public bool isSNS = false;
    public bool isAttacking;
    public bool isDead = false;
    // public GameObject[] roads;
    // public GameObject[] backgroundCities;

    // public GameObject canvasOffset;
    // public float roadSpeed = 150;
    // public float backgroundCitySpeed = 40;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        player.getCurrentStatus();
        player.UpdateStatus();
    }

    // Update is called once per frame
    void Update()
    {
        // if (isRunning) {
        //     MovebackgroundCities();
        //     MoveRoads();
        // } else {

        // }
    }

    // public void changeMode() {
    //     isSNS = !isSNS;
    // }

    public void Run() {
        isRunning = true;
        playerAnimator.SetBool("isRunning", true);
        EnemyController.isMoving = true;
    }

    public void Stop() {
        isRunning = false;
        playerAnimator.SetBool("isRunning", false);
        EnemyController.isMoving = false;
    }

    //From here, the fucking worst program I've ever seen
    // void MoveRoads() {
    //     for(int i = 0; i < roads.Length; i++) {
    //         roads[i].transform.position += new Vector3(-roadSpeed * Time.deltaTime, 0, 0);
    //     }

    //     for(int i = 0; i < roads.Length; i++) {
    //         if(roads[i].transform.position.x < -720 + canvasOffset.transform.position.x) {
    //             Debug.Log(roads[i].transform.position.x);
    //             roads[i].transform.position = new Vector3(800 - 88 + canvasOffset.transform.position.x, canvasOffset.transform.position.y, 1);
    //         }
    //     }
    // }

    // void MovebackgroundCities() {
    //     for(int i = 0; i < backgroundCities.Length; i++) {
    //         backgroundCities[i].transform.position += new Vector3(-backgroundCitySpeed * Time.deltaTime, 0, 0);
    //     }

    //     for(int i = 0; i < backgroundCities.Length; i++) {
    //         if(backgroundCities[i].transform.position.x < -720 + canvasOffset.transform.position.x) {
    //             backgroundCities[i].transform.position = new Vector3(800 - 88 + canvasOffset.transform.position.x, canvasOffset.transform.position.y, 1);
    //         }
    //     }
    // }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("OnTriggerEnter2D");
        Debug.Log(other.gameObject.name);
        var enemyController = other.gameObject.GetComponent<EnemyController>();
        var enemy = enemyController.enemy;
        if(enemy == null) {Debug.Log("enemy == null");return;}
        double percentage = enemy.CalculateGetAttackedPercentage(player.lv);
        Debug.Log("percentage: " + percentage);
        isAttacking = enemy.GetAttacked(percentage);
        Debug.Log("isAttacking: " + isAttacking);
        if(isAttacking) {
            playerAnimator.SetTrigger("isAttacking");
            enemyController.enemyAnimator.SetTrigger("Hit");
            enemyController.KnockBack();
            enemy.AddDamage(enemy.CalculateDamage(player.finalIntelligence, player.finalAssets));
            Debug.Log("敵の残りHP: " + enemy.GetHp());
        }
        if(enemy.IsDead()) {
            enemyBoxCollider2D = enemyController.GetComponent<BoxCollider2D>();
            enemyBoxCollider2D.enabled = false;
            enemyController.enemyAnimator.SetTrigger("Death");
            Destroy(other.gameObject, 1.0f);
            player.getExp(enemy.exp);
            Debug.Log("敵を倒しました");
        }
    }
}
