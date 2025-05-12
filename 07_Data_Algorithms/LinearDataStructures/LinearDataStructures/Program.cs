using System;

class Program
{
    static void Main()
    {
        //string of calculator inputs
        string[] inputhistory = { "5 + 3", "10 - 2", "7 * 4", "20 / 5", "3 ^ 2" };
        Console.WriteLine("Original Calulator Input History: ");

        foreach (string input in inputhistory)
        {
            Console.WriteLine(input);
        }

        //Replace element
        inputhistory[1] = "10 / 2";

        //Print updated list
        Console.WriteLine("\nModified Input: ");
        foreach (string input in inputhistory)
        {
            Console.WriteLine(input);
        }

        //Declare and initialize a linked list
        LinkedList<string> results = new LinkedList<string>();
        results.AddLast("Result: 8");
        results.AddLast("Result: 5");
        results.AddLast("Result: 28");
        results.AddLast("Result: 4");
        results.AddLast("Result: 9");

        //Prit Linked List
        Console.WriteLine("\nCaluculator Results: ");
        foreach (string res in results)
        {
            Console.WriteLine(res);
        }

        //Remove and elements
        results.Remove("Result: 5");

        //Pring Updated List
        Console.WriteLine("\nCaluculator Results (Updated): ");
        foreach (string res in results)
        {
            Console.WriteLine(res);
        }

        //Declare and Initialize Stack
        Stack<string> undoHistory = new Stack<string>();
        undoHistory.Push("Entered 5 + 3");
        undoHistory.Push("Entered 10 - 2");
        undoHistory.Push("Entered 7 * 4");
        undoHistory.Push("Entered 20 / 5");
        undoHistory.Push("Entered 3 ^ 2");

        //Print undoHistory Stack
        Console.WriteLine("\nUndoHistory Stack: ");
        foreach (string undo in undoHistory)
        {
            Console.WriteLine(undo);
        }

        //Pop to reome and display most recent action
        Console.WriteLine("\nUndoing Action: " + undoHistory.Pop());
        //Print updated Linked List
        Console.WriteLine("\nUpdated Undo History: ");
        foreach (string undo in undoHistory)
        {
            Console.WriteLine(undo);
        }


        //Queue of pending calculations
        Queue<string> pendingCalculations = new Queue<string>();
        pendingCalculations.Enqueue("Calculate: 15 + 5");
        pendingCalculations.Enqueue("Calculate: 12 - 3");
        pendingCalculations.Enqueue("Calculate: 9 * 2");
        pendingCalculations.Enqueue("Calculate: 16 / 4");
        pendingCalculations.Enqueue("Calculate: 2 ^ 3");

        //Print Calculation Queue
        Console.WriteLine("\nCalculation Queue: ");
        foreach (string pending in pendingCalculations)
        {
            Console.WriteLine(pending);
        }

        //Dequeue an Element
        Console.WriteLine("\nDequeue first element: " + pendingCalculations.Dequeue());

        //Print Updated Calculation Queue
        Console.WriteLine("\nCalculation Queue Updated: ");
        foreach (string pending in pendingCalculations)
        {
            Console.WriteLine(pending);
        }










    }
}