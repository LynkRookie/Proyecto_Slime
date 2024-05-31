using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manejo_Objeto_Puntaje : MonoBehaviour
{
    // Start is called before the first frame update
    public int PuntosTotales { get {return PuntosTotales; }}
    private int puntosTotales;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }
}
