using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlowUpSliderController : MonoBehaviour
{

    Slider blowUpSlider;

    public GameObject EnemyCreator;
    EnemyCreatorController enemyCreatorController;
    public bool isSNSMode = false;
    float blowUpValue = 0;
    public bool isUnderBlowUp = false;
    // Start is called before the first frame update
    void Start()
    {
        blowUpSlider = GetComponent<Slider>();
        enemyCreatorController = EnemyCreator.GetComponent<EnemyCreatorController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSNSMode) {
            blowUpValue += 0.02f * Time.deltaTime;
            MaxSliderValue();
            blowUpSlider.value = blowUpValue;
        } else if (!isSNSMode && blowUpValue > 0) {
            blowUpValue -= 0.0075f * Time.deltaTime;
            blowUpSlider.value = blowUpValue;
        } else {
            blowUpValue = 0;
        }
        isUnderBlowUp = GetBlowUp();
    }

    public void JumpUpValue() {
        if(isSNSMode) {
            blowUpValue += 0.1f;
            MaxSliderValue();
            blowUpSlider.value = blowUpValue;
        }
    }

    public bool GetBlowUp() {
        if (blowUpValue >= 1.0f) {
            return true;
        } else if (isUnderBlowUp && blowUpValue >= 0.25f) {
            return true;
        } else {
            return false;
        }
    }

    void MaxSliderValue() {
        if (blowUpValue >= 1.0f) {
            blowUpValue = 1.0f;
        }
    }

    public bool IsUnderBlowUp(){
        if (isUnderBlowUp && blowUpValue >= 0.25f) {
            return true;
        } else {
            return false;
        }
    }
}
