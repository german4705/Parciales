using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour, IDamageable
{
   

    public int life;
    [SerializeField] private int dmg;

   
   
    public void GetDamage()
    {
        life -= dmg;
        if (life <= 0)
        {
            Destroy(gameObject, 3f);
        }
    }

    
}
