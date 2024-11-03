using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserved 
{
    public void Subscribe(IObserver observer);

    public void UnSubscribe(IObserver observer);


}
