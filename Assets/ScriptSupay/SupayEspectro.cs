using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupayEspectro : MonoBehaviour
{
    [SerializeField] private float tiempoAgarrar = 5f;
    [SerializeField] private int  CantidadCordura = 30;
    [SerializeField] private float rangoDeteccion = 5f;
    [SerializeField] private float velocidadMovimiento = 2f;

    private bool estaAgarrando = false;
    private GameObject jugador;

  
    void Update()
    {
        if(jugador != null && !estaAgarrando)
        {
            float distanciaAlJugador = Vector3.Distance(transform.position, jugador.transform.position);

            if(distanciaAlJugador <= rangoDeteccion)
            {
                MoverHaciaJugador();
              
            }
        }
    }

    private void MoverHaciaJugador()
    {
        
        Vector3 direccion = (jugador.transform.position - transform.position).normalized;
        transform.position += direccion * velocidadMovimiento * Time.deltaTime;

        if (Vector3.Distance(transform.position, jugador.transform.position) < 1f && !estaAgarrando)
        {
            StartCoroutine(AgarrarJugador());
        }
    }

    private IEnumerator AgarrarJugador()
    {
        estaAgarrando = true;

        Player jugadorScript = jugador.GetComponent<Player>();

        if(jugadorScript  != null)
        {
            jugadorScript.ReducirCordura(CantidadCordura);
            Debug.Log("SUPAY ESPECTRO ha agarrado al jugador y le ha reducido la cordura en " + CantidadCordura);

            if (jugadorScript.GetCordura() <= 0)
            {
                Debug.Log("JUGADOR SE VOLVIO LOCO");
            }
        }
        yield return new WaitForSeconds(tiempoAgarrar);

        estaAgarrando = false;
        Debug.Log("SUPAY ESPECTRO ha terminado el agarre.");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PLAYER"))
        {
            jugador = other.gameObject;
            StartCoroutine(AgarrarJugador());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PLAYER")) 
        {
            jugador = null; 
        }
    }

    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}
