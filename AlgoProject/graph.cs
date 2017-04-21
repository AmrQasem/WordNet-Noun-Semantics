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
        List<nodeGraph> myNodes;//basic nodes
        int myRoot;// my root
        public int distance;
        Dictionary<int, string[]> existingNode;//to take the data in the file for later work
        string mypath;
        List<int> mydistances;
        mapping_functions MF;


        public void readInputCasesRelations(string path)
        {
           
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string[] splited = null;
            splited = path.Split('.');
            string[] splited2 = splited[0].Split('/');
            FileStream fd = new FileStream("SampleCasesResults/" + splited2[1] + "result.txt", FileMode.Create);
            StreamWriter sd = new StreamWriter(fd);
            List<string[]> input = new List<string[]>();
            string newLine = null;
            
            while (sr.Peek() != -1)
            {
                newLine = sr.ReadLine();
                string[] line = newLine.Split(',');
                string[] SCAnoun = shortestCommonAncestor_Nouns(line[0], line[1]);

                sd.Write(distance + ",");
                for (int j = 0; j < SCAnoun.Length; j++)
                {
                    sd.Write(SCAnoun[j] + " ");
                }

                sd.WriteLine();

            }
            sr.Close();
            sd.Close();

        }


        public void readInputCasesOutCast(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string[] splited = null;
            splited = path.Split('.');
            string[] splited2 = splited[0].Split('/');
            FileStream fd = new FileStream("SampleCasesResults/" + splited2[1] + "result.txt", FileMode.Create);
            StreamWriter sd = new StreamWriter(fd);

            string newLine = null;
            while (sr.Peek() != -1)
            {
                newLine = sr.ReadLine();
                string[] line = newLine.Split(',');
                List<string> my = new List<string>();
                for (int i = 0; i < line.Length; i++)
                    my.Add(line[i]);

                sd.WriteLine(outcast(my));
            }
            sr.Close();
            sd.Close();

        }

        public graph(string mypathSynsets, string path)
        {
            mypath = mypathSynsets;
            MF = new mapping_functions(mypath);
            existingNode = new Dictionary<int, string[]>();
            distance = 0;
            myNodes = new List<nodeGraph>();
            mydistances = new List<int>();

            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string newLine = null;
            while (sr.Peek() != -1)
            {
                newLine = sr.ReadLine();
                string[] line = newLine.Split(',');
                if (line.Length == 1)
                    myRoot = int.Parse(line[0]);

                int key = int.Parse(line[0]);
                line = line.ToList().GetRange(1, line.Length - 1).ToArray();
                existingNode.Add(key, line);
                nodeGraph newNode = new nodeGraph(key);
                myNodes.Add(newNode);

            }
            sr.Close();

            for (int i = 0; i < existingNode.Count; i++)
            {
                createRelation(i, existingNode[i]);
            }

        }
        void createRelation(int child, string[] parents)
        {
            for (int i = 0; i < parents.Length; i++)
            {
                myNodes[child].next.Add(int.Parse(parents[i]));
            }

        }
        public int shortestCommonAncestor(int id1, int id2)
        {
            //Queue<nodeGraph> ID_1 = new Queue<nodeGraph>();
            //Queue<nodeGraph> ID_2 = new Queue<nodeGraph>();

            //ID_1.Enqueue(myNodes[id1]);
            //ID_2.Enqueue(myNodes[id2]);
            //bool IsFinished = false;
            //nodeGraph perv = new nodeGraph();
            //while (IsFinished)
            //{
            //    nodeGraph node1 = ID_1.Dequeue();
            //    nodeGraph node2 = ID_2.Dequeue();
            //    for (int i = 0; i < node1.next.Count; i++)
            //    {
            //        if (myNodes[node1.next[i]].check == true)
            //        {
            //            return myNodes[node1.next[i]];
            //        }
            //        else
            //        {
            //            myNodes[node1.next[i]].check = true;
            //            myNodes[node1.value].levelFromParent1 = (myNodes[perv.value].levelFromParent1) + 1;
            //            perv = myNodes[node1.value];
            //            ID_1.Enqueue(myNodes[node1.next[i]]);
            //        }
            //    }
            //    for (int i = 0; i < node2.next.Count; i++)
            //    {
            //        if (myNodes[node2.next[i]].check == true)
            //        {
            //            return myNodes[node2.next[i]];
            //        }
            //        else
            //        {
            //            myNodes[node2.next[i]].check = true;
            //            ID_2.Enqueue(myNodes[node2.next[i]]);
            //        }
            //    }
            //}

            //return myNodes[Root()];

            char mark = 'm';
            distance = 0;
            markParents(id1, mark);
            mark = 'f';
            int sca = markParents(id2, mark);
            int distance1 = myNodes[sca].levelFromParent1 + myNodes[sca].levelFromParent2;
            mark = 'u';
            markParents(id1, mark);
            markParents(id2, mark);



            mark = 'm';
            distance = 0;
            markParents(id2, mark);
            mark = 'f';
            int sca2 = markParents(id1, mark);
            int distance2 = myNodes[sca2].levelFromParent1 + myNodes[sca2].levelFromParent2;
            mark = 'u';
            markParents(id1, mark);
            markParents(id2, mark);
            distance = Math.Min(distance1, distance2);
            if (distance == distance1)
                return sca;
            else
                return sca2;

        }

        public string outcast(List<string> inputs)
        {
            List<string> words = new List<string>();
            List<int> ids = new List<int>();
            for (int i = 0; i < inputs.Count(); i++)
            {
                int temp = 0;
                for (int j = 0; j < inputs.Count(); j++)
                {
                    if (i != j)
                    {
                        shortestCommonAncestor_Nouns(inputs[i], inputs[j]);
                        temp += distance;
                    }
                }

                ids.Add(temp);
                words.Add(inputs[i]);
            }
            int max = 0;
            int index = 0;
            for (int i = 0; i < ids.Count; i++)
            {
                if (max < Math.Max(max, ids[i]))
                {
                    max = Math.Max(max, ids[i]);
                    index = i;
                }
            }

            return words[index];

        }

        public string[] shortestCommonAncestor_Nouns(string Noun1, string Noun2)
        {
           
            List<int> Ids_1 = MF.mappingFunc2(Noun1);
            List<int> Ids_2 = MF.mappingFunc2(Noun2);
            string[] CommonSynsets;
            int MinDistance = 100000;
            int sca ;
            int minSCA = 0;

            for (int i = 0; i < Ids_1.Count; i++)
            {
                for (int j = 0; j < Ids_2.Count; j++)
                {
                    sca = shortestCommonAncestor(Ids_1[i], Ids_2[j]);
                    if (MinDistance > distance)
                    {
                        MinDistance = distance;
                        minSCA = sca;
                    }
                }
            }
            CommonSynsets = MF.mappingFunc1(minSCA);
            distance = MinDistance;
            return CommonSynsets;
        }



        int markParents(int id, char mark)
        {
            Queue<int> Q = new Queue<int>();
            Q.Enqueue(id);
            while (Q.Count != 0)
            {

                int u = Q.Dequeue();
                if (mark == 'm')
                    myNodes[u].check = true;
                else if (mark == 'u')
                    myNodes[u].check = false;
                else if (myNodes[u].check == true && mark == 'f')
                    return myNodes[u].value;

                for (int i = 0; i < myNodes[u].next.Count; i++)
                {
                    int m = myNodes[u].next[i];
                    if (mark == 'm')
                    {
                        myNodes[m].check = true;
                        if (myNodes[m].levelFromParent1 == 0)
                        {
                            myNodes[m].levelFromParent1 = myNodes[u].levelFromParent1 + 1;
                        }

                        else if (myNodes[m].levelFromParent1 > myNodes[u].levelFromParent1 + 1)
                            myNodes[m].levelFromParent1 = myNodes[u].levelFromParent1 + 1;
                    }
                    else if (mark == 'u')
                    {
                        myNodes[m].check = false;
                        myNodes[m].levelFromParent1 = 0;
                        myNodes[m].levelFromParent2 = 0;
                    }
                    else if (myNodes[m].check == true && mark == 'f')
                    {

                        myNodes[m].levelFromParent2 = myNodes[u].levelFromParent2 + 1;
                        return myNodes[m].value;
                    }
                    else
                    {
                        myNodes[m].levelFromParent2 = myNodes[u].levelFromParent2 + 1;
                    }
                    Q.Enqueue(m);

                }
            }
            return -1;
        }



        public int Root()
        {
            return myRoot;
        }


    }
}
