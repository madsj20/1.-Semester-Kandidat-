using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxHandler : MonoBehaviour
{
    public Slider widthSlider, heightSlider, depthSlider;
    public TextMeshProUGUI volumeDisplay, surfaceAreaDisplay;

    private float width = 1, height = 1, depth = 1;
    private float volume, surfaceArea;

    void Start()
    {
        widthSlider.onValueChanged.AddListener((value) =>  { UpdateValues(value, "width"); });
        heightSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "height"); });
        depthSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "depth"); });

        UpdateUI();
    }

    void UpdateDimensions()
    {
        volume = width * height * depth;
        surfaceArea = (width * height + width * depth + height * depth) * 2;

        transform.localScale = new Vector3(width, height, depth);
    }

    void UpdateUI()
    {
        string volumeText = volume.ToString("0.00"),
            surfaceAreaText = surfaceArea.ToString("0.00");

        string widthText = width.ToString("0.00"),
            heightText = height.ToString("0.00"),
            depthText = depth.ToString("0.00");

        volumeDisplay.text = $"Kassens volumen:\nV = h * l * b\n{heightText} * {widthText} * {depthText} = {volumeText}";

        surfaceAreaDisplay.text = "Kassens overfladeareal:\nA = 2 * (h * l + h * b + l * b)\n" +
            $"2 * ({heightText} * {widthText} + {heightText} * {depthText} + {widthText} * {depthText}) = {surfaceAreaText}";
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
