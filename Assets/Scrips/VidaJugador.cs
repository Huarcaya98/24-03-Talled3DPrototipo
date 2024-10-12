using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJugador : SistemaVida
{
    public new void Start()
    {
        vidaMaxima = 100; 
        base.Start();    
    }

   
}
