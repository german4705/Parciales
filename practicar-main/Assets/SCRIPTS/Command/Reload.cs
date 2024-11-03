using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : ICommandImput
{
    Movement _movement;

    public Reload(Movement m)
    {
        _movement = m;
    }
    public void execute()
    {
        _movement.reload();
    }
}
