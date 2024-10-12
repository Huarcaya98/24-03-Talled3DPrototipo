using TMPro;
using UnityEngine;

public class SistemaDeModificacionDeParametros : MonoBehaviour
{
  
    public Jugador scriptJugador;
    public PPCamara scriptCamara;
    public TextMeshProUGUI textoVelocidad;
    public TextMeshProUGUI textoSensibilidad;
    public float cambioDeVelocidad=0;
    public Vector2 cambioDeSensibilidad= Vector2.one / 2;

    void Start()
    {
        ActualizarTextoVelocidad();
        ActualizarTextoSensibilidad();
        textoSensibilidad.text = scriptCamara.GetComponent<PPCamara>().sensibilidad.x.ToString();
        textoVelocidad.text = scriptJugador.GetComponent<Jugador>().velocidad.ToString();
    }

    public void AumentarVelocidad()
    {
        cambioDeVelocidad += 0.5f;
        //ModificarValoresJugador(cambioDeVelocidad);
        ActualizarTextoVelocidad();
    }

    public void DisminuirVelocidad()
    {
        cambioDeVelocidad -= 0.5f;
        //ModificarValoresJugador(-cambioDeVelocidad);
        ActualizarTextoVelocidad();
    }

    public void AumentarSensibilidad()
    {
        ModificarValoresCamara(cambioDeSensibilidad);
        ActualizarTextoSensibilidad();
    }

    public void DisminuirSensibilidad()
    {
        ModificarValoresCamara(-cambioDeSensibilidad);
        ActualizarTextoSensibilidad();
    }

    public void ModificarValoresCamara(Vector2 cambio)
    {
        if (scriptCamara != null)
        {
            var camara = scriptCamara.GetComponent<PPCamara>();
            camara.sensibilidad += cambio;
            camara.sensibilidad = new Vector2(Mathf.Max(camara.sensibilidad.x, 1.5f), Mathf.Max(camara.sensibilidad.y, 1.5f)); // Restringir a valores mínimos de 1.5
        }
    }

    //public void ModificarValoresJugador(float cambio)
    //{
    //    if (scriptJugador != null)
    //    {
    //        var jugador = scriptJugador.GetComponent<Jugador>();
    //        jugador.velocidad += cambio;
    //        jugador.velocidad = Mathf.Max(jugador.velocidad, 0.5f);
    //    }
    //}

    void ActualizarTextoVelocidad()
    {
        if (textoVelocidad != null && scriptJugador != null)
        {
            float velocidadActual = scriptJugador.GetComponent<Jugador>().velocidad;
            textoVelocidad.text = velocidadActual.ToString();
        }
    }

    void ActualizarTextoSensibilidad()
    {
        if (textoSensibilidad != null && scriptCamara != null)
        {
            Vector2 sensibilidadActual = scriptCamara.GetComponent<PPCamara>().sensibilidad;
            textoSensibilidad.text = sensibilidadActual.x.ToString();
        }
    }
}
