using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorVidas : MonoBehaviour
{
    public GameObject[] vidas; // Arreglo de objetos GameObject que representan las vidas
    private int vidasRestantes;

    private void Start()
    {
        ResetVidas();
    }

    public void ResetVidas()
    {
        vidasRestantes = vidas.Length;
        for (int i = 0; i < vidas.Length; i++)
        {
            vidas[i].SetActive(true);
        }
    }

    // Método para desactivar una vida basada en el índice
    public void DesactivarVida(int indice)
    {
        if (indice >= 0 && indice < vidas.Length && vidas[indice].activeSelf)
        {
            vidas[indice].SetActive(false);
            vidasRestantes--;
        }
    }

    public int GetVidasRestantes()
    {
        return vidasRestantes;
    }
}
