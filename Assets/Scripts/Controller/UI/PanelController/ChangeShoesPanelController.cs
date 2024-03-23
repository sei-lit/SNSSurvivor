using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeShoesPanelController : EquipmentsPanelController
{
    public GameObject equipmentPrefab;
    GameObject content;
    void Awake() {
        content = GameObject.Find ("Content");
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(Shoes shoes in player.aquiredShoes) {
            GameObject prefabs = Instantiate(equipmentPrefab, content.transform);
            Button shoesButton = prefabs.GetComponent<Button>();
            Text shoesButtonText = shoesButton.GetComponentInChildren<Text>();
            shoesButtonText.text = shoes.name + ": 財力 +" + shoes.assets + ", 忍耐力 +" + shoes.endurance;
            shoesButton.onClick.AddListener(() => OnClickedShoesButton(shoes.name));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickedShoesButton(string shoesName) {
        Debug.Log(shoesName + "が選択された");
        foreach(Shoes shoes in player.aquiredShoes) {
            if(shoesName == shoes.name) {
                player.shoes = shoes;
                Debug.Log(shoes.name + "を装備");
            }
        }
        UpdateCurrentshoes();
        player.UpdateStatus();
    }
}
