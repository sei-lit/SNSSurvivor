using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sneakers : Shoes
{
    private static Sneakers sneakers = new Sneakers();

    public static Sneakers Current => sneakers;
    private Sneakers() {
        name = "ただのスニーカー";
        assets = 1;
        endurance = 1;
    }
}
