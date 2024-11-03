using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory <TResult,T1,T2>
{
    public TResult Create(T1 arg1, T2 arg2);
}
