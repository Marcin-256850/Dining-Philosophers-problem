using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFilosophersProblem
{

    class Program
    {
        static void Main(string[] args)
        {
            const int numPhilosophers = 5;
            var philosophers = new Philosopher[numPhilosophers];
            var forks = new Fork[numPhilosophers];

            // Inicjalizacja widelców
            for (int i = 0; i < numPhilosophers; i++)
            {
                forks[i] = new Fork(i);
            }

            // Inicjalizacja filozofów
            for (int i = 0; i < numPhilosophers; i++)
            {
                philosophers[i] = new Philosopher(i, forks[i], forks[(i + 1) % numPhilosophers]);
            }

            // Uruchomienie wątków filozofów
            var threads = new Thread[numPhilosophers];
            for (int i = 0; i < numPhilosophers; i++)
            {
                threads[i] = new Thread(new ThreadStart(philosophers[i].Run));
                threads[i].Start();
            }


            // Oczekiwanie na zakończenie pracy wątków filozofów
            for (int i = 0; i < numPhilosophers; i++)
            {
                threads[i].Join();
            }

            int n = int.Parse(Console.ReadLine());

            Fork fork = new Fork();
            fork.start(n);

        }
    }


}






