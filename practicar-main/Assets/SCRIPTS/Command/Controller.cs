using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller 
{
    
    Movement _movement;

    Dictionary<KeyCode, ICommandImput> _commandsDictironary;
    
    public Controller(Movement m)
    {
        _movement = m;
        
        _commandsDictironary = new Dictionary<KeyCode, ICommandImput>();
        BindKeyCommand(KeyCode.Space, new Jump(_movement));
        BindKeyCommand(KeyCode.R, new Reload(_movement));
        BindKeyCommand(KeyCode.C, new Shoot(_movement));

        


    }
   public void ArtificialUpDate()
    {
        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        _movement.move(vertical, horizontal);

       var command= HandlerImput();

        command?.execute();
    }




   
    public void BindKeyCommand(KeyCode key,ICommandImput command)
    {
        _commandsDictironary[key] = command;
    }

    public ICommandImput HandlerImput()
    {
        foreach (var pair in _commandsDictironary)
        {
            if(Input.GetKeyDown(pair.Key))
            {
                return pair.Value;
            }
        }
        return null;
    }
}
