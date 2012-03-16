using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.twitter
{
  class Program
  {
    static void Main(string[] args)
    {
      twitter tw = new twitter();
      tw.PostTweet("hello,team member!");
     
    }
  }
}
