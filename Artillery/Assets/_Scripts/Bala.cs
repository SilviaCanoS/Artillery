using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bala : MonoBehaviour
{
    public GameObject particulasExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        //Explota luego de 3 segundos de tocar el suelo
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Obstaculo")) 
            Invoke("Explotar", 3);

        if (collision.gameObject.CompareTag("Objetivo")) 
            Explotar();
    }

    private void FixedUpdate()
    {
        if (this.transform.position.y < -40)
        {
            Cañon.bloqueado = false;
            Destroy(this.gameObject);
        }
    }

    public void Explotar()
    {
        GameObject particulas = Instantiate(particulasExplosion, transform.position, Quaternion.identity) 
                                as GameObject; //identity = 0
        Cañon.bloqueado = false;
        SeguirCamara.objetivo = null;
        Destroy(this.gameObject);
    }
}
