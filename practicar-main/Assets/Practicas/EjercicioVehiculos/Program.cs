using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program2 : MonoBehaviour
{
    public  static void Main()
    {
        IVehiculos automovil = new Automomovil();
        IVehiculos autobus = new AutoBus();
        IVehiculos bicicleta = new Bicicleta();
        

        GestionVehiculos gestion = new GestionVehiculos();


        gestion.IniciarVehiculo(automovil);
        gestion.DetenerVechiculo(automovil);
        gestion.ReponerCombustible(automovil);

        gestion.IniciarVehiculo(autobus);
        gestion.DetenerVechiculo(autobus);

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
