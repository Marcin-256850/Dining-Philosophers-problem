using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace NFilosophersProblem
{
    internal class Fork
    {
        LinkedList<Philosopher> circle = new LinkedList<Philosopher>();
        bool isPicked = false; //na poczatku polozony

        public void start(int n)
        {
            Thread[] threads = new Thread[n];
            for (int i = 0; i < n; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(think_eat));
                threads[i].Start(i);
            }
        }
        public void think_eat(object id)
        {
            int philosopherId = (int)id;
            circle.AddLast(new Philosopher { ID = philosopherId});
        }
        public void acquireleft()
        {

        }

        public void acquireright()
        {

        }

        public void release()
        {
            this.isPicked = false;
        }

    }

    public class Philosopher { 
        public int ID { get; set; }
        bool leftFork = false;  
        bool rightFork = false;
        bool forks = false;
    }

}
