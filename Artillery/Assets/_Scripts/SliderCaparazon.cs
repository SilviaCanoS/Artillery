using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderCaparazon : MonoBehaviour
{
    UnityEngine.UI.Slider sliderCaparazon;
    public Ajustes ajustes;

    // Start is called before the first frame update
    void Start()
    {
        sliderCaparazon = this.GetComponent<UnityEngine.UI.Slider>();
        sliderCaparazon.value = ajustes.movimientoCaparazon;
        sliderCaparazon.onValueChanged.AddListener(delegate { 
                      ajustes.CambiarVelocidadCaparazon(sliderCaparazon.value); });
    }
}
