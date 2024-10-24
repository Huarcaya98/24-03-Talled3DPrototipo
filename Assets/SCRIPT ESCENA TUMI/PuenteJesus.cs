using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuenteJesus: MonoBehaviour
{
    public Vector3 puenteAbiertoPosition; 
    public Vector3 puenteCerradoPosition;
    public float velocidadMovimiento = 2f;

    private bool moviendoPuente = false;
    private bool puenteAbierto = false;
    private Vector3 posicionObjetivo;

    private void Start()
    {
        puenteCerradoPosition = transform.localPosition;
        puenteAbiertoPosition = transform.localPosition + new Vector3(0, 3, 0); 
    }

    private void Update()
    {
        if (moviendoPuente)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, posicionObjetivo, velocidadMovimiento * Time.deltaTime);

            if (Vector3.Distance(transform.localPosition, posicionObjetivo) < 0.01f)
            {
                moviendoPuente = false;
            }
        }
    }

    public void AbrirPuente()
    {
        posicionObjetivo = puenteAbiertoPosition;
        moviendoPuente = true;
        puenteAbierto = true;
        Debug.Log("Puedes Pasar ");
    }

    public void CerrarPuente()
    {
        posicionObjetivo = puenteCerradoPosition;
        moviendoPuente = true;
        puenteAbierto = false;
        Debug.Log("No Puedes Pasar ");
    }


}
