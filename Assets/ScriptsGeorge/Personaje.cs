using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
     [SerializeField] protected float velocidad = 5f;
     [SerializeField]protected float fuerzaSalto = 7f;
     public float vida = 100f;
     public float cordura = 100f; // Estado mental
     public bool agachado =  false;

    protected Rigidbody rb;
    public bool enSuelo;

    private void Awake()
    {
        Init();
    }
    protected virtual void Init()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Saltar();
        Correr();
        Agacharse();
    }

    protected virtual void Move()
    {

    }

    protected virtual void Saltar()
    {

    }

    protected virtual void Correr()
    {

    }

    protected virtual void Agacharse()
    {

    }

    protected virtual void Levantarse()
    {

    }
    protected virtual void RecibirDanio()
    {

    }

    protected virtual void Cordura()
    {

    }

    protected virtual void Morir()
    {

    }

    protected virtual bool EstaEnSuelo()
    {
        return enSuelo;
    }

    protected virtual bool EstaEnAire()
    {
        return !EstaEnSuelo();
    }

    //Metodo para collisiones con el suelo

     private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}
