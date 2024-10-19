using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviminentoJugador : MonoBehaviour
{
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private  int vida = 100;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        float movimientoVertical = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        transform.Translate(movimientoHorizontal, 0, movimientoVertical);

        if (vida <= 0)
        {
            DestruirJugador();
        }
    }

    public void RecibirDanio(int cantidad)
    {
        vida -= cantidad;
        vida = Mathf.Max(vida, 0);
        Debug.Log("Vida restante :" + vida);

        if (vida <= 0)
        {
            Debug.Log("El jugador a muerto ");
            DestruirJugador();
        }

    }

    void DestruirJugador()
    {

        Destroy(gameObject);
    }


}
