using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Disparos : MonoBehaviour
{
    public List<GameObject> balas;
    GameObject balaPrefab;
    public GameObject hongo, caparazon, corona, pinguino;
    public Ajustes ajustes;
    public int disparos = 0;

    private void Start()
    {
        switch (ajustes.bala)
        {
            case Ajustes.EscogerBala.Hongo: balaPrefab = hongo; break;
            case Ajustes.EscogerBala.Caparazon: balaPrefab = caparazon; break;
            case Ajustes.EscogerBala.Corona: balaPrefab = corona; break;
            case Ajustes.EscogerBala.Pinguino: balaPrefab = pinguino; break;
        }

        Vector3 posCaparazon = new Vector3(-32, 18, 0);

        switch (ajustes.nivelDificultad)
        {
            case Ajustes.Dificultad.facil:
                disparos = 15;
                for(int i = 0; i <= 9; i++)
                {
                    posCaparazon.y -= 2;
                    Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
                        .transform.SetParent(this.transform);
                }
                posCaparazon.x += 3;
                posCaparazon.y = 18;
                for(int i = 0; i <= 4; i++)
                {
                    posCaparazon.y -= 2;
                    Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
                        .transform.SetParent(this.transform);
                }
                break;
            case Ajustes.Dificultad.normal:
                disparos = 10;
                for (int i = 0; i <= 9; i++)
                {
                    posCaparazon.y -= 2;
                    Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
                        .transform.SetParent(this.transform);
                }
                break;
            case Ajustes.Dificultad.dificil:
                disparos = 5;
                for (int i = 0; i <= 4; i++)
                {
                    posCaparazon.y -= 2;
                    Instantiate(balaPrefab, posCaparazon, Quaternion.identity)
                        .transform.SetParent(this.transform);
                }
                break;
        }

        Collider[] hijos = GetComponentsInChildren<Collider>();
        foreach (Collider c in hijos) balas.Add(c.gameObject);
    }

    public void EliminarBala()
    {
        var objetoAEliminar = balas[balas.Count - 1];
        Destroy(objetoAEliminar);
        balas.RemoveAt(balas.Count - 1);
        if(balas == null) Destroy(this.gameObject);
    }
}
