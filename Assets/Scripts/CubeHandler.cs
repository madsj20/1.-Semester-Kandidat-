using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeHandler : MonoBehaviour
{
    public float buffer = 0;

    public GameObject cube, worldCanvas;

    public Slider widthSlider, heightSlider, depthSlider;
    public TextMeshProUGUI volumeDisplay, surfaceAreaDisplay;
    public TextMeshProUGUI widthText, heightText, depthText;

    private float width = 1, height = 1, depth = 1;
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
        worldCanvas.GetComponent<RectTransform>().sizeDelta = cube.transform.localScale + Vector3.one * 0.4f;
        worldCanvas.transform.rotation = cube.transform.rotation;
    }

    void SetupSliders()
    {
        widthSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "width"); });
        heightSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "height"); });
        depthSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "depth"); });
    }

    void UpdateDimensions()
    {
        volume = width * height * depth;
        surfaceArea = (width * height + width * depth + height * depth) * 2;

        cube.transform.localScale = new Vector3(width, height, depth);
        cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.localScale.y / 2 - 0.5f, cube.transform.position.z);

        widthText.transform.position = new Vector3(0, -0.5f - buffer, -depth / 2 - buffer);
        heightText.transform.position = new Vector3(width / 2 + buffer, height / 2 - 0.5f, -depth / 2 - buffer);
        depthText.transform.position = new Vector3(width / 2 + buffer, -0.5f - buffer, 0);
    }

    void UpdateUI()
    {
        string volumeText = volume.ToString("0.00"),
            surfaceAreaText = surfaceArea.ToString("0.00");

        widthText.text = "l = " + width.ToString("0.00");
        heightText.text = "h = " + height.ToString("0.00");
        depthText.text = "b = " + depth.ToString("0.00");

        volumeDisplay.text = $"Kassens volumen: V = h * l * b\n{heightText.text} * {widthText.text} * {depthText.text} = {volumeText}";

        surfaceAreaDisplay.text = "Kassens overfladeareal:\nA = 2 * (h * l + h * b + l * b)\n" +
            $"2 * ({heightText.text} * {widthText.text} + {heightText.text} * {depthText.text} + {widthText.text} * {depthText.text}) = {surfaceAreaText}";
    }

    void UpdateValues(float value, string dimension)
    {
        switch (dimension)
        {
            case "width":
                width = value;
                break;
            case "height":
                height = value;
                break;
            case "depth":
                depth = value;
                break;
        }

        UpdateDimensions();
        UpdateUI();
    }
}
