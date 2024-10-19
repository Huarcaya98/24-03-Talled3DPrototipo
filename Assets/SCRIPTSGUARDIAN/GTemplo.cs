using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTemplo : MonoBehaviour
{

    [SerializeField] protected float rangoDeAtaque = 4f;
    [SerializeField] protected float velocidad = 4f;
    public Vector3 posicionOriginal;
    public Vector3[] puntosDePatrulla;
    private int indicePuntoActual = 0;

    protected GameObject jugador;
    protected MovimientoJugador jugadorScript;
    private Rigidbody rb;

    private bool puedeAtacar = true;
    public float tiempoEntreAtaques = 2f;
    public float proximoAtaque = 0f;
    private bool estaDormido = false;

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        posicionOriginal = transform.position;
        jugador = GameObject.FindWithTag("JUGADOR");
        if (jugador != null)
        {
            jugadorScript = jugador.GetComponent<MovimientoJugador>();
        }

        rb.isKinematic = true;
    }

    protected void Update()
    {

        if (jugador != null)
        {
            float distanciaAlJugador = Vector3.Distance(transform.position, jugador.transform.position);
            Debug.Log("Distancia al jugador " + distanciaAlJugador);

            if (!estaDormido && distanciaAlJugador <= rangoDeAtaque)
            {
                if (puedeAtacar && Time.time >= proximoAtaque)
                {
                    Atacar();
                    proximoAtaque = Time.time + tiempoEntreAtaques;
                }
            }

        }
    }

    public void CambiarEstadoDormido(bool estado)
    {
        estaDormido = estado;
    }

    public virtual void Atacar()
    {
        if (jugadorScript != null)
        {
            jugadorScript.RecibirDanio(10);
            Debug.Log("El guardián ha atacado al jugador.Vida restante del jugador " + jugador);
        }

        else
        {
            Debug.LogWarning("No se encontró el script del jugador.");
        }
    }

    protected void Patrullar()
    {
        if (puntosDePatrulla.Length == 0) return;


        Vector3 destino = puntosDePatrulla[indicePuntoActual];
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);


        if (Vector3.Distance(transform.position, destino) < 0.1f)
        {
            indicePuntoActual = (indicePuntoActual + 1) % puntosDePatrulla.Length;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAtaque);
    }





}
