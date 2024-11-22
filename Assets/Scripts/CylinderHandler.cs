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

    private const string R_COLOR = "#FE5CA2";
    private const string H_COLOR = "#06c8c0";

    private string r = $"<color={R_COLOR}>r</color>";
    private string h = $"<color={H_COLOR}>h</color>";

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
        cylinder.transform.localPosition = new Vector3(cylinder.transform.localPosition.x, cylinder.transform.localScale.y -1, cylinder.transform.localPosition.z);

        radiusText.transform.localPosition = new Vector3(radius / 4, height + buffer - 1, 0);
        heightText.transform.localPosition = new Vector3(radius / 2 + buffer, height / 2 - 1, 0);
    }

    void UpdateUI()
    {
        string volumeText = volume.ToString("0.00"),
            surfaceAreaText = surfaceArea.ToString("0.00");

        radiusText.text = $"<color={R_COLOR}>{radius.ToString("0.00")}</color>";
        heightText.text = $"<color={H_COLOR}>{height.ToString("0.00")}</color>";

        volumeDisplay.text = $"Rumfang:\nV = {h} * π * {r}^2 = {volumeText}";

        surfaceAreaDisplay.text = $"Overfladeareal:\nA = 2 * π * {r} * ({h} + {r}) = {surfaceAreaText}";
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
