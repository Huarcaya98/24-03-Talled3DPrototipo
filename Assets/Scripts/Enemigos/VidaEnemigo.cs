using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : SistemaVida
{
    public new void Start()
    {
        vidaMaxima = 50; 
        base.Start();     
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RecibirDaño(10);
            Debug.Log("Enemigo colisionó con el jugador. Vida actual: " + vidaActual);
        }
    }
}

