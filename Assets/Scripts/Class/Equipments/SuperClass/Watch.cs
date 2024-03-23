using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : Equipment
{
    public Watches[] watches = {Watches.oldWatch, Watches.normalWatch, Watches.gShock, Watches.rolex};
    public int? hp;
    public float? intelligence;
    public string name;
}
