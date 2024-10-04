using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxHandler : MonoBehaviour
{
    public GameObject widthSlider, heightSlider, depthSlider;
    public TextMeshProUGUI volumeDisplay, surfaceAreaDisplay;

    public float scaleMultiplyer;

    private float width, height, depth;
    private float volume, surfaceArea;

    // Update is called once per frame
    void Update()
    {
        volume = width * height * depth;
        surfaceArea = (width * height + width * depth + height * depth) * 2;

        volumeDisplay.text = $"Kassens volumen V = h * l * b = {height} * {width} * {depth} = {volume}";

        surfaceAreaDisplay.text = $"Kassens overfladeareal A = 2 * (h * l + h * b + l * B) = 2 * ({height} * {width} + {height} * {depth} + {width} * {depth}) = {volume}";
    }
}
