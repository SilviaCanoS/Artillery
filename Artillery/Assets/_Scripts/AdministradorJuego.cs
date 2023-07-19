using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorJuego : MonoBehaviour
{
    public static AdministradorJuego singletonAdminJuego;
    private static int velocidadBala = 30, disparosPorJuego = 10;
    private static float velocidadRotacion = 15, velocidadCaparazon = 15;
    public GameObject gameOverCanvas, ganarCanvas, canvasPausa, canvasJuego;
    public Transform bestTransform, scoreTransform;
    public TMP_Text bestText, scoreText;
    public RegistroScore registroScore;
    public Ajustes ajustes;
    public FuerzaScrollBar fuerzaScrollBar;
    public Disparos disparos;

    public int VelocidadBala
    {
        get { return velocidadBala; }
        set { velocidadBala = value; }
    }

    public float VelocidadRotacion
    {
        get { return velocidadRotacion; }
        set { velocidadRotacion = value; }
    }

    public float VelocidadCaparazon
    {
        get { return velocidadCaparazon; }
        set { velocidadCaparazon = value; }
    }

    public int DisparosPorJuego
    {
        get { return disparosPorJuego; }
        set { disparosPorJuego = value; }
    }

    private void Awake()
    {
        //no permite que exista más de una instancia
        if (singletonAdminJuego == null) singletonAdminJuego = this;
        else Debug.LogError("Ya existe una instancia de esta clase");
    }

    private void Start()
    {
        Time.timeScale = 1;
        Cañon.bloqueado = false;

        disparosPorJuego = disparos.disparos;

        bestTransform = GameObject.Find("BestText").transform;
        bestText = bestTransform.GetComponent<TMP_Text>();
        scoreTransform = GameObject.Find("ScoreText").transform;
        scoreText = scoreTransform.GetComponent<TMP_Text>();

        registroScore.Cargar();
        bestText.text = $"Best: {registroScore.mejor}";
        registroScore.score = 0;
    }

    private void Update()
    {
        scoreText.text = $"Score: {registroScore.score}";
        if (registroScore.score >= registroScore.mejor)
        {
            registroScore.mejor = registroScore.score;
            bestText.text = $"Best: {registroScore.mejor}";
        }
        registroScore.Guardar();

        velocidadRotacion = ajustes.movimientoTuberia;
        velocidadCaparazon = ajustes.movimientoCaparazon;
        velocidadBala = (int)fuerzaScrollBar.velocidad;
    }

    public void GanarJuego()
    {
        ganarCanvas.SetActive(true);
        canvasJuego.SetActive(false);
        Time.timeScale = 0;
    }

    public void PerderJuego()
    {
        gameOverCanvas.SetActive(true);
        canvasJuego.SetActive(false);
        Time.timeScale = 0;
    }

    public void MostrarPausa()
    {
        canvasPausa.SetActive(true);
        canvasJuego.SetActive(false);
        Time.timeScale = 0;
    }

    public void RegresarJuego()
    {
        canvasPausa.SetActive(false);
        canvasJuego.SetActive(true);
        Time.timeScale = 1;
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SiguienteNivel()
    {
        Time.timeScale = 1;
        var siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > siguienteNivel) SceneManager.LoadScene(siguienteNivel);
        else IrMenuPrincipal();
    }

    public void IrMenuPrincipal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
