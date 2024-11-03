using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : IPool<T> 
{
    private Stack<T> stack = new Stack<T>();

    public void Return(T value)
    {
        stack.Push(value);
    }

    public bool TryRent(out T value)
    {
        return stack.TryPop(out value);
    }
}
