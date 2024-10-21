using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupayFisico : MonoBehaviour
{

    [SerializeField] private GameObject balaLargaDistanciaPrefab; 
    [SerializeField] private GameObject balaCortaDistanciaPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float tiempoEntreDisparos = 1f;
    [SerializeField] private float velocidadBalaLarga = 10f;
    [SerializeField] private float velocidadBalaCorta = 5f;
    [SerializeField] private float rangoAtaqueDistancia = 15f;
    [SerializeField] private float rangoAtaqueCorto = 5f;
    [SerializeField] private float velocidadEmbestida = 8f;
    public float danoEmbestida = 20f; 
    public int corduraEmbestida = 10;
    public float rangoDeEmbiste = 3f;


    private bool enEmbestida = false;

    private Player player;
    private float proximoDisparo;
    private bool haEmbistido = false;

    private void Start()
    {
        player = FindObjectOfType<Player>();
       
    }

    private void Update()
    {
        if (player != null)
        {
            float distanciaJugador = Vector3.Distance(transform.position, player.transform.position);

            
            ActualizarFirePoint();

            if (distanciaJugador < rangoAtaqueDistancia)
            {
                if (!haEmbistido)
                {
                    haEmbistido = true;
                    Embestir();
                    Invoke(nameof(TerminarEmbestida), 1f); 
                }

                
                if (distanciaJugador > rangoAtaqueCorto && Time.time >= proximoDisparo)
                {
                    DispararLargaDistancia();
                    proximoDisparo = Time.time + tiempoEntreDisparos;
                }

               
                if (distanciaJugador <= rangoAtaqueCorto && Time.time >= proximoDisparo)
                {
                    DispararCortaDistancia();
                    proximoDisparo = Time.time + tiempoEntreDisparos;
                }
            }
            else
            {
                haEmbistido = false; 
                enEmbestida = false; 
            }
        }
    }

    private void ActualizarFirePoint()
    {
        if (player != null)
        {
            
            Vector3 direccion = (player.transform.position - transform.position).normalized;

           
            Quaternion rotacion = Quaternion.LookRotation(direccion);
            firePoint.rotation = rotacion;
        }
    }

    private void DispararLargaDistancia()
    {

        GameObject bala = Instantiate(balaLargaDistanciaPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * velocidadBalaLarga;

        
        player.RecibirDaño(player.GetVida() * 0.4f);
        player.ReducirCordura(Mathf.RoundToInt(player.GetCordura() * 0.4f));
    }

    private void DispararCortaDistancia()
    {

        GameObject bala = Instantiate(balaCortaDistanciaPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * velocidadBalaCorta;

       
        player.RecibirDaño(player.GetVida() * 0.15f);
        player.ReducirCordura(Mathf.RoundToInt(player.GetCordura() * 0.2f));
    }

    private void Embestir()
    {

        if (Vector3.Distance(transform.position, player.transform.position) < rangoDeEmbiste)
        {
            
            Vector3 direccion = (player.transform.position - transform.position).normalized;
            transform.position += direccion * velocidadEmbestida * Time.deltaTime;

            
            player.RecibirDaño(danoEmbestida);
            player.ReducirCordura(corduraEmbestida);
        }
    }

    private void TerminarEmbestida()
    {
        enEmbestida = false; 
    }

    private void OnDrawGizmos()
    {
        if (firePoint != null)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(firePoint.position, firePoint.position + firePoint.forward * 5);

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, rangoAtaqueDistancia);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, rangoAtaqueCorto);
        }
    }
}
