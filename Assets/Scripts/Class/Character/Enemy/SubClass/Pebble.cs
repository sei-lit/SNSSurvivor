using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : Enemy
{
    public Pebble() {
        hp = 35;
        lv = 5;
        intelligence = 25;
        assets = 10;
        endurance = 10;
        exp = 10;
    }
}
