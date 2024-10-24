using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntorchaJesus : MonoBehaviour
{
    public PuenteJesus puente; 
    public bool estaPrendida = false;
    public Transform antorchaTransform;

    private void Start()
    {
        if (antorchaTransform == null)
        {
            antorchaTransform = transform;
        }
    }

    public void Interactuar()
    {
        estaPrendida = !estaPrendida;

        if (estaPrendida)
        {
            antorchaTransform.localRotation = Quaternion.Euler(0, 0, 45);
            puente.AbrirPuente(); 
        }
        else
        {
            antorchaTransform.localRotation = Quaternion.Euler(0, 0, -45);
            puente.CerrarPuente(); 
        }
    }
}
