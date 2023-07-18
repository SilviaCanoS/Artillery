using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class Disparos : MonoBehaviour
{
    public List<GameObject> balas;
    GameObject balaPrefab;
    public GameObject hongo, caparazon, corona, pinguino;
    public Ajustes ajustes;
    public int disparos = 0;
    public Transform disparosTransform;
    public TMP_Text disparosText;
    Vector3 posCaparazon;

    private void Start()
    {
        switch (ajustes.bala)
        {
            case Ajustes.EscogerBala.Hongo: balaPrefab = hongo; break;
            case Ajustes.EscogerBala.Caparazon: balaPrefab = caparazon; break;
            case Ajustes.EscogerBala.Corona: balaPrefab = corona; break;
            case Ajustes.EscogerBala.Pinguino: balaPrefab = pinguino; break;
        }
        if(balaPrefab == hongo) posCaparazon = new Vector3(-26, 16, 0);
        else posCaparazon = new Vector3(-30, 14, 0);

        Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
                .transform.SetParent(this.transform);
        switch (ajustes.nivelDificultad)
        {
            case Ajustes.Dificultad.facil: disparos = 15; break;
            case Ajustes.Dificultad.normal: disparos = 10; break;
            case Ajustes.Dificultad.dificil: disparos = 5; break;
        }

        disparosTransform = GameObject.Find("DisparosText").transform;
        disparosText = disparosTransform.GetComponent<TMP_Text>();
        disparosText.text = $"x{disparos}";

        //Vector3 posCaparazon = new Vector3(-32, 18, 0);
        //switch (ajustes.nivelDificultad)
        //{
        //    case Ajustes.Dificultad.facil:
        //        disparos = 15;
        //        for(int i = 0; i <= 9; i++)
        //        {
        //            posCaparazon.y -= 2;
        //            Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
        //                .transform.SetParent(this.transform);
        //        }
        //        posCaparazon.x += 3;
        //        posCaparazon.y = 18;
        //        for(int i = 0; i <= 4; i++)
        //        {
        //            posCaparazon.y -= 2;
        //            Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
        //                .transform.SetParent(this.transform);
        //        }
        //        break;
        //    case Ajustes.Dificultad.normal:
        //        disparos = 10;
        //        for (int i = 0; i <= 9; i++)
        //        {
        //            posCaparazon.y -= 2;
        //            Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
        //                .transform.SetParent(this.transform);
        //        }
        //        break;
        //    case Ajustes.Dificultad.dificil:
        //        disparos = 5;
        //        for (int i = 0; i <= 4; i++)
        //        {
        //            posCaparazon.y -= 2;
        //            Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
        //                .transform.SetParent(this.transform);
        //        }
        //        break;
        //}

        //Collider[] hijos = GetComponentsInChildren<Collider>();
        //foreach (Collider c in hijos) balas.Add(c.gameObject);
    }

    public void EliminarBala()
    {
        disparos--;
        disparosText.text = $"x{disparos}";
        //var objetoAEliminar = balas[balas.Count - 1];
        //Destroy(objetoAEliminar);
        //balas.RemoveAt(balas.Count - 1);
        if (balas == null) Destroy(this.gameObject);
    }
}
