using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormaScrollBar : MonoBehaviour
{
    Image forma;
    public Sprite hongo, caparazon, corona, pinguino;
    public Ajustes ajustes;

    // Start is called before the first frame update
    void Start()
    {
        forma = this.GetComponent<Image>();
        switch (ajustes.bala)
        {
            case Ajustes.EscogerBala.Hongo: forma.sprite = hongo; break;
            case Ajustes.EscogerBala.Caparazon: forma.sprite = caparazon; break;
            case Ajustes.EscogerBala.Corona: forma.sprite = corona; break;
            case Ajustes.EscogerBala.Pinguino: forma.sprite = pinguino; break;
        }
    }
}
