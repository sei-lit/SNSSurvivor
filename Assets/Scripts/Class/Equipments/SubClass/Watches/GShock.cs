using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GShock : Watch
{
    private static GShock gShock = new GShock();

    public static GShock Current => gShock;
    private GShock() {
        name = "G-SHOCK";
        hp = 1;
        intelligence = 1;
    }
}
