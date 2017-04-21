
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

            List<string> messages = new List<string>();
            messages.Add("Sample Case");
            messages.Add("Sample Case");
            messages.Add("Sample Case");
            messages.Add("Sample Case");
            messages.Add("Small Case");
            messages.Add("Small Case");
            messages.Add("Medium Case");
            messages.Add("Medium Case");
            
            FileStream fs = new FileStream("SampleCases.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            int i = 1;
            string newLine=null;
            while (sr.Peek()!=-1)
            {
                newLine = sr.ReadLine();
                string[] paths = newLine.Split(',');
                graph myGraph1 = new graph(paths[0], paths[1]);
                myGraph1.readInputCasesRelations(paths[2]);
                if (paths.Length == 4)
                {
                    myGraph1.readInputCasesOutCast(paths[3]);
                   
                }

                Console.Write("-Case " + i +" DONE. "+paths[2]);
                if (paths.Length == 4)
                    Console.Write(" , " + paths[3]);
                Console.WriteLine();
                   i++;
            }


           
            //Console.WriteLine("CASE1:");
            //Console.WriteLine("SCA: ");
            
            //string[] SCAnoun = myGraph1.shortestCommonAncestor_Nouns("Tepic", "ethmoidal_artery");
            //for (int i = 0; i < SCAnoun.Length; i++)
            //{
            //    Console.Write("The Shortest common Ancestor is: ");
            //    Console.WriteLine(SCAnoun[i]);
            //}
            //Console.Write("With distance:  ");
            //Console.WriteLine(myGraph1.distance);

            //string[] SCAnoun = myGraph1.shortestCommonAncestor_Nouns("a", "h");
            ////K and F gives distance = 6 in case4
            ////C and H gives distance = 5 in case3
            ////H and F gives distance = 2 in case3
            ////A and H gives distance = 1 in case2
                
            //for (int i = 0; i < SCAnoun.Length; i++)
            //{
            //    Console.Write("The Shortest common Ancestor is : ");
            //    Console.WriteLine(SCAnoun[i]);
            //}
            //Console.Write("With distance  :  ");
            //Console.WriteLine(myGraph1.distance);

            

            //List<string> my = new List<string>();
            //my.Add("Eucalyptus_regnans");
            //my.Add("motor_oil");
            //my.Add("Dryas_octopetala");
            //my.Add("mountain_ash");
            //my.Add("Oreopteris_limbosperma");

            //my.Add("Mirabilis_oblongifolia");

            //my.Add("mountain_four_o'clock");

            //my.Add("Tsuga_mertensiana");

            //my.Add("mountain_lily");

            //my.Add("Dryopteris_oreades");

            //my.Add("mountain_swamp_gum");
            //my.Add("Asplenium_montanum");
            //Console.WriteLine(myGraph1.outcast(my));



            //graph myGraph1 = new graph("1sysnets.txt","1hypernyms.txt");
            //mapping_functions MF = new mapping_functions("4synsets.txt");
            //List<int> ids=MF.mappingFunc2("g");
            //for (int i = 0; i < ids.Count; i++)
            //    {
            //       Console.WriteLine(ids[i]);
            //    }
            //string[] synsets = MF.mappingFunc1(10);
            //for (int i = 0; i < synsets.Length; i++)
            //    {
            //        Console.WriteLine(synsets[i]);
            //    }
            //Console.WriteLine("CASE1:");
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph1.shortestCommonAncestor(1, 2));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph1.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph1.shortestCommonAncestor(1, 6));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph1.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph1.shortestCommonAncestor(4, 10));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph1.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph1.shortestCommonAncestor(0, 9));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph1.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph1.shortestCommonAncestor(0, 10));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph1.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph1.shortestCommonAncestor(5,3));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph1.distance);

            //graph myGraph2 = new graph("2hypernyms.txt");
            //Console.WriteLine("CASE2:");
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph2.shortestCommonAncestor(1, 6));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph2.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph2.shortestCommonAncestor(0, 1));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph2.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph2.shortestCommonAncestor(0, 7));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph2.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph2.shortestCommonAncestor(0, 2));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph2.distance);

            //graph myGraph3 = new graph("3synsets.txt", "3hypernyms.txt");
            //Console.WriteLine("CASE3:");
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph3.shortestCommonAncestor(3, 2));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph3.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph3.shortestCommonAncestor(4, 5));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph3.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph3.shortestCommonAncestor(7, 2));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph3.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph3.shortestCommonAncestor(7,5));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph3.distance);

            //graph myGraph4 = new graph("4synsets,txt","4hypernyms.txt");
            //Console.WriteLine("CASE4:");
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph4.shortestCommonAncestor(10, 5));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph4.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph4.shortestCommonAncestor(10, 5));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph4.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph4.shortestCommonAncestor(7, 6));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph4.distance);
            //Console.Write("SCA: ");
            //Console.WriteLine(myGraph4.shortestCommonAncestor(0,6));
            //Console.Write("DIS: ");
            //Console.WriteLine(myGraph4.distance);

            //test mapping function1

            //mapping_functions MF = new mapping_functions("1synset.txt");
            //Console.WriteLine("Enter the ID :  ");
            //int id = int.Parse(Console.ReadLine());
            //string [] synsets=MF.mappingFunc1(id);
            //Console.WriteLine("The Synsets of the ID number "+id+"  is  : ");
            //for(int i=0;i<synsets.Length;i++)
            //{
            //    Console.WriteLine(synsets[i]);
            //}
            //Console.WriteLine("Enter the Synset :  ");
            //string synset = Console.ReadLine();

            //List<int> ids = MF.mappingFunc2(synset);
            //Console.WriteLine("The IDs of the synset " + synset + "  is  : ");
            //for (int i = 0; i < synsets.Length; i++)
            //{
            //    Console.WriteLine(synsets[i]);
            //}
       
        }
    }
}
