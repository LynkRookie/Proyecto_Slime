using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientos_Slime : MonoBehaviour
{
// Variable para el Rigidbody2D
    private Rigidbody2D rb;

    // Variables para el movimiento horizontal
    private float horizontal;

    // Variables para el salto
    public float fuerzaSalto;
    public float saltitos_contante= 1f; // es la forma de la q salta el slime
    public float intervaloDeSalto = 1f; // Intervalo de tiempo entre saltos
    private float proximoTiempoDeSalto = 0f; // Tiempo del próximo salto
    private bool puedeDobleSalto = true; // Variable para el doble salto

    // Tecla para el salto
    public KeyCode teclaSalto = KeyCode.Space;

    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        // Obtener el input horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal <0.0f)
           {
            transform.localScale = new Vector3(-0.08627177f,0.09267274f,1.0f);
           } 
        else if (horizontal > 0.0f)
            {
                transform.localScale = new Vector3(0.08627177f,0.09267274f,1.0f);
            }
        // Verificar si es tiempo de saltar
        if (Time.time >= proximoTiempoDeSalto && Input.GetKeyDown(teclaSalto))
        {
            Jump();
            proximoTiempoDeSalto = Time.time + intervaloDeSalto; // Actualizar el tiempo del próximo salto
            puedeDobleSalto = true; // Habilitar el doble salto después de un salto
        }
        // Doble salto
        else if (Input.GetKeyDown(teclaSalto) && puedeDobleSalto)
        {
            Jump();
            puedeDobleSalto = false; // Deshabilitar el doble salto
        }
    }

    private void FixedUpdate()
    {
        // Mover el Slime horizontalmente
        rb.velocity = new Vector2(horizontal, rb.velocity.y);
    }

    private void Jump()
    {
        // Aplicar fuerza de salto al Rigidbody2D
        rb.AddForce(Vector2.up * fuerzaSalto);
    }
}