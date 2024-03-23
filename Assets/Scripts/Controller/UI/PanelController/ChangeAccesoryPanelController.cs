using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAccesoryPanelController : EquipmentsPanelController
{
    public GameObject equipmentPrefab;
    GameObject content;
    void Awake() {
        content = GameObject.Find ("Content");
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(Accesory accesory in player.aquiredAccesory) {
            GameObject prefabs = Instantiate(equipmentPrefab, content.transform);
            Button accesoryButton = prefabs.GetComponent<Button>();
            Text accesoryButtonText = accesoryButton.GetComponentInChildren<Text>();
            accesoryButtonText.text = accesory.name + ": 全ステータスUP";
            accesoryButton.onClick.AddListener(() => OnClickedAccesoryButton(accesory.name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedAccesoryButton(string accesoryName) {
        Debug.Log(accesoryName + "が選択された");
        foreach(Accesory accesory in player.aquiredAccesory) {
            if(accesoryName == accesory.name) {
                player.accesory = accesory;
                Debug.Log(accesory.name + "を装備");
            }
        }
        UpdateCurrentAccesory();
        player.UpdateStatus();
    }
}
