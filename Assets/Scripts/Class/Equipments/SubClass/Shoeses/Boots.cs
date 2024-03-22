using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : Shoes
{
    private static Boots boots = new Boots();

    public static Boots Current => boots;
    private Boots() {
        assets = 1;
        endurance = 1;
    }
}
