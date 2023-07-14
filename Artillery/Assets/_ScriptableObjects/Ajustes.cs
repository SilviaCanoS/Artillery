using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//va a aparecer en el menu con el boton derecho del mouse en la pestaña proyect, 0 = primer elemento
[CreateAssetMenu(fileName = "Ajustes", menuName = "Tools/Ajustes", order = 1)]

public class Ajustes : ScriptableObjects
{
    public bool ajustes = false;
    public int movimientoTuberia = 30;
    public float movimientoCaparazon = 30;
    public Dificultad nivelDificultad = Dificultad.facil;
    public EscogerBala bala = EscogerBala.Hongo;
    public enum Dificultad { facil, normal, dificil }
    public enum EscogerBala { Hongo, Caparazon, Corona, Pinguino }

    public void CambiarVelocidadTuberia(int nuevaVelocidad)
    {
        movimientoTuberia = nuevaVelocidad;
    }

    public void CambiarVelocidadCaparazon(float nuevaVelocidad)
    {
        movimientoCaparazon = nuevaVelocidad;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        nivelDificultad = (Dificultad)nuevaDificultad;
    }

    public void CambiarBala(int nuevaBala)
    {
        bala = (EscogerBala)nuevaBala;
    }
}
