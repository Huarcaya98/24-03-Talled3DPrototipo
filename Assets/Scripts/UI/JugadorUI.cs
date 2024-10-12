using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JugadorUI : SistemaUI
{
    public Slider barraVida;
    public Slider barraCordura;
    public Slider barraResistencia;
    public TextMeshProUGUI textoMunicion;
    public TextMeshProUGUI textoPiezasTumi;
    public TextMeshProUGUI textoObjetoActual;

    public override void ActualizarVida(int vida)
    {
        barraVida.value = vida;
    }

    public override void ActualizarCordura(float cordura)
    {
        barraCordura.value = cordura;
    }

    public override void ActualizarResistencia(float resistencia)
    {
        barraResistencia.value = resistencia;
    }

    public override void ActualizarMunicion(int municion)
    {
        textoMunicion.text = "Munición: " + municion;
    }

    public override void ActualizarPiezasTumi(int piezas)
    {
        textoPiezasTumi.text = "Piezas del Tumi: " + piezas + "/4";
    }

    public override void ActualizarObjetoActual(string objeto)
    {
        textoObjetoActual.text = "Objeto en uso: " + objeto;
    }
}
