using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianEnGuardia : GuardianTiempo
{
    public float distanciaDePatrullaje;
    private Vector3 destino;
    private int direccion = 0;

    private float alturaFija;

    void Start()
    {
        alturaFija = transform.position.y;
        destino = ObtenerSiguienteDestino();
    }

    
    void Update()
    {
        Patrullar();
        if (JugadorEnRango())
        {
            Atacar();
        }
    }

    private void Patrullar()
    {

        Vector3 posicionDestino = new Vector3(destino.x, alturaFija, destino.z);
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);


        if (Vector3.Distance(transform.position, posicionDestino) < 0.1f)
        {
            destino = ObtenerSiguienteDestino(); 
        }
    }

    private Vector3 ObtenerSiguienteDestino()
    {
        Vector3 nuevaPosicion = transform.position;

        switch (direccion)
        {
            case 0: 
                nuevaPosicion = posicionOriginal + new Vector3(distanciaDePatrullaje, 0, 0);
                break;
            case 1: 
                nuevaPosicion = posicionOriginal + new Vector3(0, 0 , distanciaDePatrullaje);
                break;
            case 2: 
                nuevaPosicion = posicionOriginal + new Vector3(-distanciaDePatrullaje, 0, 0);
                break;
            case 3: 
                nuevaPosicion = posicionOriginal + new Vector3(0,0, -distanciaDePatrullaje);
                break;
        }

        
        direccion = (direccion + 1) % 4;

        return nuevaPosicion;
    }


    private bool JugadorEnRango()
    {
        if (jugador != null)
        {
            float distanciaAlJugador = Vector3.Distance(transform.position, jugador.transform.position);
            return distanciaAlJugador <= rangoDeAtaque; 
        }
        return false; 
    }

    public override void Atacar()
    {
        base.Atacar();
    }
}
