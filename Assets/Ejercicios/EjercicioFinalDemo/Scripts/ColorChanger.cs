using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Slider redSlider; //ESTOS SON LOS SLIDERS QUE USTED CREA EN EL CANVAS
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;
    [SerializeField] private Slider redSliderFireBall; //ESTOS SON LOS SLIDERS QUE USTED CREA EN EL CANVAS
    [SerializeField] private Slider greenSliderFireBall;
    [SerializeField] private Slider blueSliderFireBall;
    [SerializeField] private MeshRenderer meshRenderer; //ESTO SE PUEDE BORRAR, ES SOLO PARA EJEMPLO
    [SerializeField] private Material materialEffect; //ESTE ES EL MATERIAL DEL SHADER DE SU EFECTO
    [SerializeField] private MeshRenderer meshRendererFireBall; //ESTO SE PUEDE BORRAR, ES SOLO PARA EJEMPLO
    [SerializeField] private Material materialEffectFireBall; //ESTE ES EL MATERIAL DEL SHADER DE SU EFECTO
    public Color colorToChangeWaterLaser;
    public Color colorToChangeFireBall;
    void Update()
    {
        colorToChangeWaterLaser = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        meshRenderer.material.color = colorToChangeWaterLaser; 
        materialEffect.SetColor("_Color01", colorToChangeWaterLaser); //ACA USTED COGE LA REFERENCIA DE SU PROPIEDAD EN EL SHADER
        materialEffect.SetColor("_Color02", colorToChangeWaterLaser); //ACA USTED COGE LA REFERENCIA DE SU PROPIEDAD EN EL SHADER

        colorToChangeFireBall = new Color(redSliderFireBall.value, greenSliderFireBall.value, blueSliderFireBall.value);
        meshRendererFireBall.material.color = colorToChangeFireBall; 
        materialEffectFireBall.SetColor("_Color01", colorToChangeFireBall); //ACA USTED COGE LA REFERENCIA DE SU PROPIEDAD EN EL SHADER
        materialEffectFireBall.SetColor("_Color02", colorToChangeFireBall); //ACA USTED COGE LA REFERENCIA DE SU PROPIEDAD EN EL SHADER
    }
}
