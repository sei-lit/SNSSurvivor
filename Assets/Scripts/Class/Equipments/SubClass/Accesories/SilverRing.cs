using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverRing : Accesory
{
    private static SilverRing silverRing = new SilverRing();

    public static SilverRing Current => silverRing;
    private SilverRing() {
        hp = 3;
        intelligence = 3;
        assets = 5;
        endurance = 1;
    }
}
