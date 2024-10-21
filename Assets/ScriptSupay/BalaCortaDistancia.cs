using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaCortaDistancia : MonoBehaviour
{
    [SerializeField] private float daño = 10f; 
    [SerializeField] private float velocidad = 5f;
    [SerializeField] private float tiempoVida = 3f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * velocidad;
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PLAYER"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                
                player.RecibirDaño(daño);
              
                player.ReducirCordura(5);  
            }

           
            Destroy(gameObject);
        }
    }
}
