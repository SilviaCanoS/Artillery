using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cañon : MonoBehaviour
{
    public static bool bloqueado;
    //public AudioClip clipDisparo;
    private GameObject sonidoDisparo;
    private AudioSource sourceDisparo;

    [SerializeField] private GameObject balaPrefab;
    public GameObject particulasDisparo;
    private GameObject puntaCañon;
    private float rotacion;
    private int cont = 1;

    public CañonControl cañonControl;
    private InputAction apuntar, modificarFuerzaDisparo, disparar;

    private void Awake()
    {
        cañonControl = new CañonControl();
    }

    private void OnEnable()
    {
        apuntar = cañonControl.Cañon.Apuntar;
        modificarFuerzaDisparo = cañonControl.Cañon.ModificarFuerzaDisparo;
        disparar = cañonControl.Cañon.Disparar;
        apuntar.Enable();
        modificarFuerzaDisparo.Enable();
        disparar.Enable();

        //disparar.started //cuando se inicia el evento
        disparar.performed += Disparar; //mientras ocurre
        //disparar.canceled //cuano termina
    }

    private void Start()
    {
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
            GameObject temp = Instantiate(balaPrefab, puntaCañon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles; //eulerAngles = matriz de rotacion
            direccionDisparo.y = 90 - direccionDisparo.x; //si y de puntaCañon tiene 90° de rotacion
            Vector3 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
            Vector3 cambiarAltura = new Vector3(puntaCañon.transform.position.x,
                                    puntaCañon.transform.position.y + 2, puntaCañon.transform.position.z);
            GameObject particulas = Instantiate(particulasDisparo, cambiarAltura,
                                                Quaternion.Euler(direccionParticulas), transform);
            tempRB.velocity = direccionDisparo.normalized * AdministradorJuego.singletonAdminJuego.VelocidadBala;
            sourceDisparo.Play();
            //sourceDisparo.PlayOneShot(clipDisparo); //para que no se cicle
            bloqueado = true;
        }
    }
}
