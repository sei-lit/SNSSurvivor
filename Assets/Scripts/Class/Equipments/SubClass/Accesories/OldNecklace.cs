using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldNecklace : Accesory
{
    private static OldNecklace oldNecklace = new OldNecklace();

    public static OldNecklace Current => oldNecklace;
    private OldNecklace() {
        name = "古いネックレス";
        hp = 3;
        intelligence = 3;
        assets = 5;
        endurance = 1;
    }
}
