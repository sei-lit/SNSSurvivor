using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy = new Enemy();
    public Canvas gameOverCanvas;
    public static bool isMoving = false;
    public Animator enemyAnimator;
    float speed = 150;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
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
            Debug.Log("プレイヤーを倒しました");
            GameOver();
            playerController.blowUpSliderController.isUnderBlowUp = false;
        }
    }

    void GameOver() {
        // gameOverCanvas.gameObject.SetActive(true);
        Instantiate(gameOverCanvas, transform.position, transform.rotation);
    } 

    void GameStop(PlayerController playerController) {
        speed = 0;
        playerController.isDead = true;
    }

    public void KnockBack() {
        speed = 0;
        transform.position += Vector3.right * 50.0f;
        speed = 100;
    }
}
