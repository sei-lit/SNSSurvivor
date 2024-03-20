using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentsPanelController : MonoBehaviour
{
    public GameObject changeEquipmentsPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenChangeEquipmentsPanel() {
        changeEquipmentsPanel.SetActive(true);
    }
}
