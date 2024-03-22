using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TShirt : Body
{
    private static TShirt tShirt = new TShirt();

    public static TShirt Current => tShirt;
    private TShirt() {
        hp = 3;
        endurance = 1;
    }
}
