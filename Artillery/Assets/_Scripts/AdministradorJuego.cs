using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego singletonAdminJuego;
    private static int velocidadBala = 30, disparosPorJuego = 10;
    private static float velocidadRotacion = 15;

    public int VelocidadBala
    {
        get { return velocidadBala; }
        set { velocidadBala = value; }
    }

    public int DisparosPorJuego
    {
        get { return disparosPorJuego; }
        set { disparosPorJuego = value; }
    }

    public float VelocidadRotacion
    {
        get { return velocidadRotacion; }
        set { velocidadRotacion = value; }
    }

    private void Awake()
    {
        //no permite que exista más de una instancia
        if (singletonAdminJuego == null) singletonAdminJuego = this;
        else Debug.LogError("Ya existe una instancia de esta clase");
    }
}
