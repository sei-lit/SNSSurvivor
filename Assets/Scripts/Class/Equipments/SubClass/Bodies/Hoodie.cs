using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoodie : Body
{
    private static Hoodie hoodie = new Hoodie();

    public static Hoodie Current => hoodie;
    private Hoodie() {
        hp = 3;
        endurance = 1;
    }
}
