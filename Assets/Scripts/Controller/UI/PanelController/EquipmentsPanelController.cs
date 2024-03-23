using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentsPanelController : MonoBehaviour
{
    protected Player player = Player.Current;
    public Text toolText;
    public Text bodyText;
    public Text accesoryText;
    public Text watchText;
    public Text shoesText;
    public GameObject changeEquipmentsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentAllEquipments();
    }

    public void OpenChangeEquipmentsPanel() {
        changeEquipmentsPanel.SetActive(true);
    }

    public void CloseThisPanel() {
        this.gameObject.SetActive(false);
    }

    public void UpdateCurrentAllEquipments() {
        UpdateCurrentTool();
        UpdateCurrentBody();
        UpdateCurrentAccesory();
        UpdateCurrentWatch();
        UpdateCurrentshoes();
    }

    public void UpdateCurrentTool() {
        if (player.tool != null) {
            toolText.text = player.tool.name;
        }
    }

    public void UpdateCurrentBody() {
        if (player.body != null) {
            bodyText.text = player.body.name;
        }
    }

    public void UpdateCurrentAccesory() {
        if (player.accesory != null) {
            accesoryText.text = player.accesory.name;
        }
    }

    public void UpdateCurrentWatch() {
        if (player.watch != null) {
            watchText.text = player.watch.name;
        }
    }

    public void UpdateCurrentshoes() {
        if (player.shoes != null) {
            shoesText.text = player.shoes.name;
        }
    }
}
