using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : ICommandImput
{
    Movement _movement;

    public Jump(Movement c)
    {
        _movement = c;
    }

    public void execute()
    {
        _movement.Jump();
    }

    
}
