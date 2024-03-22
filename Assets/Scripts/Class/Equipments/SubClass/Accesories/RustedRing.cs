using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustedRing : Accesory
{
    private static RustedRing rustedRing = new RustedRing();

    public static RustedRing Current => rustedRing;
    private RustedRing() {
        hp = 3;
        intelligence = 3;
        assets = 5;
        endurance = 1;
    }
}
