using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class FuerzaScrollBar : MonoBehaviour
{
    Scrollbar fuerzaBala;
    //float timer = 0, timerEfecto = 0.5f;
    float movimiento = 0;
    public float velocidad = 1;
    public CañonControl cañonControl;
    private InputAction modificarFuerzaDisparo;

    private void Awake()
    {
        cañonControl = new CañonControl();
    }

    private void OnEnable()
    {
        modificarFuerzaDisparo = cañonControl.Cañon.ModificarFuerzaDisparo;
        modificarFuerzaDisparo.Enable();
    }

    private void OnDisable()
    {
        modificarFuerzaDisparo.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        fuerzaBala = GetComponent<Scrollbar>();
        fuerzaBala.value = movimiento;
    }

    private void Update()
    {
        movimiento += modificarFuerzaDisparo.ReadValue<float>() *
            AdministradorJuego.singletonAdminJuego.VelocidadCaparazon;

        if (movimiento < 0) movimiento = 0;
        else if (movimiento > 1) movimiento = 1; 

        fuerzaBala.value = movimiento;

        if (fuerzaBala.value == 0) velocidad = 20;
        else if (fuerzaBala.value > 0 && fuerzaBala.value <= 0.1f) velocidad = 21;
        else if (fuerzaBala.value > 0.1f && fuerzaBala.value <= 0.2f) velocidad = 22;
        else if (fuerzaBala.value > 0.2f && fuerzaBala.value <= 0.3f) velocidad = 23;
        else if (fuerzaBala.value > 0.3f && fuerzaBala.value <= 0.4f) velocidad = 24;
        else if (fuerzaBala.value > 0.4f && fuerzaBala.value <= 0.5f) velocidad = 25;
        else if (fuerzaBala.value > 0.5f && fuerzaBala.value <= 0.6f) velocidad = 26;
        else if (fuerzaBala.value > 0.7f && fuerzaBala.value <= 0.7f) velocidad = 27;
        else if (fuerzaBala.value > 0.8f && fuerzaBala.value <= 0.8f) velocidad = 28;
        else if (fuerzaBala.value > 0.9f && fuerzaBala.value <= 0.9f) velocidad = 29;
        else if (fuerzaBala.value > 0.9f)velocidad = 30;

        //timer += Time.deltaTime;
        //if (timer >= timerEfecto)
        //{
        //    timer = 0;
        //    fuerzaBala.value += .1f;
        //    velocidad = fuerzaBala.value * 100;
        //}

        //if (fuerzaBala.value > 1)
        //{
        //    fuerzaBala.value = 0;
        //    velocidad = 1;
        //}
    }
}
