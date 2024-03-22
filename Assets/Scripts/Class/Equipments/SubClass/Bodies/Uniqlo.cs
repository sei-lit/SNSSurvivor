using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uniqlo : Body
{
    private static Uniqlo uniqlo = new Uniqlo();

    public static Uniqlo Current => uniqlo;
    private Uniqlo() {
        hp = 3;
        endurance = 1;
    }
}
