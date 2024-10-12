using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public int vida = 100;
    

        
    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float movimientoVertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        transform.Translate(movimientoHorizontal, 0, movimientoVertical);
    }

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
        Debug.Log("Vida restante :" + vida);

        if(vida <= 0)
        {
            Debug.Log("El jugador a muerto ");
        }

    }
}
