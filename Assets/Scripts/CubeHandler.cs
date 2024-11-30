using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeHandler : MonoBehaviour
{
    public float buffer = 0;

    public GameObject cube, worldCanvas;

    public Slider heightSlider, lengthSlider, widthSlider;
    public TextMeshProUGUI volumeDisplay, surfaceAreaDisplay;
    public TextMeshProUGUI heightText, lengthText, widthText;

    private float height = 1, length = 1, width = 1;
    private float volume, surfaceArea;

    private const string H_COLOR = "#15EC15ff";
    private const string L_COLOR = "#4040FBff";
    private const string B_COLOR = "#EC2E2Eff";

    private string h = $"<color={H_COLOR}>h</color>";
    private string l = $"<color={L_COLOR}>l</color>";
    private string b = $"<color={B_COLOR}>b</color>";

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
        heightSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "height"); });
        lengthSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "length"); });
        widthSlider.onValueChanged.AddListener((value) => { UpdateValues(value, "width"); });
    }

    void UpdateDimensions()
    {
        volume = height * length * width;
        surfaceArea = (height * length + height * width + length * width) * 2;

        cube.transform.localScale = new Vector3(width, height, length);
        cube.transform.localPosition = new Vector3(cube.transform.localPosition.x, cube.transform.localScale.y / 2 - 0.5f, cube.transform.localPosition.z);

        heightText.transform.localPosition = new Vector3(width / 2 + buffer, height / 2 - 0.5f, -length / 2 - buffer);
        lengthText.transform.localPosition = new Vector3(width / 2 + buffer, -0.5f - buffer, 0);
        widthText.transform.localPosition = new Vector3(0, -0.5f - buffer, -length / 2 - buffer); 
    }

    void UpdateUI()
    {
        string volumeText = volume.ToString("0.0"),
            surfaceAreaText = surfaceArea.ToString("0.0");

        heightText.text = $"<color={H_COLOR}>{height.ToString("0.0")}</color>";
        lengthText.text = $"<color={L_COLOR}>{length.ToString("0.0")}</color>";
        widthText.text = $"<color={B_COLOR}>{width.ToString("0.0")}</color>";

        volumeDisplay.text = $"Rumfang:\nV = {h} * {l} * {b} = {volumeText}";

        surfaceAreaDisplay.text = $"Overfladeareal:\nA = 2 * ({h} * {l} + {h} * {b} + {l} * {b}) = {surfaceAreaText}";
    }

    void UpdateValues(float value, string dimension)
    {
        switch (dimension)
        {
            case "height":
                height = value;
                break;
            case "length":
                length = value;
                break;
            case "width":
                width = value;
                break;
        }

        UpdateDimensions();
        UpdateUI();
    }
}
