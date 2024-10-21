using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaLargaDistancia : MonoBehaviour
{
    [SerializeField] private float da�o = 20f;  
    [SerializeField] private float velocidad = 10f;
    [SerializeField] private float tiempoVida = 5f;

    private void Start()
    {
        
        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PLAYER"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                
                player.RecibirDa�o(da�o);
             
                player.ReducirCordura(10); 
            }

            
            Destroy(gameObject);
        }
    }

}
