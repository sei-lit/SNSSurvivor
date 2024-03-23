using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanelController : MonoBehaviour
{
    Player player = Player.Current;
    public Text hpText;
    public Text intelligenceText;
    public Text assetsText;
    public Text enduranceText;
    public Text reputationText;
    public Text statusPointText;
    // Start is called before the first frame update
    void Start()
    {
        GetStatus();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetStatus() {
        hpText.text = player.maxHp.ToString();
        intelligenceText.text = player.intelligence.ToString();
        assetsText.text = player.assets.ToString();
        enduranceText.text = player.endurance.ToString();
        reputationText.text = player.reputation.ToString();
        statusPointText.text = "残りの伸びしろ: " + player.statusPoint.ToString();
    }

    public void CloseThisPanel() {
        player.UpdateStatus();
        this.gameObject.SetActive(false);
    }

    public void TappedPlusHp() {
        player.PlusHp();
        GetStatus();
    }

    public void TappedMinusHp() {
        player.MinusHp();
        GetStatus();
    }

    public void TappedPlusIntelligence() {
        player.PlusIntelligence();
        GetStatus();
    }

    public void TappedMinusIntelligence() {
        player.MinusIntelligence();
        GetStatus();
    }

    public void TappedPlusAssets() {
        player.PlusAssets();
        GetStatus();
    }

    public void TappedMinusAssets() {
        player.MinusAssets();
        GetStatus();
    }

    public void TappedPlusEndurance() {
        player.PlusEndurance();
        GetStatus();
    }

    public void TappedMinusEndurance() {
        player.MinusEndurance();
        GetStatus();
    }

    public void TappedPlusReputation() {
        player.PlusReputation();
        GetStatus();
    }

    public void TappedMinusReputation() {
        player.MinusReputation();
        GetStatus();
    }
}
