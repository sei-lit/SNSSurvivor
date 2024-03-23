using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uniqlo : Body
{
    private static Uniqlo uniqlo = new Uniqlo();

    public static Uniqlo Current => uniqlo;
    private Uniqlo() {
        name = "UNIQLOの服";
        hp = 3;
        endurance = 1;
    }
}
