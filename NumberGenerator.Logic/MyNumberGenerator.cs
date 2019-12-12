﻿using System;
using System.Threading.Tasks;

namespace NumberGenerator.Logic
{
    public class MyNumberGenerator
    {
        private const int RANDOM_MIN_VALUE = 1;
        private const int RANDOM_MAX_VALUE = 10;
        private const int MSECONDS_TO_SLEEP = 750;

        private readonly int _nrOfGenerations;

        public delegate void NumberChangedHandler(int newNumber);

        public MyNumberGenerator(int nrOfGenerations)
        {
            _nrOfGenerations = nrOfGenerations;
        }

        public void Start()
        {
            Random random = new Random();
            for (int i = 0; i < _nrOfGenerations; i++)
            {
                int newNumber = random.Next(RANDOM_MIN_VALUE, RANDOM_MAX_VALUE + 1);
                OnNewNumber(newNumber);
                Task.Delay(MSECONDS_TO_SLEEP).Wait();
                Console.WriteLine("-----------------------------");
            }
        }

        private void OnNewNumber(int newNumber)
        {
            NumberChanged?.Invoke(newNumber);
        }

        public NumberChangedHandler NumberChanged { get; set;
            
        }
    }
}
