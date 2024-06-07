using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sensSlider;
    [SerializeField] TextMeshProUGUI volumeText;
    [SerializeField] TextMeshProUGUI sensText;
    public PlayerCam cam;

    // Update is called once per frame
    void Update()
    {
        volumeText.text = (volumeSlider.value * 10).ToString("0");
        sensText.text = sensSlider.value.ToString("0");
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void ChangeSens()
    {
        cam.sensX = sensSlider.value;
        cam.sensY = sensSlider.value;
    }
}
