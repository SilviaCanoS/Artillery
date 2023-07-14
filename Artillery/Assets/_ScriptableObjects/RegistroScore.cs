using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//va a aparecer en el menu con el boton derecho del mouse en la pestaña proyect, 0 = primer elemento
[CreateAssetMenu(fileName = "RegistroScore", menuName = "Tools/RegistroScore", order = 0)]

public class RegistroScore : ScriptableObjects
{
    public int mejor = 0;
    public int score = 0;
}
