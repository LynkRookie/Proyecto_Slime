using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;
    public GameManagerCoin gameManager;
    [SerializeField] private AudioClip sonidoRecoleccion; // Añadir campo para el sonido de recolección

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reproducir el sonido de recolección si está asignado
            if (sonidoRecoleccion != null)
            {
                AudioSource.PlayClipAtPoint(sonidoRecoleccion, transform.position);
            }

            // Sumar puntos al GameManager y destruir la moneda
            gameManager.SumarPuntos(valor);
            Destroy(gameObject);
        }
    }
}
