using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aceleracion: GTemplo
{
    public float aceleracion;
    private float velocidadMaxima;
    private float aceleracionBase;
    private bool persiguiendoJugador = false;

    private Transform jugador;


    void Start()
    {
        base.Start();
        velocidadMaxima = velocidad;
        velocidad = 0;
        aceleracionBase = aceleracion;
        GameObject jugadorObj = GameObject.FindWithTag("JUGADOR");
        if (jugadorObj != null)
        {
            jugador = jugadorObj.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró al jugador en la escena.");
        }
    }

   
    void Update()
    {
        base.Update();
        if (jugador != null && JugadorEnRango())
        {
            if (!persiguiendoJugador)
            {
                persiguiendoJugador = true;
                aceleracion += aceleracionBase;
            }

            velocidad += aceleracion * Time.deltaTime;
            velocidad = Mathf.Clamp(velocidad, 0, velocidadMaxima);


            transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);


            if (Time.time >= proximoAtaque && Vector3.Distance(transform.position, jugador.position) < rangoDeAtaque)
            {
                Atacar();
                proximoAtaque = Time.time + tiempoEntreAtaques;
            }
        }
        else
        {
            RegresarAPosicionOriginal();
            velocidad = 0;
            persiguiendoJugador = false;
        }

    }

    private bool JugadorEnRango()
    {

        return jugador != null && Vector3.Distance(transform.position, jugador.position) < rangoDeAtaque;
    }

    public override void Atacar()
    {

        if (jugadorScript != null)
        {
            jugadorScript.RecibirDanio(10);
            Debug.Log("Atacando al jugador");
        }
        else
        {
            Debug.LogWarning("No se encontró el script del jugador.");
        }
    }

    private void RegresarAPosicionOriginal()
    {

        if (puntosDePatrulla.Length > 0)
        {
            Patrullar();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionOriginal, velocidad * Time.deltaTime);
        }
    }

}


