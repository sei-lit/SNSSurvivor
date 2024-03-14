using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Enemy enemy = new Enemy();
    public GameObject enemyCreator;
    EnemyCreatorController enemyCreatorController;
    int spwnEnemyNumber;
    public GameObject gameOverCanvas;
    public static bool isMoving = false;
    public Animator enemyAnimator;
    float speed = 150;
    float spwnInterval = 1.0f;    
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
        enemyCreatorController = enemyCreator.GetComponent<EnemyCreatorController>();
        InvokeRepeating("spwnRandomEnemys", 0.0f, spwnInterval);
        enemy = enemy.CreateEnemy(spwnEnemyNumber);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    void spwnRandomEnemys() {
        Debug.Log("spwnRandomEnemys");
        spwnEnemyNumber = Random.Range(0, enemy.enemys.Length);
        enemyCreatorController.spwnEnemy(spwnEnemyNumber);
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("OnTriggerEnter2D");
        Debug.Log(other.gameObject.name);
        var playerController = other.gameObject.GetComponent<PlayerController>();
        var player = playerController.player;
        if(player == null) {Debug.Log("player == null");return;}       
        Debug.Log("PlayerIsAttacking: " + playerController.isAttacking);
        if(!playerController.isAttacking) {
            enemyAnimator.SetTrigger("Attack");
            playerController.playerAnimator.SetTrigger("getHurt");
            KnockBack();
            player.AddDamage(player.CalculateDamage(enemy.intelligence, enemy.assets));
            player.UpdateStatus();
        }
        if(player.IsDead()) {
            GameStop(playerController);
            playerController.playerAnimator.SetTrigger("isDead");
            // Destroy(other.gameObject, 1.0f);
            Debug.Log("プレイヤーを倒しました");
            GameOver();
        }
    }

    void GameOver() {
        gameOverCanvas.SetActive(true);
    } 

    void GameStop(PlayerController playerController) {
        speed = 0;
        playerController.roadSpeed = 0;
        playerController.backgroundCitySpeed = 0;
    }

    public void KnockBack() {
        speed = 0;
        Debug.Log("this.transform.position + Vector3.right * 30: " + (this.transform.position + Vector3.right * 5.0f));
        transform.position += Vector3.right * 50.0f;
        speed = 100;
    }
}
