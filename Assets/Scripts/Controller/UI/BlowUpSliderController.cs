using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlowUpSliderController : MonoBehaviour
{

    Slider blowUpSlider;
    public bool isSNSMode = false;
    float blowUpValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        blowUpSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSNSMode) {
            blowUpValue += 0.02f * Time.deltaTime;
            blowUpSlider.value = blowUpValue;
        } else {
            blowUpValue -= 0.0075f * Time.deltaTime;
            blowUpSlider.value = blowUpValue;
        }
    }

    public void JumpUpValue() {
        blowUpValue += 0.1f;
        blowUpSlider.value = blowUpValue;
    }
}
