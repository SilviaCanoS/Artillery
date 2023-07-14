using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderTuberia : MonoBehaviour
{
    UnityEngine.UI.Slider sliderTuberia;
    public Ajustes ajustes;

    // Start is called before the first frame update
    void Start()
    {
        sliderTuberia = this.GetComponent<UnityEngine.UI.Slider>();
        sliderTuberia.value = ajustes.movimientoTuberia;
        sliderTuberia.onValueChanged.AddListener(delegate { 
                      ajustes.CambiarVelocidadTuberia((int)sliderTuberia.value); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
