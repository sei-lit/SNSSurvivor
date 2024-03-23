using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedOutfit : Body
{
    private static UsedOutfit usedOutfit = new UsedOutfit();

    public static UsedOutfit Current => usedOutfit;
    private UsedOutfit() {
        name = "古着";
        hp = 3;
        endurance = 1;
    }
}
