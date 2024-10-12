using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AceleracionProgresiva : GuardianTiempo
{
    public float aceleracion;
    private float velocidadMaxima; 
    private float aceleracionBase; 
    private bool persiguiendoJugador = false;

    private new void Start()
    {
        base.Start(); 
        velocidadMaxima = velocidad; 
        velocidad = 0; 
        aceleracionBase = aceleracion;  
    }

    private void Update()
    {
        base.Update();

        if (JugadorEnRango())
        {
            
            if (!persiguiendoJugador)
            {
                persiguiendoJugador = true;
                aceleracion += aceleracionBase; 
            }

            
            velocidad += aceleracion * Time.deltaTime; 
            velocidad = Mathf.Clamp(velocidad, 0, velocidadMaxima); 

            
            Transform jugador = GameObject.FindWithTag("JUGADOR").transform;
            transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidad * Time.deltaTime);

            
            if (Vector3.Distance(transform.position, jugador.position) < rangoDeAtaque)
            {
                Atacar();
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
       
        return Vector3.Distance(transform.position, jugador.transform.position) < rangoDeAtaque; 
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
