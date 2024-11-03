using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool <T>
{
    public bool TryRent(out T value);
    public void Return(T value);
   
    
}
