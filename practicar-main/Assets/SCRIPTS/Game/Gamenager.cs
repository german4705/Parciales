using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager :MonoBehaviour
{
  public static Gamemanager Instance; // todo igual salvo que aca hago una variable estatica con referencia a mi mismo

    [SerializeField] private int CurrentPoints;
    private void Awake()
    {
        if(Gamemanager.Instance!=null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
   
    public void AddPoints(int points)
    {
        CurrentPoints += points;
    }



}
