using UnityEngine;
using UnityEngine.AI;

public class SupayPersecucion : SistemaDePersecucion
{
    public Transform objetivo;
    private NavMeshAgent enemigo;

    SupayPersecucion(Transform jugador, NavMeshAgent enemigo) : base(jugador, enemigo)
    {
        this.objetivo = jugador;
        this.enemigo = enemigo;
    }

    void Start()
    {
        enemigo = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
    }

    public override void Perseguir()
    {
        enemigo.SetDestination(objetivo.position);
    }
}
