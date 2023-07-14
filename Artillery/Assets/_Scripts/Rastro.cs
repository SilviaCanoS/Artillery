using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Rastro : MonoBehaviour
{
    [Header("Configurar en editor")]
    public float distanciaMinimaEntrePuntos = 0.1f;

    private LineRenderer linea, mesh;
    private GameObject _objetivoLinea;
    private List<Vector3> puntos;
    public Ajustes ajustes;
    public Material hongo, caparazon, corona, pinguino;

    public GameObject ObjetivoLinea
    {
        get { return (_objetivoLinea);}
        set
        {
            _objetivoLinea = value;
            if(_objetivoLinea != null)
            {
                linea.enabled = false;
                puntos = new List<Vector3>();
                AgregarPunto();
            }
        }
    }

    public Vector3 UltimoPunto
    {
        get
        {
            if (puntos == null) return (Vector3.zero);
            return (puntos[puntos.Count - 1]);
        }
    }

    public void AgregarPunto()
    {
        Vector3 punto = _objetivoLinea.transform.position;
        if (puntos.Count > 0 && (punto - UltimoPunto).magnitude < distanciaMinimaEntrePuntos) return;
        puntos.Add(punto);
        linea.positionCount = puntos.Count;
        linea.SetPosition(puntos.Count - 1, UltimoPunto);
        linea.enabled = true;
    }

    private void Awake()
    {
        linea = GetComponent<LineRenderer>();
        linea.enabled = false;
        puntos = new List<Vector3>();
    }

    private void Start()
    {
        mesh = this.GetComponent<LineRenderer>();
        switch (ajustes.bala)
        {
            case Ajustes.EscogerBala.Hongo: mesh.material = hongo; break;
            case Ajustes.EscogerBala.Caparazon: mesh.material = caparazon; break;
            case Ajustes.EscogerBala.Corona: mesh.material = corona; break;
            case Ajustes.EscogerBala.Pinguino: mesh.material = pinguino; break;
        }
    }

    private void FixedUpdate()
    {
        if(_objetivoLinea == null) 
        {
            if (SeguirCamara.objetivo != null)
            {
                if (SeguirCamara.objetivo.CompareTag("Bala"))
                    ObjetivoLinea = SeguirCamara.objetivo;
                else
                    return;
            }
            else
                return;
        }

        AgregarPunto();
        if (SeguirCamara.objetivo == null) ObjetivoLinea = null;
    }
}
