using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitePantalla : MonoBehaviour
{
    [Header("Configurar en el editor")] //decoradores
    public float radio = 1;
    public bool mantenerEnPantalla = false;

    [Header("Configuraciones dinamicas")] //decoradores
    public float anchoCamara, altoCamara;
    public bool estaEnPantalla = true, salioDerecha, salioIzquierda, salioArriba, salioAbajo;

    private void Awake()
    {
        //tamaño de la escena
        altoCamara = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;
    }

    //en esta funcion porque se va a ejecutar despues de toda la logica del juego, evita condiciones de carrera
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        estaEnPantalla = true;
        salioAbajo = salioArriba = salioDerecha = salioIzquierda = false;

        if (pos.x > anchoCamara - radio)
        {
            pos.x = anchoCamara - radio;
            salioDerecha = true;
        }

        if (pos.x < -anchoCamara + radio)
        {
            pos.x = -anchoCamara + radio;
            salioIzquierda = true;
        }

        if (pos.y > altoCamara - radio)
        {
            pos.y = altoCamara - radio;
            salioArriba = true;
        }

        if (pos.y < -altoCamara + radio)
        {
            pos.y = -altoCamara + radio;
            salioAbajo = true;
        }

        estaEnPantalla = !(salioAbajo || salioArriba || salioDerecha || salioIzquierda);

        //si la pelota ya se salio de la pantalla, se regresa a la ultima posicion guardada
        if (mantenerEnPantalla && !estaEnPantalla)
        {
            transform.position = pos;
            estaEnPantalla = true;
        }
    }

    //dibuja los bordes de la camara
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 tamanoBorde = new Vector3(anchoCamara * 2, altoCamara * 2, .5f);
        Gizmos.DrawWireCube(Vector3.zero, tamanoBorde);
    }
}
