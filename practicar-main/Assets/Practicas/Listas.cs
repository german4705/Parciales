using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listas : MonoBehaviour
{
    //1. List<T>(Lista Genérica) 
    //La List<T> es la más común de todas las listas en C#. Es una lista de tamaño dinámico, lo que significa que puede crecer o reducirse según sea necesario.

     //Ventajas:

     //Tamaño dinámico.
     //Fácil acceso a elementos por índice.
     //Buena para almacenar y manipular grandes cantidades de datos de manera secuencial.

    List<int> numbers = new List<int>();

    public void ListaGenerica()
    {
        numbers.Add(5);
        numbers.Add(10);
        numbers.Remove(5);

        Debug.Log(numbers.Count); // cantidad: 1
        Debug.Log(numbers[0]); // valor:10

        Debug.Log("Cantidad de elementos: " + numbers.Count);

        //ciclo for
        for (int i = 0; i < numbers.Count; i++)
        {
            Debug.Log("Elemento en la posición " + i + ": " + numbers[i]); //posicion y valor
        }
        // o un foreach
        foreach (int number in numbers)
        {
            Debug.Log("Valor: " + number);
        }
    }

    int[] ArraysNumbers = new int[3];
   public void Arrays()
    {
        ArraysNumbers[0] = 5;
        ArraysNumbers[1] = 10;
        ArraysNumbers[2] = 15;

        Debug.Log(ArraysNumbers.Length);
        Debug.Log(ArraysNumbers[ArraysNumbers.Length - 1]);
    }








}
