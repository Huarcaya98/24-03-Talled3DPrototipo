using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonRegresar : SistemaPantallas
{
    protected override void Init()
    {
        base.Init();
        botonRegresar.onClick.AddListener(AccionBoton); // Asigna el m�todo espec�fico
    }

    protected override void AccionBoton()
    {
        ReproducirSonido();
        panelMenu.SetActive(true);
        panelOpciones.SetActive(false);
    }
}
