using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioArma : MonoBehaviour
{
    public GameObject escopeta;
    public GameObject crucifijo;
    private int armaSeleccionada = 0;  // Por defecto inicia con la escopeta

    void Start()
    {
        SeleccionarArma();
    }

    void Update()
    {
        // Cambiar de arma con las teclas 1 y 2
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            armaSeleccionada = 0;  // Escopeta
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            armaSeleccionada = 1;  // Crucifijo
        }

        // Cambiar de arma con la rueda del mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            armaSeleccionada = (armaSeleccionada + 1) % 2;  // Cambia hacia arriba
        }
        else if (scroll < 0f)
        {
            armaSeleccionada = (armaSeleccionada - 1 + 2) % 2;  // Cambia hacia abajo
        }

        SeleccionarArma();
    }

    void SeleccionarArma()
    {
        // Activa la arma seleccionada y desactiva la otra
        escopeta.SetActive(armaSeleccionada == 0);
        crucifijo.SetActive(armaSeleccionada == 1);
    }

    public bool EsEscopetaActiva()
    {
        return armaSeleccionada == 0;
    }

}
