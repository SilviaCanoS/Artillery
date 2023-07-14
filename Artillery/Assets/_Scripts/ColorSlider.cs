using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSlider : MonoBehaviour
{
    Image image;
    Color color;
    public Ajustes ajustes;

    // Start is called before the first frame update
    void Start()
    {
        switch (ajustes.bala)
        {
            case Ajustes.EscogerBala.Hongo: color = new Color(255, 0, 0); break;
            case Ajustes.EscogerBala.Caparazon: color = new Color(0, 255, 0); break;
            case Ajustes.EscogerBala.Corona: color = new Color(255, 0, 255); break;
            case Ajustes.EscogerBala.Pinguino: color = new Color(0, 0, 255); break;
        }
        image = this.GetComponent<Image>();
        image.color = color;
    }
}
