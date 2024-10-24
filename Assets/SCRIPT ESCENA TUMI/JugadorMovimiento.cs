using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private Rigidbody rb;
    private int piecesCollected = 0;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
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
            piecesCollected++; 
            Debug.Log($"Piezas recolectadas del Tumi: {piecesCollected}");
            Destroy(other.gameObject);
        }
    }



}
