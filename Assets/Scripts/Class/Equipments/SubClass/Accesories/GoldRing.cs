using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldRing : Accesory
{
    private static GoldRing goldRing = new GoldRing();

    public static GoldRing Current => goldRing;
    private GoldRing() {
        name = "金の指輪";
        hp = 3;
        intelligence = 3;
        assets = 5;
        endurance = 1;
    }
}
