using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgoProject
{
    public class graph
    {
        List<nodeGraph> myNodes;
        long myRoot;
        Dictionary<long,string[]> existingNode;
       
       public graph(string path)
        {
            existingNode = new Dictionary<long,string[]>();
            myNodes = new List<nodeGraph>();

            FileStream fs = new FileStream(path,FileMode.Open);
            StreamReader sr = new StreamReader(fs);
         
            string newLine = null;
           while (sr.Peek() !=-1)
           {
               newLine = sr.ReadLine();
               string[] line= newLine.Split(',');
               if (line.Length == 1)
                   myRoot =long.Parse( line[0]);

               long key = long.Parse(line[0]);
               line = line.ToList().GetRange(1, line.Length - 1).ToArray();
               existingNode.Add(key,line);
               nodeGraph newNode=new nodeGraph(key);
               myNodes.Add(newNode);

           }
           sr.Close();
           
           for (int i=0;i<existingNode.Count;i++)
           {
               createRelation(i, existingNode[i]);
           }

        }
       public  void createRelation(long child,string[] parents)
       {
           for (int i = 0; i < parents.Length; i++)
           {
               myNodes[int.Parse(parents[i])].next.Add(child);
           }
               
       }


      public long Root()
       {
           return myRoot;
       }


    }
}
