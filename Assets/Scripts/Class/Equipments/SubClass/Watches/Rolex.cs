using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolex : Watch
{
    private static Rolex rolex = new Rolex();

    public static Rolex Current => rolex;
    private Rolex() {
        hp = 1;
        intelligence = 1;
    }
}
