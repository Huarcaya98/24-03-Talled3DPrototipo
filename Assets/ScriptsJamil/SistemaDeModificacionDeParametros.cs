using TMPro;
using UnityEngine;

public class SistemaDeModificacionDeParametros : MonoBehaviour
{
  
    public JugadorMovimiento scriptJugador;
    public TextMeshProUGUI textoVelocidad;
    public TextMeshProUGUI textoSensibilidad;

    void Start()
    {
        ActualizarTextoVelocidad();
        //ActualizarTextoSensibilidad();
        //textoSensibilidad.text = scriptCamara.GetComponent<FPScamera>().sensibilidad.x.ToString();
        textoVelocidad.text = scriptJugador.GetComponent<JugadorMovimiento>().velocidadMovimiento.ToString();
    }

    public void AumentarVelocidad()
    {
        ModificarValoresJugador(0.5f);
        ActualizarTextoVelocidad();
    }

    public void DisminuirVelocidad()
    {
        ModificarValoresJugador(-0.5f);
        ActualizarTextoVelocidad();
    }

    public void AumentarSensibilidad()
    {
        ModificarValoresCamara(Vector2.one / 2);
        //ActualizarTextoSensibilidad();
    }

    public void DisminuirSensibilidad()
    {
        ModificarValoresCamara(-Vector2.one / 2);
        //ActualizarTextoSensibilidad();
    }

    public void ModificarValoresCamara(Vector2 cambio)
    {
        //if (scriptCamara != null)
        //{
        //    var camara = scriptCamara.GetComponent<FPScamera>();
        //    camara.sensibilidad += cambio;
        //    camara.sensibilidad = new Vector2(Mathf.Max(camara.sensibilidad.x, 1.5f), Mathf.Max(camara.sensibilidad.y, 1.5f)); // Restringir a valores mínimos de 1.5
        //}
    }

    public void ModificarValoresJugador(float cambio)
    {
        if (scriptJugador != null)
        {
            var jugador = scriptJugador.GetComponent<personaje_movimiento>();
            jugador.speed += cambio;
            jugador.speed = Mathf.Max(jugador.speed, 0.5f);
        }
    }

    void ActualizarTextoVelocidad()
    {
        if (textoVelocidad != null && scriptJugador != null)
        {
            float velocidadActual = scriptJugador.GetComponent<JugadorMovimiento>().velocidadMovimiento;
            textoVelocidad.text = velocidadActual.ToString();
        }
    }

    //void ActualizarTextoSensibilidad()
    ////{
    ////    if (textoSensibilidad != null && scriptCamara != null)
    ////    {
    ////        Vector2 sensibilidadActual = scriptCamara.GetComponent<FPScamera>().sensibilidad;
    ////        textoSensibilidad.text = sensibilidadActual.x.ToString();
    ////    }
    //}
}
