using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropdownDificultad : MonoBehaviour
{
    public Ajustes ajustes;
    TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = this.GetComponent<TMP_Dropdown>();
        dropdown.value = (int)ajustes.nivelDificultad;
        dropdown.onValueChanged.AddListener(delegate {
            ajustes.CambiarDificultad(dropdown.value);
            IdentificarNivel();
        });
    }

    public void IdentificarNivel()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
