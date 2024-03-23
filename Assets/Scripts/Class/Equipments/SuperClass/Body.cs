using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : Equipment
{
    public Bodies[] bodies = {Bodies.usedOutfit, Bodies.tShirt, Bodies.hoodie, Bodies.uniqlo};
    public float? endurance;
    public int? hp;
    public string name;
}
