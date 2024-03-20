using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Chatacter
{

    public Enemy() {
        hp = 7;
        lv = 1;
        intelligence = 5;
        assets = 5;
        endurance = 5;
        exp = 10;
    }

    public Enemy CreateEnemy(int number) {
        return null;
    }
}
