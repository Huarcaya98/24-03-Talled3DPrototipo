using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMovimiento : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField] protected float velocidadPadre;

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
    }

    protected virtual void Move()
    {
        // M�todo virtual que ser� sobreescrito en las clases hijas
    }
}
