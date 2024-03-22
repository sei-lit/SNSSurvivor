using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverChain : Accesory
{
    private static SilverChain silverChain = new SilverChain();

    public static SilverChain Current => silverChain;
    private SilverChain() {
        hp = 3;
        intelligence = 3;
        assets = 5;
        endurance = 1;
    }
}
