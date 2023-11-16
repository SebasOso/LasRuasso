using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Slider redSlider; //ESTOS SON LOS SLIDERS QUE USTED CREA EN EL CANVAS
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;
    [SerializeField] private MeshRenderer meshRenderer; //ESTO SE PUEDE BORRAR, ES SOLO PARA EJEMPLO
    [SerializeField] private Material materialEffect; //ESTE ES EL MATERIAL DEL SHADER DE SU EFECTO
    public Color colorToChange;
    void Update()
    {
        colorToChange = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        meshRenderer.material.color = colorToChange; 
        materialEffect.SetColor("_Color01", colorToChange); //ACA USTED COGE LA REFERENCIA DE SU PROPIEDAD EN EL SHADER
        materialEffect.SetColor("_Color02", colorToChange); //ACA USTED COGE LA REFERENCIA DE SU PROPIEDAD EN EL SHADER
    }
}
