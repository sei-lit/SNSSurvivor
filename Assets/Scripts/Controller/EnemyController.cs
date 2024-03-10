using System.Collections;
using System.Collections.Generic;
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
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
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
            player.AddDamage(player.CalculateDamage(enemy.intelligence, enemy.assets));
            Debug.Log("プレイヤーの残りHP: " + player.GetHp());
        }
        if(player.IsDead()) {
            Destroy(other.gameObject, 2.0f);
            Debug.Log("プレイヤーを倒しました");
        }
    }
}
