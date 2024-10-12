using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JefeUI : SistemaUI
{
    public Slider barraVidaJefe;
    public TextMeshProUGUI textoEstadoJefe;

    public override void ActualizarVida(int vida)
    {
        barraVidaJefe.value = vida;
    }

    public override void ActualizarEstado(string estado)
    {
        textoEstadoJefe.text = "Estado del Jefe: " + estado;
    }
}
