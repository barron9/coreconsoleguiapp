using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ThreadWithState
    {
        // State information used in the task.
        private string boilerplate;
        private int value;

        // The constructor obtains the state information.
        public ThreadWithState(string text, int number)
        {
            boilerplate = text;
            value = number;
        }

        // The thread procedure performs the task, such as formatting
        // and printing a document.
        public void ThreadProc()
        {
            Console.WriteLine(boilerplate, value);
        }
    }

}
