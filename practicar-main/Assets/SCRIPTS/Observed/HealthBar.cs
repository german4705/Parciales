using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour,IObserver
{
    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private EnemyLIfe boss;



    public void Notify()
    {
        healthBar.fillAmount = (float)boss.CurrentHealth / boss.MaxHealth;
    }

    private void Awake()
    {

        boss.LifeHandle.Subscribe(this);
    }

}
