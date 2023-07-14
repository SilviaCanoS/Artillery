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

        if (fuerzaBala.value == 0) velocidad = 1;
        else velocidad = fuerzaBala.value * 100;

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
