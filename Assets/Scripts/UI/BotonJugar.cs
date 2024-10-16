using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : SistemaPantallas
{
    protected override void Init()
    {
        base.Init();
        botonJugar.onClick.AddListener(AccionBoton); // Asigna el método específico
    }

    protected override void AccionBoton()
    {
        ReproducirSonido();
        SceneManager.LoadScene("Nivel 1");
    }
}
