using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject
{
    public class nodeGraph
    {
       public long value;
       public List<long> next;
      public  nodeGraph(long id)
        {
            value = id;
            next =new List<long>() ;
        }
     public   nodeGraph()
      {
          value = 0;
          next = new List<long>();
      }
    }
}
