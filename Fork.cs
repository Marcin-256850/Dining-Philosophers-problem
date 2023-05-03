using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;


namespace NFilosophersProblem
{
    public class Fork
    {
        public int id { get; set; }
        public bool inUse = false;

        public Fork (int id)
        {
            this.id = id;
        }
        public bool PickUp()
        {
            lock (this) // blokada dostępu do obiektu Fork
            {
                if (this.inUse == false)
                {
                    this.inUse = true;
                    return true;
                }
                else {
                    this.inUse = true;
                    return false; 
                }
            }
        }

        public void PutDown()
        {
            
            {
                inUse = false;
            }
        }
    }

    public class Philosopher
    {
        public int ID { get; set; }
        public Fork leftFork; //{ get; set; }
        public Fork rightFork; //{ get; set; }

        public Philosopher(int id, Fork leftFork, Fork rightFork)
        {
            this.ID = id;
            this.leftFork = leftFork;
            this.rightFork = rightFork;
        }

        public void Run()
        {

            while (true)
            {
                // Próba podniesienia lewego widelca
                if (ID % 2 == 1)
                {
                    if (leftFork.PickUp())
                    {

                        Console.WriteLine($"Philosopher {ID} picked up left fork");

                        // Próba podniesienia prawego widelca
                        
                        if (rightFork.PickUp())
                        {
                            Console.WriteLine($"Philosopher {ID} picked up right fork");

                            // Filozof je posiłek
                            Console.WriteLine($"Philosopher {ID} is eating");
                            Thread.Sleep(4000);

                            // Odłożenie prawego widelca
                            rightFork.PutDown();
                            Console.WriteLine($"Philosopher {ID} put down right fork");

                            // Odłożenie lewego widelca
                            leftFork.PutDown();
                            Console.WriteLine($"Philosopher {ID} put down left fork");

                            // Przerwa przed kolejnym posiłkiem
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            // Jeśli nie udało się podnieść prawego widelca, odłożenie lewego widelca
                            leftFork.PutDown();
                            
                            Console.WriteLine($"Philosopher {ID} put down left fork");

                            // Przerwa przed kolejną próbą
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        // Przerwa przed kolejną próbą
                        Console.WriteLine($"Philosopher {ID} is thinking...");
                        Thread.Sleep(1000);
                    }
                } else
                {
                    if (rightFork.PickUp())
                    {

                        Console.WriteLine($"Philosopher {ID} picked up right fork");

                        // Próba podniesienia prawego widelca
                        
                        if (leftFork.PickUp())
                        {
                            Console.WriteLine($"Philosopher {ID} picked up left fork");

                            // Filozof je posiłek
                            Console.WriteLine($"Philosopher {ID} is eating");
                            Thread.Sleep(4000);

                            // Odłożenie prawego widelca
                            rightFork.PutDown();
                            Console.WriteLine($"Philosopher {ID} put down right fork");

                            // Odłożenie lewego widelca
                            leftFork.PutDown();
                            Console.WriteLine($"Philosopher {ID} put down left fork");

                            // Przerwa przed kolejnym posiłkiem
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            // Jeśli nie udało się podnieść prawego widelca, odłożenie lewego widelca

                            rightFork.PutDown();
                            Console.WriteLine($"Philosopher {ID} put down right fork");

                            // Przerwa przed kolejną próbą
                            Thread.Sleep(1000);
                        }
                    }
                    else
                    {
                        // Przerwa przed kolejną próbą
                        Console.WriteLine($"Philosopher {ID} is thinking...");
                        Thread.Sleep(1000);
                    }
                }
            }
        }


    }
}



