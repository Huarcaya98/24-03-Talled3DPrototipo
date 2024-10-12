using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : SistemaMovimiento
{
    [SerializeField] private float resistenciaCorrer = 10f;
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float resistenciaActual = 100f;
    [SerializeField] private bool enSuelo = false;

    protected override void Move()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 velocidad = Vector3.zero;

        if (movimientoHorizontal != 0 || movimientoVertical != 0)
        {
            Vector3 direccion = (transform.forward * movimientoVertical + transform.right * movimientoHorizontal);

            if (Input.GetKey(KeyCode.LeftShift) && resistenciaActual > 0)
            {
                velocidad = direccion * velocidadPadre * 2;
                resistenciaActual -= resistenciaCorrer * Time.deltaTime;
            }
            else
            {
                velocidad = direccion * velocidadPadre;
            }
        }

        velocidad.y = rb.velocity.y;
        rb.velocity = velocidad;

        // Saltar
        if (Input.GetButtonDown("Jump") && enSuelo == true)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    public void RecuperarResistencia(float cantidad)
    {
        resistenciaActual = Mathf.Min(resistenciaActual + cantidad, 100f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}
