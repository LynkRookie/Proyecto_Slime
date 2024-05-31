using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoToxico : MonoBehaviour
{
    private bool invulnerable;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Verificar si el jugador no es invulnerable antes de perder una vida
        if (!invulnerable && other.gameObject.CompareTag("Player"))
        {
            GameManagerCoin gameManagerCoin = FindObjectOfType<GameManagerCoin>(); // Encuentra una instancia existente de GameManagerCoin
            if (gameManagerCoin != null)
            {
                gameManagerCoin.PerderVida(); // Llama al método PerderVida en la instancia encontrada
                StartCoroutine(ActivarInvulnerabilidad());
            }
        }
    }

    private IEnumerator ActivarInvulnerabilidad()
    {
        invulnerable = true;
        yield return new WaitForSeconds(0.05f);
        invulnerable = false;
    }
}
