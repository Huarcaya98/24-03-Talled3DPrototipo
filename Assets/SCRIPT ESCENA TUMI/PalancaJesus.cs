using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaJesus : MonoBehaviour
{
    public PuertaJesus puerta;
    public bool estaPrendida = false;
    public Transform palancaTransform;

    private void Start()
    {
        if (palancaTransform == null)
        {
            palancaTransform = transform; 
        }
    }

    public void Interactuar()
    {
       
        estaPrendida = !estaPrendida;

       
        if (estaPrendida)
        {
            
            palancaTransform.localRotation = Quaternion.Euler(0, 0, 45); 
            puerta.AbrirPuerta(); 
        }

        else
        {
            
            palancaTransform.localRotation = Quaternion.Euler(0, 0, -45); 
            puerta.CerrarPuerta(); 
        }
    }
}