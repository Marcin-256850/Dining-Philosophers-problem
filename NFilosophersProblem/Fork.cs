using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFilosophersProblem
{
    internal class Fork
    {
        bool isPicked = false; //na poczatku polozony

        public void acquire()
        {

        }   

        public void release()
        {
            this.isPicked = false;
        }

    }

    internal class Philosopher { 
        int ID { get; set; }
        bool leftFork = false;  
        bool rightFork = false;
        bool forks = false;
    
    }

}
