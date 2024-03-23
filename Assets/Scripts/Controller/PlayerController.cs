using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Player player = Player.Current;
    public Animator playerAnimator;
    public Slider blowUpSlider;
    public BlowUpSliderController blowUpSliderController;
    public Text logText;
    BoxCollider2D enemyBoxCollider2D;
    [SerializeField] AudioSource playerAudioSource;
    [SerializeField] AudioSource playerLevelUpAudioSource;
    [SerializeField] AudioClip attackSE;
    [SerializeField] AudioClip hurtSE;
    [SerializeField] AudioClip levelUpSE;
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
        player.ResetDistance();
        blowUpSliderController = blowUpSlider.GetComponent<BlowUpSliderController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning) {
            player.AddDistance(0.1f * Time.deltaTime);
        }
    }

    public void ChangeMode() {
        isSNSMode = !isSNSMode;
        blowUpSliderController.isSNSMode = !blowUpSliderController.isSNSMode;
    }

    public void Run() {
        isRunning = true;
        playerAnimator.SetBool("isRunning", true);
        EnemyController.isMoving = true;
    }

    public void Stop() {
        isRunning = false;
        playerAnimator.SetBool("isRunning", false);
        if(!blowUpSliderController.IsUnderBlowUp()) {
            EnemyController.isMoving = false;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
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
            playerAudioSource.PlayOneShot(attackSE);
            Debug.Log("敵の残りHP: " + enemy.GetHp());
        } else {
            playerAudioSource.PlayOneShot(hurtSE);
        }
        if(enemy.IsDead()) {
            enemyBoxCollider2D = enemyController.GetComponent<BoxCollider2D>();
            enemyBoxCollider2D.enabled = false;
            enemyController.enemyAnimator.SetTrigger("Death");
            Destroy(other.gameObject, 1.0f);
            player.getExp(enemy.exp);
            if(player.CanLevelUp()) {
                Debug.Log("level up!!");
                playerLevelUpAudioSource.PlayOneShot(levelUpSE);
                player.LevelUp();
            }
            blowUpSliderController.JumpUpValue();
            if(IsDropItem()) {
                switch (DropItemType()) {
                    case "Tools":
                        DropTool(new Tool());
                        return;
                    case "Bodys":
                        DropBody(new Body());
                        return;
                    case "Accesorys":
                        DropAccesory(new Accesory());
                        return;
                    case "Watches":
                        DropWatch(new Watch());
                        return;
                    case "Shoeses":
                        DropShoes(new Shoes());
                        return;
                    default:
                        Debug.Log("Invailed value...");
                        return;
                }
            }
            Debug.Log("敵を倒しました");
        }
    }

    bool IsDropItem() {
        int randomNumber = new System.Random().Next(100);
        if(randomNumber < 100) {
            return true;
        } else {
            return false;
        }
    }

    String DropItemType() {
        int randomNumber = new System.Random().Next(5);
        String[] itemType = {"Tools", "Bodys", "Accesorys", "Watches", "Shoeses"};
        return itemType[randomNumber];
    }

    void DropTool(Tool tool) {
        int randomNumber = UnityEngine.Random.Range(0, tool.tools.Length);
        switch (tool.tools[randomNumber]) {
            case Tools.pencil:
                Pencil pencil = Pencil.Current;
                if(pencil.isAquired) {
                    Debug.Log("Pencil has already gotten");
                } else {
                    pencil.GetEquipment();
                    logText.text = "鉛筆を手に入れた！";
                    player.aquiredTool.Add(pencil);
                    Debug.Log("You got pencil!");
                }
                return;
            case Tools.book:
                Book book = Book.Current;
                if(book.isAquired) {
                    Debug.Log("Book has already gotten");
                } else {
                    book.GetEquipment();
                    logText.text = "本を手に入れた！";
                    player.aquiredTool.Add(book);
                    Debug.Log("You got book!");
                }
                return;
            case Tools.pen:
                Pen pen = Pen.Current;
                if(pen.isAquired) {
                    Debug.Log("Pen has already gotten");
                } else {
                    pen.GetEquipment();
                    logText.text = "ペンを手に入れた！";
                    player.aquiredTool.Add(pen);
                    Debug.Log("You got pen!");
                }
                return;
            case Tools.markerPen:
                MarkerPen markerPen = MarkerPen.Current;
                if(markerPen.isAquired) {
                    Debug.Log("MarkerPen has already gotten");
                } else {
                    markerPen.GetEquipment();
                    logText.text = "マーカーペンを手に入れた！";
                    player.aquiredTool.Add(markerPen);
                    Debug.Log("You got markerpen!");
                }
                return;
            default:
                Debug.Log("Invailed value...");
                return;
        }
    }

    void DropBody(Body body) {
        int randomNumber = UnityEngine.Random.Range(0, body.bodies.Length);
        switch (body.bodies[randomNumber]) {
            case Bodies.usedOutfit:
                UsedOutfit usedOutfit = UsedOutfit.Current;
                if(usedOutfit.isAquired) {
                    Debug.Log("UsedOutfit has already gotten");
                } else {
                    usedOutfit.GetEquipment();
                    logText.text = "古着を手に入れた！";
                    player.aquiredBody.Add(usedOutfit);
                    Debug.Log("You got usedOutfit!");
                }
                return;
            case Bodies.tShirt:
                TShirt tShirt = TShirt.Current;
                if(tShirt.isAquired) {
                    Debug.Log("TShirt has already gotten");
                } else {
                    tShirt.GetEquipment();
                    logText.text = "Tシャツを手に入れた！";
                    player.aquiredBody.Add(tShirt);
                    Debug.Log("You got tShirt!");
                }
                return;
            case Bodies.hoodie:
                Hoodie hoodie = Hoodie.Current;
                if(hoodie.isAquired) {
                    Debug.Log("Hoodie has already gotten");
                } else {
                    hoodie.GetEquipment();
                    logText.text = "パーカーを手に入れた！";
                    player.aquiredBody.Add(hoodie);
                    Debug.Log("You got hoodie!");
                }
                return;
            case Bodies.uniqlo:
                Uniqlo uniqlo = Uniqlo.Current;
                if(uniqlo.isAquired) {
                    Debug.Log("Uniqlo has already gotten");
                } else {
                    uniqlo.GetEquipment();
                    logText.text = "UNIQLOの服を手に入れた！";
                    player.aquiredBody.Add(uniqlo);
                    Debug.Log("You got uniqlo!");
                }
                return;
            default:
                Debug.Log("Invailed value...");
                return;
        }
    }

    void DropAccesory(Accesory accesory) {
        int randomNumber = UnityEngine.Random.Range(0, accesory.accesories.Length);
        switch (accesory.accesories[randomNumber]) {
            case Accesoryies.rustedRing:
                RustedRing rustedRing = RustedRing.Current;
                if(rustedRing.isAquired) {
                    Debug.Log("RustedRing has already gotten");
                } else {
                    rustedRing.GetEquipment();
                    logText.text = "錆びた指輪を手に入れた！";
                    player.aquiredAccesory.Add(rustedRing);
                    Debug.Log("You got rustedRing!");
                }
                return;
            case Accesoryies.silverRing:
                SilverRing silverRing = SilverRing.Current;
                if(silverRing.isAquired) {
                    Debug.Log("SilverRing has already gotten");
                } else {
                    silverRing.GetEquipment();
                    logText.text = "銀の指輪を手に入れた！";
                    player.aquiredAccesory.Add(silverRing);
                    Debug.Log("You got silverRing!");
                }
                return;
            case Accesoryies.goldRing:
                GoldRing goldRing = GoldRing.Current;
                if(goldRing.isAquired) {
                    Debug.Log("GoldRing has already gotten");
                } else {
                    goldRing.GetEquipment();
                    logText.text = "金の指輪を手に入れた！";
                    player.aquiredAccesory.Add(goldRing);
                    Debug.Log("You got GoldRing!");
                }
                return;
            case Accesoryies.oldNecklace:
                OldNecklace oldNecklace = OldNecklace.Current;
                if(oldNecklace.isAquired) {
                    Debug.Log("OldNecklace has already gotten");
                } else {
                    oldNecklace.GetEquipment();
                    logText.text = "古びたネックレスを手に入れた！";
                    player.aquiredAccesory.Add(oldNecklace);
                    Debug.Log("You got oldNecklace!");
                }
                return;
            case Accesoryies.silverChain:
                SilverChain silverChain = SilverChain.Current;
                if(silverChain.isAquired) {
                    Debug.Log("SilverChain has already gotten");
                } else {
                    silverChain.GetEquipment();
                    logText.text = "シルバーチェーンを手に入れた！";
                    player.aquiredAccesory.Add(silverChain);
                    Debug.Log("You got silverChain!");
                }
                return;
            default:
                Debug.Log("Invailed value...");
                return;
        }
    }

    void DropWatch(Watch watch) {
        int randomNumber = UnityEngine.Random.Range(0, watch.watches.Length);
        switch (watch.watches[randomNumber]) {
            case Watches.oldWatch:
                OldWatch oldWatch = OldWatch.Current;
                if(oldWatch.isAquired) {
                    Debug.Log("OldWatch has already gotten");
                } else {
                    oldWatch.GetEquipment();
                    logText.text = "古い時計を手に入れた！";
                    player.aquiredWatch.Add(oldWatch);
                    Debug.Log("You got oldWatch!");
                }
                return;
            case Watches.normalWatch:
                NormalWatch normalWatch = NormalWatch.Current;
                if(normalWatch.isAquired) {
                    Debug.Log("NormalWatch has already gotten");
                } else {
                    normalWatch.GetEquipment();
                    logText.text = "普通の時計を手に入れた！";
                    player.aquiredWatch.Add(normalWatch);
                    Debug.Log("You got normalWatch!");
                }
                return;
            case Watches.gShock:
                GShock gShock = GShock.Current;
                if(gShock.isAquired) {
                    Debug.Log("GShock has already gotten");
                } else {
                    gShock.GetEquipment();
                    logText.text = "G-SHOCKを手に入れた！";
                    player.aquiredWatch.Add(gShock);
                    Debug.Log("You got gShock!");
                }
                return;
            case Watches.rolex:
                Rolex rolex = Rolex.Current;
                if(rolex.isAquired) {
                    Debug.Log("Rolex has already gotten");
                } else {
                    rolex.GetEquipment();
                    logText.text = "ロレックスを手に入れた！";
                    player.aquiredWatch.Add(rolex);
                    Debug.Log("You got rolex!");
                }
                return;
            default:
                Debug.Log("Invailed value...");
                return;
        }
    }

    void DropShoes(Shoes shoes) {
        int randomNumber = UnityEngine.Random.Range(0, shoes.shoeses.Length);
        switch (shoes.shoeses[randomNumber]) {
            case Shoeses.sneakers:
                Sneakers sneakers = Sneakers.Current;
                if(sneakers.isAquired) {
                    Debug.Log("Sneakers has already gotten");
                } else {
                    sneakers.GetEquipment();
                    logText.text = "ただのスニーカーを手に入れた！";
                    player.aquiredShoes.Add(sneakers);
                    Debug.Log("You got sneakers!");
                }
                return;
            case Shoeses.boots:
                Boots boots = Boots.Current;
                if(boots.isAquired) {
                    Debug.Log("Boots has already gotten");
                } else {
                    boots.GetEquipment();
                    logText.text = "ブーツを手に入れた！";
                    player.aquiredShoes.Add(boots);
                    Debug.Log("You got boots!");
                }
                return;
            default:
                Debug.Log("Invailed value...");
                return;
        }
    }
}
