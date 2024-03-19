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
    public bool isSNSMode = false;
    public bool isAttacking;
    public bool isDead = false;

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
        
    }

    public void ChangeMode() {
        isSNSMode = !isSNSMode;
    }

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
            if(isSNSMode) {
                enemy.AddDamage(enemy.CalculateDamage(player.finalIntelligence * (1 + 0.01f * player.reputation), player.finalAssets));
            } else {
                enemy.AddDamage(enemy.CalculateDamage(player.finalIntelligence, player.finalAssets));
            }
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
