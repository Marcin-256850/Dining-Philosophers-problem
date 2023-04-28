using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NFilosophersProblem
{   
    
    internal class Fork
    {

        static Mutex mutex = new Mutex();
        public int ForkID;
        List<Fork> forks = new List<Fork>();
        List<Philosopher> circle = new List<Philosopher>();
        bool isPicked = false; //na poczatku polozony

        public void start(int n)
        {
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

        public void release()
        {
            this.isPicked = false;
        }

    }

    public class Philosopher { 
        public int ID { get; set; }
        public  bool rightFork = false;
        public bool leftFork = false;
        bool isHungy = true;
    }

}
