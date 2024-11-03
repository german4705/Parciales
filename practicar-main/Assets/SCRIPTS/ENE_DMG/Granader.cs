using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granader : MonoBehaviour,IDamageable
{
    public int life;
    [SerializeField] private int dmg;
    public void GetDamage()
    {
        life -= dmg;

        if(life<=0)
        {
            Destroy(gameObject, 3f);
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
