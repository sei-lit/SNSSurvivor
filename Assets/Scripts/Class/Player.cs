using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : Chatacter
{
    public int finalHp;
    public float finalIntelligence;
    public float finalAssets;
    public float finalEndurance;
    public float reputation;
    public int statusPoint;
    public Tool tool = Pencil.Current;
    public Body body = UsedOutfit.Current;
    public Accesory accesory;
    public Watch watch;
    public Shoes shoes = Sneakers.Current;

    private static Player player = new Player();

    public static Player Current => player;

    private Player() {
        lv = 1;
        hp = 10;
        intelligence = 5;
        assets = 5;
        endurance = 5;
        reputation = 0;
        getCurrentStatus();
        getCurrentEquipments();
        UpdateStatus();
    }

    private void getCurrentStatus() {

    }

    private void getCurrentEquipments() {
        
    }

    public void UpdateStatus() {
        finalHp = hp + body.hp ?? 0 + accesory.hp ?? 0 + watch.hp ?? 0;
        finalIntelligence = intelligence + tool.intelligence ?? 0 + accesory.intelligence ?? 0 + watch.intelligence ?? 0;
        finalAssets = assets + tool.assets ?? 0 + accesory.assets ?? 0 + shoes.assets ?? 0;
        finalEndurance = endurance + body.endurance ?? 0 + accesory.endurance ?? 0 + shoes.endurance ?? 0;
        Debug.Log("finalHp: " + finalHp);
    }
}
