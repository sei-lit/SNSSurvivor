using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chatacter : IDamagable, IAttack
{
    public int hp;
    public int lv;
    public float intelligence;
    public float assets;
    public float endurance;

    public int exp;

    //IDamagable
    public int CalculateDamage(float intelligence, float assets) {
        return (int)(intelligence * assets / endurance);
    }
    public void AddDamage(int damage)
    {
        Debug.Log("Damage: " + damage.ToString());
        hp -= damage;
    }
    public bool IsDead() {
        if (hp <= 0) {
            return true;
        } else {
            return false;
        }
    }

    public int GetHp() {
        return hp;
    }

    //IAttack
    public double CalculateGetAttackedPercentage(int eLv) {
        Debug.Log("CalculateGetAttackedPercentage");
        int lvDiff = lv - eLv;
        if(lvDiff >= 0) {
            return Math.Pow(2, ((double)-lvDiff/(double)20)) * 50;
        } else {
            return Math.Pow(2, ((double)lvDiff/(double)20)) * -50 + 100;
        }
    }

    public bool GetAttacked(double percentage) {
        Debug.Log("GetAttacked");
        if((int)percentage > new System.Random().Next(100)) {
            return true;
        } else {
            return false;
        }
    }
}
