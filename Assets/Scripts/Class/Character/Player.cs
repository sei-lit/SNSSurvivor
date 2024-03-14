using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Player : Chatacter, ILevelUpable
{
    int maxHp;
    public int finalHp;
    public float finalIntelligence;
    public float finalAssets;
    public float finalEndurance;
    public float reputation;
    public int statusPoint = 0;
    public int expForNextLv = 10;
    public Tool tool = Pencil.Current;
    public Body body = UsedOutfit.Current;
    public Accesory accesory;
    public Watch watch;
    public Shoes shoes = Sneakers.Current;

    private static Player player = new Player();

    public static Player Current => player;

    private Player() {
        lv = 1;
        maxHp = 10;
        intelligence = 5;
        assets = 5;
        endurance = 5;
        reputation = 1;
        getCurrentStatus();
        getCurrentEquipments();
        UpdateStatus();
    }

    public void getCurrentStatus() {
        hp = maxHp;
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

    //ILevelUpable
    public void getExp(int gainExp) {
        exp += gainExp;
        LevelUp();
    }

    public void LevelUp() {
        if(exp >= expForNextLv) {
            exp -= expForNextLv;
            lv++;
            statusPoint += 5;
            expForNextLv = CalculateExpForNextLv(lv);
        }
    }
    public int CalculateExpForNextLv(int currentLv) {
        return (int)Math.Pow((double)currentLv/(double)50, (double)2) + 10;
    }

    public void PlusHp() {
        if(statusPoint > 0) {
            hp++;
            statusPoint--;
        }
    }
    public void MinusHp() {
        if(hp > 1) {
            hp--;
            statusPoint++;
        }
    }
    public void PlusIntelligence() {
        if(statusPoint > 0) {
            intelligence++;
            statusPoint--;
        }
    }
    public void MinusIntelligence() {
        if(intelligence > 1) {
            intelligence--;
            statusPoint++;
        }
    }
    public void PlusAssets() {
        if(statusPoint > 0) {
            assets++;
            statusPoint--;
        }
    }
    public void MinusAssets() {
        if(assets > 1) {
            assets--;
            statusPoint++;
        }
    }
    public void PlusEndurance() {
        if(statusPoint > 0) {
            endurance++;
            statusPoint--;
        }
    }
    public void MinusEndurance() {
        if(endurance > 1) {
            endurance--;
            statusPoint++;
        }
    }
    public void PlusReputation() {
        if(statusPoint > 0) {
            reputation++;
            statusPoint--;
        }
    }
    public void MinusReputation() {
        if(reputation > 1) {
            reputation--;
            statusPoint++;
        }
    }
}
