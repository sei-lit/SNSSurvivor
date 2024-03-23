using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWatch : Watch
{
    private static NormalWatch normalWatch = new NormalWatch();

    public static NormalWatch Current => normalWatch;
    private NormalWatch() {
        name = "普通の時計";
        hp = 1;
        intelligence = 1;
    }
}
