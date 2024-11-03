using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public MonoBehaviour vehiculo;
    private IMovible vehiculoMovible;

    void Start()
    {
        vehiculoMovible = vehiculo as IMovible; // aca digo que la interfaz es el script que contenga la interfaz IMovile;

    }

    // Update is called once per frame
    void Update()
    {
        // Si se está presionando la tecla "W", mover el vehículo
        if (Input.GetKey(KeyCode.W))
        {
            vehiculoMovible.Moverse();
        }

        // Si se suelta la tecla "W", detener el vehículo
        if (Input.GetKeyUp(KeyCode.W))
        {
            vehiculoMovible.Detenerse();
        }
    }
}
