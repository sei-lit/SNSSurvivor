using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Player : Chatacter, ILevelUpable
{
    public int maxHp;
    public int finalHp;
    public float finalIntelligence;
    public float finalAssets;
    public float finalEndurance;
    public float reputation;
    public int statusPoint = 0;
    public int expForNextLv = 10;
    float distance = 0;
    public Tool tool = Pencil.Current;
    public Body body = UsedOutfit.Current;
    public Accesory accesory;
    public Watch watch;
    public Shoes shoes = Sneakers.Current;
    public List<Tool> aquiredTool = new List<Tool>();
    public List<Body> aquiredBody = new List<Body>();
    public List<Watch> aquiredWatch = new List<Watch>();
    public List<Accesory> aquiredAccesory = new List<Accesory>();
    public List<Shoes> aquiredShoes = new List<Shoes>();
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
        getInitialEquipments();
        UpdateStatus();
    }

    public void getCurrentStatus() {
        hp = maxHp;
    }

    private void getCurrentEquipments() {
        
    }

    private void getInitialEquipments() {
        tool.GetEquipment();
        body.GetEquipment();
        shoes.GetEquipment();
        aquiredTool.Add(tool);
        aquiredBody.Add(body);
        aquiredShoes.Add(shoes);
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
    }

    public void LevelUp() {
        exp -= expForNextLv;
        lv++;
        statusPoint += 5;
        expForNextLv = CalculateExpForNextLv(lv);
    }

    public bool CanLevelUp() {
        if(exp >= expForNextLv) {
            return true;
        } else {
            return false;
        }
    }
    public int CalculateExpForNextLv(int currentLv) {
        return (int)Math.Pow((double)currentLv/(double)50, (double)2) + 20;
    }

    public void AddDistance(float addedDistance) {
        distance += addedDistance;
    }

    public float GetDistance() {
        return distance;
    }

    public void ResetDistance() {
        distance = 0.0f;
    }

    public void PlusHp() {
        if(statusPoint > 0) {
            maxHp++;
            statusPoint--;
        }
    }
    public void MinusHp() {
        if(hp > 1) {
            maxHp--;
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