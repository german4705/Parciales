using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : ICommandImput
{
    Movement _movemment;

    public Shoot(Movement m)
    {
        _movemment = m;
    }
    public void execute()
    {
        _movemment.Shoot();
    }
}
