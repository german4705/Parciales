using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHandle : MonoBehaviour, IObserved
{
   [SerializeField] 
    private int maxHealth;
    public int MaxHealth => maxHealth;

    public int CurrentHealth { get; private set; }

    private List<IObserver> observers = new List<IObserver>();
    public void Initialize()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int dmg)
    {
        CurrentHealth -= dmg;
        NotifyAll();
    }

    public void TakeHealing(int healing)
    {
        CurrentHealth += healing;
        NotifyAll();
    }

    private void NotifyAll()
    {
        for (int i = observers.Count-1;i>=0 ; i--) //vamos del ultimo a 0 de la lista, notificando
        {
            IObserver observer = observers[i];
            observer.Notify();
        }
    }
    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnSubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }
}
