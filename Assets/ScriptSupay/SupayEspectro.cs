using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupayEspectro : MonoBehaviour
{
    [SerializeField] private float rangoDeteccion = 10f; 
    [SerializeField] private float velocidadPersecucion = 4f; 
    [SerializeField] private float dañoPorGolpe = 10f; 
    [SerializeField] private float intervaloDeDaño = 2f; 
    [SerializeField] private float porcentajeCordura = 0.3f;

    private Transform jugador; 
    private bool persiguiendo = false; 
    private float tiempoUltimoGolpe;


    private void Start()
    {
        tiempoUltimoGolpe = 0f; 
    }

    private void Update()
    {
        if (jugador != null)
        {
            
            if (Vector3.Distance(transform.position, jugador.position) <= rangoDeteccion)
            {
                if (!persiguiendo)
                {
                    
                    int corduraAFijar = (int)(jugador.GetComponent<Player>().GetCordura() * porcentajeCordura);
                    jugador.GetComponent<Player>().ReducirCordura(corduraAFijar);
                    persiguiendo = true; 
                }
                PerseguirJugador();
            }
            else
            {
                persiguiendo = false; 
            }
        }
    }

    private void PerseguirJugador()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidadPersecucion * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, jugador.position) <= 1f && Time.time - tiempoUltimoGolpe >= intervaloDeDaño)
        {
            
            jugador.GetComponent<Player>().RecibirDaño(dañoPorGolpe);
            tiempoUltimoGolpe = Time.time; 

            
            if (jugador.GetComponent<Player>().GetVida() <= 0)
            {
                Debug.Log("ESTÁS MUERTO");
                Destroy(jugador.gameObject); 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PLAYER"))
        {
            jugador = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("PLAYER"))
        {
            jugador = null;
            persiguiendo = false; 
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}