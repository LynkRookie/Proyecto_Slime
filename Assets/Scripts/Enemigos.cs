using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntoMovimiento;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private AudioClip sonidoColision; 

    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;
    private bool invulnerable;
    private AudioSource audioSource; 

    private void Start()
    {
        // Obtener el componente AudioSource si está presente en el GameObject
        audioSource = GetComponent<AudioSource>();
        // Verificar si se encontró el componente AudioSource
        if (audioSource == null)
        {
            // Si no se encontró, imprimir un mensaje de error
            Debug.LogError("El componente AudioSource no se encontró en el GameObject del enemigo.");
        }
        // Inicializar otros componentes y variables
        numeroAleatorio = Random.Range(0, puntoMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntoMovimiento[numeroAleatorio].position, velocidadMovimiento * Time.deltaTime);
        if (Vector2.Distance(transform.position, puntoMovimiento[numeroAleatorio].position) < distanciaMinima)
        {
            numeroAleatorio = Random.Range(0, puntoMovimiento.Length);
            Girar();
        }
    }

    private void Girar()
    {
        if (transform.position.x < puntoMovimiento[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si el jugador no es invulnerable antes de perder una vida
        if (!invulnerable && collision.gameObject.CompareTag("Player"))
        {
            GameManagerCoin.Instance.PerderVida();
            if (sonidoColision != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoColision); // Reproducir el sonido
            }
            StartCoroutine(ActivarInvulnerabilidad());
        }
    }

    private IEnumerator ActivarInvulnerabilidad()
    {
        invulnerable = true;
        yield return new WaitForSeconds(0.5f);
        invulnerable = false;
    }
}
