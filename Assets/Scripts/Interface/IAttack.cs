using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    bool GetAttacked(double percentage);
    double CalculateGetAttackedPercentage(int eLv);
}
