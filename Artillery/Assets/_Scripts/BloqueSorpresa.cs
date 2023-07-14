using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueSorpresa : MonoBehaviour
{
    public int resistencia = 100;
    public int puntaje;
    public RegistroScore registroScore;
    public Ajustes ajustes;

    private void Awake()
    {
        switch (ajustes.nivelDificultad)
        {
            case Ajustes.Dificultad.facil: puntaje = resistencia; break;
            case Ajustes.Dificultad.normal: puntaje = resistencia * 2; break;
            case Ajustes.Dificultad.dificil: puntaje = resistencia * 3; break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            resistencia -= 100;
            registroScore.score += puntaje;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Explosion"))
        {
            resistencia -= 200;
            registroScore.score += 400;
        }
    }

    private void Update()
    {
        if(resistencia <= 0) Destroy(this.gameObject);
    }
}
