using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEquipmentsPanelController : MonoBehaviour
{

    public GameObject changeToolPanel;
    public GameObject changeBodyPanel;
    public GameObject changeWatchPanel;
    public GameObject changeAccesoryPanel;
    public GameObject changeShoesPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseThisPanel() {
        this.gameObject.SetActive(false);
    }

    public void OnClickedChangeToolButton() {
        changeToolPanel.SetActive(true);
    }

    public void OnClickedChangeBodyButton() {
        changeBodyPanel.SetActive(true);
    }

    public void OnClickedChangeWatchButton() {
        changeWatchPanel.SetActive(true);
    }

    public void OnClickedChangeAccesoryButton() {
        changeAccesoryPanel.SetActive(true);
    }

    public void OnClickedChangeShoesButton() {
        changeShoesPanel.SetActive(true);
    }
}
