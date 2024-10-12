using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EmbestidaSupay : MonoBehaviour
{
    private Rigidbody supayRbd;
    public Transform jugadorTrf;
    private Transform supayTrf;
    private NavMeshAgent navMeshAgent;
    public bool estaEmbistiendo = true;
    public SupayPersecucion persecucionScript;

    void Start()
    {
        supayRbd = GetComponent<Rigidbody>();
        supayTrf = GetComponent<Transform>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(Embestir());
    }

    Vector3 CalculaDistanciaEntreJugadores()
    {
        return jugadorTrf.position - supayTrf.position;
    }

    IEnumerator Embestir()
    {
        while (estaEmbistiendo)
        {
            DetenerMovimiento(true);
            yield return new WaitForSeconds(2);

            DetenerMovimiento(false);
            Vector3 direccion = CalculaDistanciaEntreJugadores().normalized;
            direccion.y = 0;
            supayRbd.velocity = direccion * 20;
            yield return new WaitForSeconds(2);

            DetenerMovimiento(true);
            DetenerMovimiento(false);
            yield return new WaitForSeconds(2);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        switch (collision.collider.tag)
        {
            case "Jugador":
                StartCoroutine(RevertirEmbestir(10));
                estaEmbistiendo = false;
                break;

            case "Piston":
                StartCoroutine(RevertirEmbestir(5));
                estaEmbistiendo = false;
                break;
        }
    }

    IEnumerator RevertirEmbestir(float tiempoEspera)
    {
        DetenerMovimiento(true);
        yield return new WaitForSeconds(tiempoEspera);
        DetenerMovimiento(false);
        estaEmbistiendo = true;
        StartCoroutine(Embestir());
    }
    void DetenerMovimiento(bool valor)
    {
        if (valor)
        {
            persecucionScript.enabled = false;
            supayRbd.velocity = Vector3.zero;
            supayRbd.angularVelocity = Vector3.zero;
            supayRbd.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            navMeshAgent.isStopped = true;
        }

        else
        {
            persecucionScript.enabled = true;
            navMeshAgent.isStopped = false;
            supayRbd.constraints = RigidbodyConstraints.None;

        }

    }
}