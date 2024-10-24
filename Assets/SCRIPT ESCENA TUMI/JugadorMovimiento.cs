using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb;
    private VictoryScreen victoryScreenManager;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        victoryScreenManager = FindObjectOfType<VictoryScreen>();
    }

    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical"); 

        
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("TUMI"))
        {
            victoryScreenManager.CollectPiece(); 
            Destroy(other.gameObject); 
        }
    
    }



}
