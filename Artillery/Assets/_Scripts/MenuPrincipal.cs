using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Ajustes ajustes;
    public GameObject canvasAjustes, canvasPrincipal;
    public RegistroScore registroScore;
    public Transform bestTransform;
    public TMP_Text bestText;

    private void Start()
    {
        bestTransform = GameObject.Find("MejorText").transform;
        bestText = bestTransform.GetComponent<TMP_Text>();
        bestText.text = $"Best: {registroScore.mejor}";

        if (ajustes.ajustes)
        {
            ajustes.ajustes = false;
            MostrarAjustes();
        }
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
        Time.timeScale= 1;
    }

    public void ResetJuego()
    {
        registroScore.mejor = 0;
        bestText.text = $"Best: {registroScore.mejor}";
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void MostrarAjustes()
    {
        canvasAjustes.SetActive(true);
        canvasPrincipal.SetActive(false);
    }

    public void CerrarAjustes()
    {
        canvasAjustes.SetActive(false);
        canvasPrincipal.SetActive(true);
    }

    public void CambiarIcono()
    {
        ajustes.ajustes = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
