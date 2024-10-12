using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonOpciones : SistemaPantallas
{
    protected override void Init()
    {
        base.Init();
        botonOpciones.onClick.AddListener(AccionBoton); // Asigna el método específico
    }

    protected override void AccionBoton()
    {
        ReproducirSonido();
        panelMenu.SetActive(false);
        panelOpciones.SetActive(true);
    }
}
