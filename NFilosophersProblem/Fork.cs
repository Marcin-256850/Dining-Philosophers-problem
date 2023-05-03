using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NFilosophersProblem

{
    public class Fork
    {
        public int id { get; set; }
        public bool inUse = false;

{   
    
    internal class Fork
    {

        static Mutex mutex = new Mutex();
        public int ForkID;
        List<Fork> forks = new List<Fork>();
        List<Philosopher> circle = new List<Philosopher>();
        bool isPicked = false; //na poczatku polozony


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

            Thread[] threads = new Thread[n];
            
            for (int i = 0; i < n; i++)
            {

                threads[i] = new Thread(() => think_eat(i, forks));
                //threads[i].Start(i);
                
                circle.Add(new Philosopher { ID = i });
                forks.Add(new Fork { ForkID =i });

            }
        }
        public void think_eat(int id, List<Fork> forks)
        {
           while (true)
               
            {
                
                if (id%2==0) {
                    acquireright(id);
                    acquireleft(id);

                }
                else if(circle.Count % 2 == 1)
                {
                    acquireleft(id); 
                    acquireright(id);

                }

                if (circle[id].leftFork == true && circle[id].rightFork == true)
                {
                    Console.WriteLine("Philosopher %d is eating...", id);
                    Thread.Sleep(2);
                    Console.WriteLine("Philosopher %d finished eating", id);
                    forks[id].release();
                    Console.WriteLine("Forks being released", id);

                }
                else { Console.WriteLine("Philosopher %d is thinking", id); }
            }
                    


        }
        public void acquireleft(int num)
        {
            mutex.WaitOne();
            if (forks[num].isPicked == false)
            {
                forks[num].isPicked = true;
                circle[num].leftFork = true;
            }
            mutex.ReleaseMutex();
        }
        
        
        // dodaj ochrone przed wyjsciem poza liste !!
        
        public void acquireright(int num)
        {
            mutex.WaitOne();
            if (forks[num].isPicked==false)
            {
                circle[num - 1].rightFork = true;
                forks[num].isPicked = true;
            }
            mutex.ReleaseMutex();

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



    public class Philosopher { 
        public int ID { get; set; }
        public  bool rightFork = false;
        public bool leftFork = false;
        bool isHungy = true;

    }
}



