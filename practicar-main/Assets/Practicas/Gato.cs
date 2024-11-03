using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gato : MonoBehaviour, IAnimal
{
    public void hablar()
    {
        Debug.Log("Miauu");
    }
}

public class Loro: MonoBehaviour, IAnimal
{
    public void hablar()
    {
        Debug.Log("Que mira bobo");
    }
}
public class Perro: IAnimal
{
    public void hablar()
    {
        Debug.Log("Guauu");
    }
}

public interface IAnimal
{
    public void hablar();
    

    
}

public class conversaciones
{
    public void HacerHablar(IAnimal animal)
    {
        animal.hablar();
    }
}

public class Program
{
    public void main()
    {
        IAnimal Perro = new Perro();
        IAnimal gato = new Gato();
        IAnimal loro = new Loro();

        conversaciones conversacion = new conversaciones();

        conversacion.HacerHablar(Perro);
        conversacion.HacerHablar(gato);
        conversacion.HacerHablar(loro);
    }
    
}
