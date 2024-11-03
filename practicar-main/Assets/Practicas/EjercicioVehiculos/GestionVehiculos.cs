using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionVehiculos : MonoBehaviour
{

   public void IniciarVehiculo(IVehiculos vehiculo)
    {
        vehiculo.Arrancar();
    }


    public void DetenerVechiculo(IVehiculos vehiculo)
    {
        vehiculo.Detenerse();
    }

    
    public void ReponerCombustible(IVehiculos vehiculo)
    {
        if(vehiculo is ICombustible vehiculoConCombustible)
        {
            vehiculoConCombustible.Reponer();
        }
        else
        {
            Debug.Log("El vehiculo no necesita reponer");
        }
        
    }    


}
