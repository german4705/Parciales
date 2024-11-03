using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactoryManager : MonoBehaviour
{
    private static BulletFactoryManager Instance;
    [SerializeField]
    private BulletFactory EnemyFactory;
    private Pool<Bullet> RegularPool = new Pool<Bullet>();

    [SerializeField]
    private BulletFactory Playerfactory;
    private Pool<Bullet> FirePool= new Pool<Bullet>();

    private void Awake()
    {
        Instance = this;

    }
    public enum BulletTypes
    {
        Regular,
        Fire
    }

    public static IFactory<Bullet,Vector3,Quaternion> GetFactoryOf(BulletTypes type)
    {
         switch (type)
        {
            case BulletTypes.Regular:
                return Instance.EnemyFactory;
                     case BulletTypes.Fire:
                return Instance.Playerfactory;
                    default: return  null;
        }
    }

    public static IPool<Bullet> GetPool(BulletTypes type)
    {
        switch (type)
        {
            case BulletTypes.Regular:
                return Instance.RegularPool;
            case BulletTypes.Fire:
                return Instance.FirePool;
            default: return null;
        }
    }
}
