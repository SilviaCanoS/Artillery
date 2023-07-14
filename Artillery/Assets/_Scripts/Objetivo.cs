using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objetivo : MonoBehaviour
{
    public UnityEvent gameWon;

    private void Update()
    {
        Collider[] hijos = GetComponentsInChildren<Collider>();
        if (hijos.Length <= 0) gameWon.Invoke();
    }
}
