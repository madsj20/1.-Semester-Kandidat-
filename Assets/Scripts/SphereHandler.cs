using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SphereHandler : MonoBehaviour
{
    public float buffer = 0;

    public GameObject sphere, worldCanvas;

    public Slider radiusSlider;
    public TextMeshProUGUI volumeDisplay, surfaceAreaDisplay;
    public TextMeshProUGUI radiusText;

    private float radius = 1;
    private float volume, surfaceArea;

    private const string R_COLOR = "#ffbf4f";

    private string r = $"<color={R_COLOR}>r</color>";

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
        worldCanvas.GetComponent<RectTransform>().sizeDelta = sphere.transform.localScale + Vector3.one * 0.4f;
        worldCanvas.transform.rotation = sphere.transform.rotation;
    }

    void SetupSliders()
    {
        radiusSlider.onValueChanged.AddListener((value) => { UpdateValues(value); });
    }

    void UpdateDimensions()
    {
        volume = 4f/3f * Mathf.PI * Mathf.Pow(radius, 3);
        surfaceArea = 4 * Mathf.PI * Mathf.Pow(radius, 2);

        sphere.transform.localScale = new Vector3(radius, radius, radius);
        sphere.transform.localPosition = new Vector3(sphere.transform.localPosition.x, sphere.transform.localScale.y / 2 - 0.5f, sphere.transform.localPosition.z);

        radiusText.transform.localPosition = new Vector3(radius / 2 + buffer, radius / 2 -0.5f, 0);
    }

    void UpdateUI()
    {
        string volumeText = volume.ToString("0.0"),
            surfaceAreaText = surfaceArea.ToString("0.0");

        radiusText.text = $"<color={R_COLOR}>{radius.ToString("0.0")}</color>";

        volumeDisplay.text = $"Rumfang: V = 4 / 3 * π * {r}^3 = {volumeText}";

        surfaceAreaDisplay.text = $"Overfladeareal:\nA = 4 * π * {r}^2 = {surfaceAreaText}";
    }

    void UpdateValues(float value)
    {
        radius = value;

        UpdateDimensions();
        UpdateUI();
    }
}