using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorGuia : MonoBehaviour
{
    MeshRenderer mesh;
    public Ajustes ajustes;
    public Material hongo, caparazon, corona, pinguino;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        switch (ajustes.bala)
        {
            case Ajustes.EscogerBala.Hongo: mesh.material = hongo; break;
            case Ajustes.EscogerBala.Caparazon: mesh.material = caparazon; break;
            case Ajustes.EscogerBala.Corona: mesh.material = corona; break;
            case Ajustes.EscogerBala.Pinguino: mesh.material = pinguino; break;
        }
    }
}
