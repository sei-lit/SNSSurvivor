using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : Tool
{
    private static Pen pen = new Pen();

    public static Pen Current => pen;
    private Pen() {
        assets = 1;
        intelligence = 1;
    }
}
