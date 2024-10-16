using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonRegresar : SistemaPantallas
{
    protected override void Init()
    {
        base.Init();
        botonRegresar.onClick.AddListener(AccionBoton); // Asigna el método específico
    }

    protected override void AccionBoton()
    {
        ReproducirSonido();
        panelMenu.SetActive(true);
        panelOpciones.SetActive(false);
    }
}
