using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
 

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Disparar();

        }
        
    }

    protected virtual void Disparar()
    {

    }
}
