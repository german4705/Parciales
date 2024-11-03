using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBus : MonoBehaviour, IVehiculos,ICombustible
{
    public void Arrancar()
    {
        Debug.Log("El auto bus arranco");
    }

    public void Detenerse()
    {
        Debug.Log("El auto bus se detuvo");
    }

    public void Reponer()
    {
        Debug.Log("El auto bus cargo combustible");
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
