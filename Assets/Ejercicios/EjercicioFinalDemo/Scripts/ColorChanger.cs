using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;
    [SerializeField] private MeshRenderer meshRenderer;
    public Color colorToChange;
    void Update()
    {
        colorToChange = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        meshRenderer.material.color = colorToChange;
    }
}
