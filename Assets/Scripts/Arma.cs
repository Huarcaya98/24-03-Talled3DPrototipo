using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform camara;    // La c�mara en primera persona
    public Vector3 offset = new Vector3(0.5f, -0.5f, 1f);    // Ajuste de posici�n para que la escopeta est� en el lugar correcto


    void Update()
    {
        AliniearArma();
    }

    protected virtual void AliniearArma()
    {

    }
}
