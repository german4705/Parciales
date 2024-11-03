using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSaver : MonoBehaviour
{
    [SerializeField]
    private Player player;
    private Player.Memento? playermemento; // permite a las variables tner un valor null 


    public void Update()
    {

        
        
        if(player.healt==0 && playermemento.HasValue)
        {
           
            player.RestoreMemento(playermemento.Value);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
            playermemento = player.CreateMemento();
        }
    }


}
