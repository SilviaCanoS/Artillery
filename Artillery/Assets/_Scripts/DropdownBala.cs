using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DropdownBala : MonoBehaviour
{
    public Ajustes ajustes;
    TMP_Dropdown dropdown;
    public UnityEvent reiniciar;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = this.GetComponent<TMP_Dropdown>();
        dropdown.value = (int)ajustes.bala;
        dropdown.onValueChanged.AddListener(delegate {
            ajustes.CambiarBala(dropdown.value);
            reiniciar.Invoke();
        });
    }
}
