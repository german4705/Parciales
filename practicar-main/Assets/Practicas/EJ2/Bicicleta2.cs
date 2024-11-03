using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicicleta2 : MonoBehaviour, IMovible
{
    public void Detenerse()
    {
        Debug.Log("La bicicleta se detuvo");
       
    }

    public void Moverse()
    {
        transform.position += transform.right * Time.deltaTime;
       
        
            Debug.Log("la bicicleta se mueve");
        
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
