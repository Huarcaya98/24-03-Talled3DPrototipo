using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaUI : MonoBehaviour
{
    public virtual void ActualizarVida(int vida)
    {
        // Método virtual para actualizar la vida
    }

    public virtual void ActualizarCordura(float cordura)
    {
        // Método virtual para actualizar la cordura
    }

    public virtual void ActualizarMunicion(int municion)
    {
        // Método virtual para actualizar la munición
    }

    public virtual void ActualizarPiezasTumi(int piezas)
    {
        // Método virtual para actualizar las piezas del Tumi
    }

    public virtual void ActualizarResistencia(float resistencia)
    {
        // Método virtual para actualizar la resistencia
    }

    public virtual void ActualizarObjetoActual(string objeto)
    {
        // Método virtual para actualizar el objeto en uso
    }

    public virtual void ActualizarEstado(string estado)
    {
        // Método virtual para actualizar el estado (especialmente para el jefe)
    }

    public virtual void ActualizarDuracion(float duracion)
    {
        // Método virtual para actualizar la duración del crucifijo
    }

    public virtual void ActualizarCantidad(int cantidad)
    {
        // Método virtual para actualizar la cantidad de crucifijos
    }
}
