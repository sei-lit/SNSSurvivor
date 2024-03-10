using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment
{
    public bool isAquired = false;
    public bool isEquiped = false;

    public void GetEquipment() {
        isAquired = true;
    }

    public void Equip() {
        if(isAquired) {
            isEquiped = true;
        }
    }

    public void TakeOff() {
        if(isAquired) {
            isEquiped = false;
        }
    }
    
}
