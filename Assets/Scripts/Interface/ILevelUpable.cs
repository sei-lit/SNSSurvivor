using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelUpable
{
    void getExp(int gainExp);
    void LevelUp();
    int CalculateExpForNextLv(int currentLv);
    void PlusHp();
    void MinusHp();
    void PlusIntelligence();
    void MinusIntelligence();
    void PlusAssets();
    void MinusAssets();
    void PlusEndurance();
    void MinusEndurance();
    void PlusReputation();
    void MinusReputation();
}
