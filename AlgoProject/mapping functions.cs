using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AlgoProject
{
    public class mapping_functions
    {
        public Dictionary<string, List<int>> SynsetToID = new Dictionary<string, List<int>>();
        public Dictionary<int, string[]> fileOfIDs = new Dictionary<int, string[]>();

        public mapping_functions(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = "";
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                string[] fields = line.Split(',');
                string[] synsets = fields[1].Split(' ');

                for (int i = 0; i < synsets.Length; i++)
                {
                   
                    List<int> IDs = new List<int>();
                    if (!SynsetToID.ContainsKey(synsets[i]))
                    {
                        IDs.Add(int.Parse(fields[0]));
                        SynsetToID.Add(synsets[i], IDs);
                    }
                    else
                    {
                        IDs = SynsetToID[synsets[i]];
                        IDs.Add(int.Parse(fields[0]));
                        SynsetToID[synsets[i]] = IDs;
                    }
                }
                fileOfIDs.Add(int.Parse(fields[0]), synsets);
            }

        }

        //Mapping Function 1 take ID and return array of synsets 
        public string[] mappingFunc1( int ID)
        {
            
            return fileOfIDs[ID];
          
        }

        //Function Which Read the file and put it in List
       

        //Mapping Function 2 take synset and return list of IDs
        public List<int> mappingFunc2( string synset)
        {
           
            return SynsetToID[synset];
        }

     
      
    }
}
