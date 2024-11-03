using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torret : MonoBehaviour,IDamageable
{

   [SerializeField] private int life;
   [SerializeField] private int dmg;
   [SerializeField] private int Points;
    public void GetDamage()
    {
        life -= dmg;
        if (life <= 0)
        {
            
            Gamemanager.Instance.AddPoints(Points);
            Destroy(gameObject);
        }
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
