using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupayEspectro : MonoBehaviour
{

    [SerializeField] private float rangoDeteccion = 10f;    
    [SerializeField] private float tiempoPersecucion = 5f;  
    [SerializeField] private float velocidadPersecucion = 4f; 
    [SerializeField] private float dañoPorGolpe = 10f;
    [SerializeField] private float intervaloDeDaño = 2f;
    [SerializeField] private float porcentajeCordura = 0.3f;

    private Transform jugador;
    private Vector3 posicionInicial;
    private bool persiguiendo = false;
    private float tiempoRestantePersecucion;
    private float tiempoUltimoGolpe;

    private void Start()
    {
        posicionInicial = transform.position; 
        tiempoRestantePersecucion = tiempoPersecucion;
        tiempoUltimoGolpe = 0f;
    }

    private void Update()
    {
        if (jugador != null)
        {
            if (Vector3.Distance(transform.position, jugador.position) <= rangoDeteccion)
            {
                PerseguirJugador();


                if (!persiguiendo)
                {
                    persiguiendo = true;
                    tiempoRestantePersecucion = tiempoPersecucion;
                }
            }
            else if (persiguiendo)
            {
                RegresarAPosicionInicial();
            }
        }
        else 
        {
            RegresarAPosicionInicial();
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
                Debug.Log("ESTÁ MUERTO");
                Destroy(jugador.gameObject); 
            }
            TeletransportarYReducirCordura();
        }

        tiempoRestantePersecucion -= Time.deltaTime;
        if (tiempoRestantePersecucion <= 0) 
        {
            RegresarAPosicionInicial();
        }
    }

    private void TeletransportarYReducirCordura()
    {

        StartCoroutine(TeletransportarCoroutine());
    }

    private IEnumerator TeletransportarCoroutine()
    {
       
        gameObject.SetActive(false); 

        
        yield return new WaitForSeconds(0.1f);

        
        Vector3 direccionAlJugador = (jugador.position - transform.position).normalized;
        Vector3 nuevaPosicion = jugador.position - direccionAlJugador * 1.5f; 
        transform.position = nuevaPosicion;

        
        gameObject.SetActive(true); 

        
        int corduraAFijar = (int)(jugador.GetComponent<Player>().GetCordura() * porcentajeCordura);
        jugador.GetComponent<Player>().ReducirCordura(corduraAFijar);

        
        if (jugador.GetComponent<Player>().GetCordura() <= 0)
        {
            Debug.Log("EL JUGADOR SE VOLVIO LOCO");
            Destroy(jugador.gameObject); 
        }
    }

    private void RegresarAPosicionInicial()
    {
        if (persiguiendo) 
        {
            persiguiendo = false;
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadPersecucion * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
       
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
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
            RegresarAPosicionInicial();
        }
    }
}