using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLIfe : MonoBehaviour
{
    [SerializeField]
    private LifeHandle lifeHandle;

    public int CurrentHealth => lifeHandle.CurrentHealth;

    public int MaxHealth => lifeHandle.MaxHealth;

    public IObserved LifeHandle => lifeHandle;


    public void Start()
    {
        lifeHandle.Initialize();
    }
   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            lifeHandle.TakeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            lifeHandle.TakeHealing(5);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            lifeHandle.TakeDamage(5);
            Debug.Log("daño enemigo");
        }
    }
}
