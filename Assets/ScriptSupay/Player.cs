using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float vida = 100f;
    [SerializeField] private float cordura = 100f;
    [SerializeField] private float velocidadMovimiento = 5f;

    private Rigidbody rb;
    private Vector3 movimiento;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical).normalized;

        cordura -= Time.deltaTime * 0.1f; 
        if (cordura < 0) cordura = 0;

        if (vida <= 0)
        {
            Debug.Log("El jugador ha muerto.");
            
        }

        Debug.Log("Vida: " + vida + " | Cordura: " + cordura);
    }

    void FixedUpdate()
    {
       
        if (movimiento != Vector3.zero)
        {
            rb.MovePosition(rb.position + movimiento * Time.fixedDeltaTime);
        }
    }

    public void RecibirDaño(float cantidad)
    {
        vida -= cantidad;
        if (vida < 0) vida = 0;
    }

    public void ReducirCordura(float cantidad)
    {
        cordura -= cantidad;
        if (cordura < 0) cordura = 0;
    }

}
