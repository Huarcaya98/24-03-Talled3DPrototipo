using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrucifijoUI : SistemaUI
{
    public Slider barraDuracionCrucifijo;
    public TextMeshProUGUI textoCantidadCrucifijos;

    public override void ActualizarDuracion(float duracion)
    {
        barraDuracionCrucifijo.value = duracion;
    }

    public override void ActualizarCantidad(int cantidad)
    {
        textoCantidadCrucifijos.text = "Crucifijos: " + cantidad;
    }
}
