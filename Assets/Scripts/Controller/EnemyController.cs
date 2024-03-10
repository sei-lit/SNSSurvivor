using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Enemy enemy = new Enemy();
    public static bool isMoving = false;
    public Animator enemyAnimator;
    float speed = 100;
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
            playerController.playerAnimator.SetTrigger("isDead");
            // Destroy(other.gameObject, 1.0f);
            Debug.Log("プレイヤーを倒しました");
        }
    }

    public void KnockBack() {
        speed = 0;
        Debug.Log("this.transform.position + Vector3.right * 30: " + (this.transform.position + Vector3.right * 5.0f));
        transform.position += Vector3.right * 50.0f;
        speed = 100;
    }
}
