using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWatchPanelController : EquipmentsPanelController
{
    public GameObject equipmentPrefab;
    GameObject content;
    void Awake() {
        content = GameObject.Find ("Content");
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(Watch watch in player.aquiredWatch) {
            GameObject prefabs = Instantiate(equipmentPrefab, content.transform);
            Button watchButton = prefabs.GetComponent<Button>();
            Text watchButtonText = watchButton.GetComponentInChildren<Text>();
            watchButtonText.text = watch.name + ": 体力 +" + watch.hp + ", 知力 +" + watch.intelligence;
            watchButton.onClick.AddListener(() => OnClickedWatchButton(watch.name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedWatchButton(string watchName) {
        Debug.Log(watchName + "が選択された");
        foreach(Watch watch in player.aquiredWatch) {
            if(watchName == watch.name) {
                player.watch = watch;
                Debug.Log(watch.name + "を装備");
            }
        }
        UpdateCurrentWatch();
        player.UpdateStatus();
    }
}
