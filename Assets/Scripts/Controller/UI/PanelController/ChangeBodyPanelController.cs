using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBodyPanelController : EquipmentsPanelController
{
    public GameObject equipmentPrefab;
    GameObject content;
    void Awake() {
        content = GameObject.Find ("Content");
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(Body body in player.aquiredBody) {
            GameObject prefabs = Instantiate(equipmentPrefab, content.transform);
            Button bodyButton = prefabs.GetComponent<Button>();
            Text bodyButtonText = bodyButton.GetComponentInChildren<Text>();
            bodyButtonText.text = body.name + ": 体力 +" + body.hp + ", 忍耐力 +" + body.endurance;
            bodyButton.onClick.AddListener(() => OnClickedBodyButton(body.name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedBodyButton(string bodyName) {
        Debug.Log(bodyName + "が選択された");
        foreach(Body body in player.aquiredBody) {
            if(bodyName == body.name) {
                player.body = body;
                Debug.Log(body.name + "を装備");
            }
        }
        UpdateCurrentBody();
        player.UpdateStatus();
    }
}
