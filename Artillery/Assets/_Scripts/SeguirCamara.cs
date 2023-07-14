using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SeguirCamara : MonoBehaviour
{
    public static GameObject objetivo;

    [Header("Configurar en editor")]
    public float suavizado = 0.05f;
    public Vector2 limiteXY = Vector2.zero;
    public UnityEvent perder;
    public GameObject canvasJuego;
    public Cañon cañon;

    [Header("Configuracion dinamica")]
    public float camZ;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        Vector3 destino;
        if (objetivo == null)
        {
            canvasJuego.SetActive(true);
            destino = Vector3.zero;
            if (cañon.cont == AdministradorJuego.singletonAdminJuego.DisparosPorJuego) perder.Invoke();
        }
        else
        {
            destino = objetivo.transform.position;
            if(objetivo.CompareTag("Bala"))
            {
                bool sleeping = objetivo.GetComponent<Rigidbody>().IsSleeping();
                if(sleeping)
                {
                    objetivo = null;
                    destino = Vector3.zero;
                    Cañon.bloqueado = false;
                    return;
                }
            }
        }

        destino.x = Mathf.Max(limiteXY.x, destino.x);
        destino.y = Mathf.Max(limiteXY.y, destino.y);
        destino = Vector3.Lerp(transform.position, destino, suavizado);
        destino.z = camZ;
        transform.position = destino;
        Camera.main.orthographicSize = destino.y + 20;
    }
}
