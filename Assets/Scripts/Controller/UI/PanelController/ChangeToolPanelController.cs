using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChangeToolPanelController : EquipmentsPanelController
{
    public GameObject equipmentPrefab;
    GameObject content;
    void Awake() {
        content = GameObject.Find ("Content");
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(Tool tool in player.aquiredTool) {
            GameObject prefabs = Instantiate(equipmentPrefab, content.transform);
            Button toolButton = prefabs.GetComponent<Button>();
            Text toolButtonText = toolButton.GetComponentInChildren<Text>();
            toolButtonText.text = tool.name + ": 知力 +" + tool.intelligence + ", 財力 +" + tool.assets;
            toolButton.onClick.AddListener(() => OnClickedToolButton(tool.name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickedToolButton(string toolName) {
        Debug.Log(toolName + "が選択された");
        foreach(Tool tool in player.aquiredTool) {
            if(toolName == tool.name) {
                player.tool = tool;
                Debug.Log(tool.name + "を装備");
            }
        }
        UpdateCurrentTool();
        player.UpdateStatus();
    }
}
