using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : Enemy
{
    public Pebble() {
        hp = 7;
        lv = 1;
        intelligence = 5;
        assets = 5;
        endurance = 5;
        exp = 10;
    }
}
