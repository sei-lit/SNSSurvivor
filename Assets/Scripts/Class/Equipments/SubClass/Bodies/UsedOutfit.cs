using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsedOutfit : Body
{
    private static UsedOutfit usedOutfit = new UsedOutfit();

    public static UsedOutfit Current => usedOutfit;
    private UsedOutfit() {
        hp = 3;
        endurance = 1;
        isAquired = true;
    }
}
