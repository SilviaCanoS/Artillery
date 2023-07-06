using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public static bool bloqueado;

    [SerializeField] private GameObject balaPrefab;
    private GameObject puntaCañon;
    private float rotacion;
    private int cont = 1;

    private void Start()
    {
        puntaCañon = transform.Find("PuntaCañon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.singletonAdminJuego.VelocidadRotacion;

        //restringe el movimiento del cañon de 0 a 90°
        if (rotacion <= 90 && rotacion >= 0) transform.eulerAngles = new Vector3(rotacion, 90, 0);
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;

        if (Input.GetKeyDown(KeyCode.Space) 
            && cont <= AdministradorJuego.singletonAdminJuego.DisparosPorJuego
            && !bloqueado)
        {
            cont++;
            GameObject temp = Instantiate(balaPrefab, puntaCañon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles; //eulerAngles = matriz de rotacion
            direccionDisparo.y = 90 - direccionDisparo.x; //si y de puntaCañon tiene 90° de rotacion
            tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.singletonAdminJuego.VelocidadBala;
            bloqueado = true;
        }
    }
}
