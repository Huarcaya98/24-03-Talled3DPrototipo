using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float velocidadMovimiento = 5f;  // Velocidad de movimiento
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;  // Evita que el Rigidbody rote por la física
    }

    void Update()
    {
        // Entrada de movimiento en los ejes X y Z
        float movimientoHorizontal = Input.GetAxis("Horizontal");  // A/D o Flechas Izquierda/Derecha
        float movimientoVertical = Input.GetAxis("Vertical");      // W/S o Flechas Arriba/Abajo

        // Crear un vector de movimiento basado en la entrada del usuario
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical).normalized;

        // Aplicar movimiento al Rigidbody
        rb.MovePosition(transform.position + movimiento * velocidadMovimiento * Time.deltaTime);
    }
}
