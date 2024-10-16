using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : Interaccion
{
    private bool estaPrendida = false;

    protected override void Interactuar()
    {
        // Alternar entre los estados de la palanca
        estaPrendida = !estaPrendida;

        // Mover la palanca a la posición correspondiente
        if (estaPrendida)
        {
            palanca.localPosition = estadoPrendidoPosition; // Mueve la palanca hacia arriba
            Debug.Log("Palanca encendida");
        }
        else
        {
            palanca.localPosition = estadoApagadoPosition; // Mueve la palanca hacia abajo
            Debug.Log("Palanca apagada");
        }
    }

}
