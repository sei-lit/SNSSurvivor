using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWatch : Watch
{
    private static OldWatch oldWatch = new OldWatch();

    public static OldWatch Current => oldWatch;
    private OldWatch() {
        name = "古い時計";
        hp = 1;
        intelligence = 1;
    }
}
