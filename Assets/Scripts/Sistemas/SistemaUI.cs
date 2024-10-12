using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaUI : MonoBehaviour
{
    public virtual void ActualizarVida(int vida)
    {
        // M�todo virtual para actualizar la vida
    }

    public virtual void ActualizarCordura(float cordura)
    {
        // M�todo virtual para actualizar la cordura
    }

    public virtual void ActualizarMunicion(int municion)
    {
        // M�todo virtual para actualizar la munici�n
    }

    public virtual void ActualizarPiezasTumi(int piezas)
    {
        // M�todo virtual para actualizar las piezas del Tumi
    }

    public virtual void ActualizarResistencia(float resistencia)
    {
        // M�todo virtual para actualizar la resistencia
    }

    public virtual void ActualizarObjetoActual(string objeto)
    {
        // M�todo virtual para actualizar el objeto en uso
    }

    public virtual void ActualizarEstado(string estado)
    {
        // M�todo virtual para actualizar el estado (especialmente para el jefe)
    }

    public virtual void ActualizarDuracion(float duracion)
    {
        // M�todo virtual para actualizar la duraci�n del crucifijo
    }

    public virtual void ActualizarCantidad(int cantidad)
    {
        // M�todo virtual para actualizar la cantidad de crucifijos
    }
}
