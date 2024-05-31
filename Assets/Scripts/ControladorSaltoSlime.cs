using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSaltoSlime : MonoBehaviour
{
    public float fuerzaSaltoCorto = 5f; // Fuerza para saltos cortos
    public float intervaloSaltoCorto = 0.5f; // Intervalo entre saltos cortos
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private bool enSuelo;
    private bool tocandoPared;
    private bool puedeSaltar;
    private bool cayendo;
    private float tiempoUltimoSaltoCorto;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiempoUltimoSaltoCorto = Time.time;
    }

    void Update()
    {
        enSuelo = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, capaSuelo);
        tocandoPared = Physics2D.Raycast(transform.position, Vector2.right, 0.1f, capaSuelo) ||
                       Physics2D.Raycast(transform.position, Vector2.left, 0.1f, capaSuelo);
        puedeSaltar = enSuelo && !tocandoPared; // No puede saltar si está debajo de la plataforma o tocando una pared

        if (rb.velocity.y < 0 && !enSuelo)
        {
            cayendo = true;
        }
    }

    void FixedUpdate()
    {
        if (puedeSaltar && Time.time - tiempoUltimoSaltoCorto >= intervaloSaltoCorto)
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSaltoCorto);
            tiempoUltimoSaltoCorto = Time.time;
        }

        if (puedeSaltar && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSaltoCorto);
        }

        if (tocandoPared && !enSuelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, -Mathf.Abs(rb.velocity.x)); // Deslizamiento por la pared
        }

        if (cayendo)
        {
            // Aquí puedes agregar cualquier lógica adicional para cuando el slime esté cayendo

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            cayendo = false;
        }
    }
}
