using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : Disparo
{
    [SerializeField] private GameObject PrefabBala;
    [SerializeField] private Transform ShootPoint;
    public float fuerzaDisparo = 20f;
    public float tiempoRecarga = 1f;  // Tiempo de recarga entre disparos
    private float proximoDisparo = 0f;  // Tiempo en el que se puede disparar de nuevo

    protected override void Disparar()
    {
        // Comprobar si ha pasado suficiente tiempo desde el último disparo
        if (Time.time >= proximoDisparo)
        {
            // Instanciar la bala en el punto de disparo
            GameObject balaObj = Instantiate(PrefabBala, ShootPoint.position, Quaternion.identity);

            // Obtener el componente Bala (o BalaPlayer) y establecer la dirección
            Bala bala = balaObj.GetComponent<Bala>();
            bala.SetDirection(ShootPoint.forward);  // Establecer la dirección hacia adelante desde el ShootPoint

            // Obtener el Rigidbody de la bala y aplicar la fuerza de disparo
            Rigidbody rb = balaObj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(ShootPoint.forward * fuerzaDisparo, ForceMode.Impulse);
            }

            // Destruir la bala después de 3 segundos
            Destroy(balaObj, 3f);

            // Actualizar el tiempo para el próximo disparo
            proximoDisparo = Time.time + tiempoRecarga;
        }
    }
}