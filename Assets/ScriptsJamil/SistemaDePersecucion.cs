using UnityEngine;
using UnityEngine.AI;

public class SistemaDePersecucion : MonoBehaviour
{
    private Transform objetivo;
    private NavMeshAgent perseguidor;


    public SistemaDePersecucion(Transform objetivo, NavMeshAgent perseguidor)
    {
        this.objetivo = objetivo;
        this.perseguidor = perseguidor;
    }
    void Start()
    {
        perseguidor = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Perseguir();
    }

    public virtual void Perseguir() { return; }

}
