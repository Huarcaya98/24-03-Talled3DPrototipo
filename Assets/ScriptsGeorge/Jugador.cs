using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : Personaje
{
    //caminar
    protected override void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Movemos al jugador según la velocidad y las direcciones
        Vector3 movement = transform.forward * vertical + transform.right * horizontal;
        movement.Normalize(); // Normalizamos para evitar mayor velocidad en diagonales
        rb.velocity = new Vector3(movement.x * velocidad, rb.velocity.y, movement.z * velocidad);

    }
    //Correr
    protected override void Correr()
    {
        if(Input.GetKey(KeyCode.LeftShift) && EstaEnSuelo())
        {
            velocidad = 7.5f;
        }
        else
        {
            velocidad = 5f;
        }
    }
    //Saltar
    protected override void Saltar()
    {
        if(Input.GetButtonDown("Jump") && EstaEnSuelo())
        { 
            rb.AddForce(new Vector3(0,fuerzaSalto,0) , ForceMode.Impulse);
        
        }
    }
    //Agacharse
    protected override void Agacharse()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.7f, transform.localScale.z);
            agachado = true;

        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, 1f, transform.localScale.z);
            agachado = false;
        }
    }

}
