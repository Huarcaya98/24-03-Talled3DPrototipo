using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaJesus : MonoBehaviour
{
    public Vector3 puertaAbiertaPosition; 
    public Vector3 puertaCerradaPosition;
    public float velocidadMovimiento = 2f;

    private bool moviendoPuerta = false;
    private bool puertaAbierta = false;
    private Vector3 posicionObjetivo;


    private void Start()
    {
       
        puertaCerradaPosition = transform.localPosition;
       
        puertaAbiertaPosition = transform.localPosition + new Vector3(0, 3, 0);
    }

    private void Update()
    {
        
        if (moviendoPuerta)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, posicionObjetivo, velocidadMovimiento * Time.deltaTime);

           
            if (Vector3.Distance(transform.localPosition, posicionObjetivo) < 0.01f)
            {
                moviendoPuerta = false;
            }
        }
    }

    public void AbrirPuerta()
    {
        posicionObjetivo = puertaAbiertaPosition;
        moviendoPuerta = true;
        puertaAbierta = true;
        Debug.Log("Puerta abierta");
    }

    public void CerrarPuerta()
    {
        posicionObjetivo = puertaCerradaPosition;
        moviendoPuerta = true;
        puertaAbierta = false;
        Debug.Log("Puerta cerrada");
    }

}
