using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencil : Tool
{
    private static Pencil pencil = new Pencil();

    public static Pencil Current => pencil;
    private Pencil() {
        assets = 1;
        intelligence = 1;
    }
}
