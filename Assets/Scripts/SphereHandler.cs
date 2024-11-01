using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SphereHandler : MonoBehaviour
{
    public Slider radiusSlider;
    public TextMeshProUGUI volumeDisplay, surfaceAreaDisplay;

    private float radius = 1;
    private float volume, surfaceArea;

    void Start()
    {
        radiusSlider.onValueChanged.AddListener((value) => { UpdateValues(value); });
        UpdateDimensions();
        UpdateUI();
    }

    void UpdateDimensions()
    {
        volume = 4f/3f * Mathf.PI * Mathf.Pow(radius, 3);
        surfaceArea = 4 * Mathf.PI * Mathf.Pow(radius, 2);

        transform.localScale = new Vector3(radius, radius, radius);
    }

    void UpdateUI()
    {
        string volumeText = volume.ToString("0.00"),
            surfaceAreaText = surfaceArea.ToString("0.00");

        string radiusText = radius.ToString("0.00");

        volumeDisplay.text = $"Kuglens volumen: V = 4 / 3 * π * r^3\n3 / 4 * π * {radiusText}^3 = {volumeText}";

        surfaceAreaDisplay.text = $"Kuglens overfladeareal:\nA = 4 * π * r^2\n4 * π * {radiusText}^2 = {surfaceAreaText}";
    }

    void UpdateValues(float value)
    {
        radius = value;

        UpdateDimensions();
        UpdateUI();
    }
}
