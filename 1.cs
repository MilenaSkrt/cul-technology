using System;

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();
        DynamicArray dynamicArray = new DynamicArray();

        linkedList.Add(1);
        linkedList.Add(2);
        linkedList.Add(3);

        Console.WriteLine("Связанный список:");
        linkedList.PrintList();

        dynamicArray.Add(1);
        dynamicArray.Add(2);
        dynamicArray.Add(3);

        Console.WriteLine("\nДинамический массив:");
        dynamicArray.PrintArray();

        // Удаление элемента
        Console.WriteLine("\nУдаление элемента '2' из связанного списка:");
        linkedList.Remove(2);
        linkedList.PrintList();

        Console.WriteLine("\nУдаление элемента '2' из динамического массива:");
        dynamicArray.Remove(2);
        dynamicArray.PrintArray();

        // Поиск элемента
        Console.WriteLine("\nПоиск элемента '3' в связанном списке:");
        Node searchResult1 = linkedList.Find(3);
        if (searchResult1 != null)
        {
            Console.WriteLine("Элемент найден!");
        }
        else
        {
            Console.WriteLine("Элемент не найден.");
        }

        Console.WriteLine("\nПоиск элемента '3' в динамическом массиве:");
        int searchResult2 = dynamicArray.Find(3);
        if (searchResult2 != -1)
        {
            Console.WriteLine("Элемент найден на позиции {0}!", searchResult2);
        }
        else
        {
            Console.WriteLine("Элемент не найден.");
        }

        // Подсчет количества элементов по условию
        Console.WriteLine("\nПодсчет количества элементов, равных '1', в связанном списке:");
        int count1 = linkedList.CountElements(x => x == 1);
        Console.WriteLine("Количество элементов: {0}", count1);

        Console.WriteLine("\nПодсчет количества элементов, равных '1', в динамическом массиве:");
        int count2 = dynamicArray.CountElements(x => x == 1);
        Console.WriteLine("Количество элементов: {0}", count2);
    }
}

public class LinkedList
{
    private Node head;

    public void Add(int value)
    {
        if (head == null)
        {
            head = new Node(value);
        }
        else
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(value);
        }
    }

    public void Remove(int value)
    {
        if (head == null)
        {
            return;
        }

        if (head.Value == value)
        {
            head = head.Next;
            return;
        }

        Node current = head;
        Node prev = null;
        while (current != null)
        {
            if (current.Value == value)
            {
                prev.Next = current.Next;
                return;
            }

            prev = current;
            current = current.Next;
        }
    }

    public Node Find(int value)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Value == value)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }

    public int CountElements(Func<int, bool> condition)
    {
        int count = 0;
        Node current = head;
        while (current != null)
        {
            if (condition.Invoke(current.Value))
            {
                count++;
            }
            current = current.Next;
        }
        return count;
    }

    public void PrintList()
    {
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }

    public Node(int value)
    {
        Value = value;
    }
}

public class DynamicArray
{
    private int[] array;
    private int length;

    public DynamicArray()
    {
        array = new int[1];
        length = 0;
    }

    public void Add(int value)
    {
        if (length == array.Length)
        {
            Array.Resize(ref array, array.Length * 2);
        }
        array[length] = value;
        length++;
    }

    public void Remove(int value)
    {
        int index = Array.IndexOf(array, value);
        if (index == -1)
        {
            return;
        }

        for (int i = index; i < length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        length--;
    }

    public int Find(int value)
    {
        return Array.IndexOf(array, value);
    }

    public int CountElements(Func<int, bool> condition)
    {
        int count = 0;
        for (int i = 0; i < length; i++)
        {
            if (condition.Invoke(array[i]))
            {
                count++;
            }
        }
        return count;
    }

    public void PrintArray()
    {
        for (int i = 0; i < length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
