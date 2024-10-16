using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVida : MonoBehaviour
{
    [SerializeField] public int vidaMaxima;
    public int vidaActual;

    public void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log("Recibió daño. Vida actual: " + vidaActual);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        Debug.Log("Ha muerto.");
        Destroy(gameObject); 
    }

    public int ObtenerVidaActual()
    {
        return vidaActual;
    }

    public void RecuperarVida(int cantidad)
    {
        vidaActual = Mathf.Min(vidaActual + cantidad, vidaMaxima);
        Debug.Log("Recuperó vida. Vida actual: " + vidaActual);
    }
}


