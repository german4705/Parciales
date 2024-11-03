using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automovil : MonoBehaviour,IMovible
{
    public void Detenerse()
    {
        Debug.Log("el auto se detuvo");
      
    }

    public void Moverse()
    {
        transform.position += transform.right * Time.deltaTime;
        Debug.Log("el auto se mueve");
        
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
