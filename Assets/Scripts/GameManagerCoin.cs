using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCoin : MonoBehaviour
{
    public static GameManagerCoin Instance { get; private set; }
    private int puntosTotales;
    private int vidas = 3;

    public ContadorVidas hub;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        InicializarEstado();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InicializarEstado();
    }

    // Método para reiniciar el estado del GameManager
    public void InicializarEstado()
    {
        puntosTotales = 0;
        vidas = 3;

        hub = FindObjectOfType<ContadorVidas>();
        if (hub != null)
        {
            hub.ResetVidas();
        }
    }

    public int PuntosTotales { get { return puntosTotales; } }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
    }

    public void PerderVida()
    {
        if (vidas > 0)
        {
            vidas--;

            if (hub != null)
            {
                hub.DesactivarVida(vidas);
            }

            if (vidas == 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    public void destruirPersonaje()
    {
        Destroy(gameObject);
    }
}
