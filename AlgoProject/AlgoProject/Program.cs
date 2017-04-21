using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgoProject
{
    class Program
    {
        static void Main(string[] args)
        {
            graph myGraph = new graph("2hypernyms.txt");
            mapping_functions mf = new mapping_functions();
            List<words> listwords = mf.ReadFile("1synsets11.txt");
            
        }
    }
}
