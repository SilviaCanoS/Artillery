using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Cañon : MonoBehaviour
{
    public int cont = 0;
    public UnityEvent balaDisparada;
    public static bool bloqueado;
    //public AudioClip clipDisparo;
    private GameObject sonidoDisparo;
    private AudioSource sourceDisparo;

    //[SerializeField]
    GameObject balaPrefab;
    public GameObject particulasDisparo, canvasJuego, hongo, caparazon, corona, pinguino;
    private GameObject puntaCañon;
    private float rotacion;

    public CañonControl cañonControl;
    private InputAction apuntar, disparar;
    public Ajustes ajustes;

    private void Awake()
    {
        cañonControl = new CañonControl();
    }

    private void OnEnable()
    {
        apuntar = cañonControl.Cañon.Apuntar;
        disparar = cañonControl.Cañon.Disparar;
        apuntar.Enable();
        disparar.Enable();

        //disparar.started //cuando se inicia el evento
        disparar.performed += Disparar; //mientras ocurre
        //disparar.canceled //cuano termina
    }


    private void Start()
    {
        switch(ajustes.bala)
        {
            case Ajustes.EscogerBala.Hongo: balaPrefab = hongo; break;
            case Ajustes.EscogerBala.Caparazon: balaPrefab = caparazon; break;
            case Ajustes.EscogerBala.Corona: balaPrefab = corona; break;
            case Ajustes.EscogerBala.Pinguino: balaPrefab = pinguino; break;
        }

        puntaCañon = transform.Find("PuntaCañon").gameObject;
        sonidoDisparo = GameObject.Find("DisparoSonido");
        sourceDisparo = sonidoDisparo.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotacion += Input.GetAxis("Horizontal") * AdministradorJuego.singletonAdminJuego.VelocidadRotacion;
        rotacion += apuntar.ReadValue<float>() * AdministradorJuego.singletonAdminJuego.VelocidadRotacion;

        //restringe el movimiento del cañon de 0 a 90°
        if (rotacion <= 90 && rotacion >= 0) transform.eulerAngles = new Vector3(rotacion, 90, 0);
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;

        //if (Input.GetKeyDown(KeyCode.Space) 
        //    && cont <= AdministradorJuego.singletonAdminJuego.DisparosPorJuego
        //    && !bloqueado) 
    }

    private void Disparar(InputAction.CallbackContext context)
    {
        if (cont <= AdministradorJuego.singletonAdminJuego.DisparosPorJuego && !bloqueado)
        {
            cont++;
            canvasJuego.SetActive(false);            
            GameObject temp = Instantiate(balaPrefab, puntaCañon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles; //eulerAngles = matriz de rotacion
            direccionDisparo.y = 90 - direccionDisparo.x; //si y de puntaCañon tiene 90° de rotacion
            //Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
            //Vector3 cambiarAltura = puntaCañon.transform.position + new Vector3(0, 2, 0);
            GameObject particulas = Instantiate(particulasDisparo, puntaCañon.transform.position,
                                    Quaternion.AngleAxis(-direccionDisparo.x, new Vector3(0, 0, 1)));
            tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.singletonAdminJuego.VelocidadBala;
            //AdministradorJuego.singletonAdminJuego.DisparosPorJuego--;
            sourceDisparo.Play();
            //sourceDisparo.PlayOneShot(clipDisparo); //para que no se cicle
            bloqueado = true;
            balaDisparada.Invoke();
        }
    }
}
