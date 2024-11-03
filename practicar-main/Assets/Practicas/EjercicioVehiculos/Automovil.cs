using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automomovil : MonoBehaviour, IVehiculos,ICombustible
{
    public void Arrancar()
    {
        Debug.Log("El auto arranco");
    }

    public void Detenerse()
    {
        Debug.Log("El auto se detuvo");
    }

    public void Reponer()
    {
        Debug.Log("El auto paro a cargar combustible");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
