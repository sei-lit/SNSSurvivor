using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Equipment
{
    public Tools[] tools = {Tools.pencil, Tools.pen, Tools.markerPen, Tools.book};
    public float? intelligence;
    public float? assets;
    public string name;
}
