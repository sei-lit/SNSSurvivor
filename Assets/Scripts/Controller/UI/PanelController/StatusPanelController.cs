using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanelController : MonoBehaviour
{
    Player player = Player.Current;
    public Text lvText;
    public Text hpText;
    public Text intelligenceText;
    public Text assetsText;
    public Text enduranceText;
    public Text reputationText;
    public Text statusPointText;
    public GameObject levelUpPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetStatus();
    }

    public void GetStatus() {
        lvText.text = "Lv. " + player.lv.ToString();
        hpText.text = player.finalHp.ToString();
        intelligenceText.text = player.finalIntelligence.ToString();
        assetsText.text = player.finalAssets.ToString();
        enduranceText.text = player.finalEndurance.ToString();
        reputationText.text = player.reputation.ToString();
        statusPointText.text = player.statusPoint.ToString();
    }

    public void OpenLevelUpPanel() {
        levelUpPanel.SetActive(true);
    }
}
