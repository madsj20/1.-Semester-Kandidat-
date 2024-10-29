using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CylinderHandler : MonoBehaviour
{
    public Slider radiusSlider, heightSlider;
    public TextMeshProUGUI volumeDisplay, surfaceAreaDisplay;

    private float radius = 0.5f, height = 1;
    private float volume, surfaceArea;

    void Start()
    {
        radiusSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "radius"); });
        heightSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "height"); });
        UpdateDimensions();
        UpdateUI();
    }

    void UpdateDimensions()
    {
        volume = height * Mathf.PI * Mathf.Pow(radius, 2f);
        surfaceArea = 2 * Mathf.PI * radius * (height + radius);

        transform.localScale = new Vector3(radius * 2, height, radius * 2);
    }

    void UpdateUI()
    {
        string volumeText = volume.ToString("0.00"),
            surfaceAreaText = surfaceArea.ToString("0.00");

        string radiusText = radius.ToString("0.00"),
            heightText = height.ToString("0.00");

        volumeDisplay.text = $"Cylenderets volumen:\nV = h * π * r^2\n{heightText} * π * {radiusText}^2 = {volumeText}";

        surfaceAreaDisplay.text = $"Cylenderets overfladeareal:\nA = 2 * π * r * (h + r)\n2 * π * {radiusText} * ({heightText} + {radiusText}) = {surfaceAreaText}";
    }

    void UpdateValues(float value, string dimension)
    {
        switch (dimension)
        {
            case "radius":
                radius = value / 2;
                break;
            case "height":
                height = value;
                break;
        }

        UpdateDimensions();
        UpdateUI();
    }
}
