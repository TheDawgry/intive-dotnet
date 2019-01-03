using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApp app = new ConsoleApp();
            while (true)                        //Repeats application as long as user closes it himself
            {
                app.Play();
            }
        }
    }
}
