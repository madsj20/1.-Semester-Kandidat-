using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CylinderHandler : MonoBehaviour
{
    public float buffer = 0;

    public GameObject cylinder, worldCanvas;

    public Slider radiusSlider, heightSlider;
    public TextMeshProUGUI volumeDisplay, surfaceAreaDisplay;
    public TextMeshProUGUI radiusText, heightText;

    private float radius = 1, height = 2;
    private float volume, surfaceArea;

    void Start()
    {
        SetupWorldCanvas();
        SetupSliders();
        UpdateDimensions();
        UpdateUI();
    }

    void SetupWorldCanvas()
    {
        worldCanvas.GetComponent<Canvas>().worldCamera = Camera.main;
        worldCanvas.GetComponent<RectTransform>().sizeDelta = cylinder.transform.localScale + Vector3.one * 0.4f;
        worldCanvas.transform.rotation = cylinder.transform.rotation;
    }

    void SetupSliders()
    {
        radiusSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "radius"); });
        heightSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "height"); });
    }

    void UpdateDimensions()
    {
        volume = height * Mathf.PI * Mathf.Pow(radius, 2f);
        surfaceArea = 2 * Mathf.PI * radius * (height + radius);

        cylinder.transform.localScale = new Vector3(radius, height / 2, radius);
        cylinder.transform.position = new Vector3(cylinder.transform.position.x, cylinder.transform.localScale.y -1, cylinder.transform.position.z);

        radiusText.transform.position = new Vector3(radius / 4, height + buffer - 1, 0);
        heightText.transform.position = new Vector3(radius / 2 + buffer, height / 2 - 1, 0);
    }

    void UpdateUI()
    {
        string volumeText = volume.ToString("0.00"),
            surfaceAreaText = surfaceArea.ToString("0.00");

        radiusText.text = radius.ToString("0.00");
        heightText.text = height.ToString("0.00");

        volumeDisplay.text = $"Cylenderets volumen:\nV = h * π * r^2\n{heightText.text} * π * {radiusText.text}^2 = {volumeText}";

        surfaceAreaDisplay.text = $"Cylenderets overfladeareal:\nA = 2 * π * r * (h + r)\n2 * π * {radiusText.text} * ({heightText.text} + {radiusText.text}) = {surfaceAreaText}";
    }

    void UpdateValues(float value, string dimension)
    {
        switch (dimension)
        {
            case "radius":
                radius = value;
                break;
            case "height":
                height = value * 2;
                break;
        }

        UpdateDimensions();
        UpdateUI();
    }
}
