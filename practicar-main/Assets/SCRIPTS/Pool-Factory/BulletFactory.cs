using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class BulletFactory : MonoBehaviour,IFactory<Bullet,Vector3,Quaternion>
{
   
    [SerializeField]
    private Bullet prefab;

    

    public  Bullet Create(Vector3 position, Quaternion rotation)
    {
        return  Instantiate(prefab,position,rotation);
        
    }
   
}
