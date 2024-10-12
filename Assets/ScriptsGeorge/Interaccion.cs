using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion : MonoBehaviour
{
    public Transform palanca;
    public Vector3 estadoApagadoPosition;
    public Vector3 estadoPrendidoPosition;

   // private bool estaPrendida = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactuar();
        }


    }

    protected virtual void Interactuar()
    {

    }

}
