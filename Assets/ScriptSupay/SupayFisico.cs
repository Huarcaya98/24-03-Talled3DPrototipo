using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupayFisico : MonoBehaviour
{

    [SerializeField] private GameObject balaLargaDistanciaPrefab; 
    [SerializeField] private GameObject balaCortaDistanciaPrefab;  
    [SerializeField] private float tiempoEntreDisparos = 1f;
    [SerializeField] private float velocidadBalaLarga = 10f;
    [SerializeField] private float velocidadBalaCorta = 5f;
    [SerializeField] private float rangoAtaqueDistancia = 15f;
    [SerializeField] private float rangoAtaqueCorto = 5f;
    [SerializeField] private float velocidadEmbestida = 8f;

    private Player player;
    private bool enAtaqueDistancia = false;
    private bool enAtaqueCorto = false;
    private bool enEmbestida = false;
    private float proximoDisparo;

    private void Start()
    {
        player = FindObjectOfType<Player>();  
    }

    private void Update()
    {
        if (player != null)
        {
            float distanciaJugador = Vector3.Distance(transform.position, player.transform.position);

            
            if (Input.GetMouseButtonDown(0) && Time.time >= proximoDisparo)  
            {
                if (distanciaJugador > rangoAtaqueCorto && distanciaJugador <= rangoAtaqueDistancia && !enEmbestida)
                {
                    DispararLargaDistancia();
                    proximoDisparo = Time.time + tiempoEntreDisparos;
                }
            }

            
            if (Input.GetMouseButtonDown(1) && Time.time >= proximoDisparo)  
            {
                if (distanciaJugador <= rangoAtaqueCorto && !enEmbestida)
                {
                    DispararCortaDistancia();
                    proximoDisparo = Time.time + tiempoEntreDisparos;
                }
            }

            
            if (distanciaJugador <= rangoAtaqueDistancia && distanciaJugador > rangoAtaqueCorto && !enAtaqueDistancia && !enAtaqueCorto)
            {
                if (!enEmbestida)
                {
                    enEmbestida = true;
                    Embestir();
                    Invoke(nameof(TerminarEmbestida), 15f); 
                }
            }
        }
    }

    private void DispararLargaDistancia()
    {
        
        GameObject bala = Instantiate(balaLargaDistanciaPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = (player.transform.position - transform.position).normalized * velocidadBalaLarga;

        
        player.RecibirDaño(player.GetVida() * 0.4f);
        player.ReducirCordura(Mathf.RoundToInt(player.GetCordura() * 0.4f));
    }

    private void DispararCortaDistancia()
    {
        
        GameObject bala = Instantiate(balaCortaDistanciaPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        rb.velocity = (player.transform.position - transform.position).normalized * velocidadBalaCorta;

        
        player.RecibirDaño(player.GetVida() * 0.15f);
        player.ReducirCordura(Mathf.RoundToInt(player.GetCordura() * 0.2f));
    }

    private void Embestir()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, velocidadEmbestida * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) < 1f)  
        {
            player.RecibirDaño(player.GetVida() * 0.5f);  
        }
    }

    private void TerminarEmbestida()
    {
        enEmbestida = false;
    }

}
