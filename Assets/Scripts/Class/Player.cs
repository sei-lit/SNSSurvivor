using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Chatacter
{
    int exp;
    float reputation;

    public Player() {
        hp = 10;
        lv = 100;
        intelligence = 10;
        assets = 5;
        endurance = 5;
    }
}
