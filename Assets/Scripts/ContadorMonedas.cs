using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorMonedas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManagerCoin gameManagerCoin;
    public TextMeshProUGUI puntos;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntos.text = gameManagerCoin.PuntosTotales.ToString();
    }
}
