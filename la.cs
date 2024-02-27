using System;

class Node //класс Node для представления элемента односвязного списка
{
    public int data; // данные элемента
    public Node next; // указатель на следующий элемент

    public Node(int data) // конструктор класса Node, инициализирует данные и указатель
    {
        {
        this.data = data;
        this.next = null;
    }
}

class LinkedList  // класс LinkedList для работы с односвязным списком
    {
    private Node head; // указатель на начало списка (голову)

        public LinkedList() // конструктор класса LinkedList, инициализирует голову списка
        {
        head = null;
    }

    public void AddElement(int data) // метод для добавления элемента в конец списка
        {
            {
        Node newNode = new Node(data); // создание нового элемента

                if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newNode;
        }
        Console.WriteLine("Element {0} added successfully.", data);
    }

    public void DeleteElement(int data) // метод для удаления элемента из списка
                {
        Node current = head;
        Node previous = null;

        while (current != null && current.data != data)
        {
            previous = current;
            current = current.next;
        }

        if (current == null)
        {
            Console.WriteLine("Element not found.");
            return;
        }

        if (previous == null)
        {
            head = current.next;
        }
        else
        {
            previous.next = current.next;
        }

        Console.WriteLine("Element {0} deleted successfully.", data);
    }

    public void FindElement(int data) // метод для поиска элемента в списке
            {
        Node current = head;
        while (current != null)
        {
            if (current.data == data)
            {
                Console.WriteLine("Element {0} found.", data);
                return;
            }
            current = current.next;
        }

        Console.WriteLine("Element not found.");
    }

    public void CountElements(int condition) // метод для подсчета элементов, соответствующих определенному условию
            {
                {
        int count = 0;
        Node current = head;
        while (current != null)
        {
            if (current.data > condition) // условие для подсчета элементов
            {
                count++;
            }
            current = current.next;
        }

        Console.WriteLine("Number of elements meeting the condition: {0}", count);
    }
}

class Program // класс Program для запуска программы
        {
    static void Main()  // метод Main, точка входа в программу
            {
        LinkedList list = new LinkedList(); // создание экземпляра списка LinkedList

                list.AddElement(5); // добавление элемента со значением 5
                list.AddElement(10); // добавление элемента со значением 10
                list.AddElement(15); // добавление элемента со значением 15

                list.FindElement(10); // поиск элемента со значением 10

                list.DeleteElement(10); // удаление элемента со значением 10
                list.FindElement(10); // проверка наличия удаленного элемента

                list.CountElements(7); // Подсчитать количество элементов, значение которых больше 7
    }
}
