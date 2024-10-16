using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : SistemaMovimiento
{
    [Header("Rango")]
    private Transform jugador;
    [Range(0f, 10f)][SerializeField] private float rangoPersecucion = 5.0f;
    [Range(0f, 5f)][SerializeField] private float distanciaEvasion = 1.5f;

    [Header("Velocidad")]
    private float velocidadActual;
    private bool afectadoPorCrucifijo = false;

    protected override void Init()
    {
        base.Init();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        velocidadActual = velocidadPadre;
    }

    protected override void Move()
    {
        float distanciaJugador = Vector3.Distance(transform.position, jugador.position);

        if (!afectadoPorCrucifijo)
        {
            if (distanciaJugador < rangoPersecucion && distanciaJugador > distanciaEvasion)
            {
                PerseguirJugador();
            }
            else if (distanciaJugador <= distanciaEvasion)
            {
                EvasionJugador();
            }
        }
    }

    private void PerseguirJugador()
    {
        Vector3 direccion = (jugador.position - transform.position).normalized;
        rb.MovePosition(transform.position + direccion * velocidadActual * Time.deltaTime);
    }

    private void EvasionJugador()
    {
        Vector3 direccion = (transform.position - jugador.position).normalized;
        rb.MovePosition(transform.position + direccion * velocidadActual * Time.deltaTime);
    }

    public void ReducirVelocidad(float cantidad)
    {
        afectadoPorCrucifijo = true;
        velocidadActual -= cantidad;

        if (velocidadActual < 0)
        {
            velocidadActual = 0;
        }
    }

    public void RestaurarVelocidad()
    {
        afectadoPorCrucifijo = false;
        velocidadActual = velocidadPadre;
    }
}