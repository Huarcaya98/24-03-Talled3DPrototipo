using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianPersiguiendo : GuardianTiempo
{
    private float tiempoPersecucion = 10f;
    private float contadorPersecucion = 0f;
    private bool estaPersiguiendo = false;


    void Update()
    {
        if (JugadorEnRango())
        {

            if (!estaPersiguiendo)
            {
                estaPersiguiendo = true;
                contadorPersecucion = tiempoPersecucion;
            }


            if (estaPersiguiendo)
            {
                PerseguirJugador();
                contadorPersecucion -= Time.deltaTime;


                if (contadorPersecucion <= 0f)
                {
                    estaPersiguiendo = false;
                    RegresarAPatrullar();
                }
            }
        }
        else if (!estaPersiguiendo)
        {

            Patrullar();
        }
    }

    private void PerseguirJugador()
    {

        velocidad += Time.deltaTime * 0.5f;
        Vector3 direccion = (jugador.transform.position - transform.position).normalized;
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    private void RegresarAPatrullar()
    {

        velocidad = 4f;
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


