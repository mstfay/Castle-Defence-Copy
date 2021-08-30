using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    [SerializeField] Slider arrowSlider;
    [SerializeField] Slider healthSlider;
    PlayerStats stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = PlayerStats.instance;
        arrowSlider.value = 1f;
        healthSlider.value = 1f;
    }
    public void SliderValue(int maxxValue, int currentValue)
    {
        int sliderValue = maxxValue - currentValue;
        arrowSlider.maxValue = maxxValue;
        arrowSlider.value = sliderValue;
    }

    public void HealtValue(int maxHealtValue, int currentHealt)
    {        
        maxHealtValue = stats.maxHealt;
        int slider2Value = maxHealtValue - currentHealt;
        healthSlider.maxValue = maxHealtValue;
        healthSlider.value = slider2Value;
    }
}
