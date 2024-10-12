using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoPlayer : Disparo
{
    [SerializeField] private GameObject PrefabBala;
    [SerializeField] private Transform ShootPoint;
    public float fuerzaDisparo = 20f;

    protected override void Disparar()
    {
        // Instanciar la bala en el punto de disparo
        GameObject balaObj = Instantiate(PrefabBala, ShootPoint.position, Quaternion.identity);

        // Obtener el componente Bala (o BalaPlayer) y establecer la direcci�n
        Bala bala = balaObj.GetComponent<Bala>();
        bala.SetDirection(ShootPoint.forward);  // Establecer la direcci�n hacia adelante desde el ShootPoint

        // Destruir la bala despu�s de 3 segundos
        Destroy(balaObj, 3f);
    }

}
