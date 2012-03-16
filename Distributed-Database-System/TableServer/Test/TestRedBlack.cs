using System;
using RedBlackCS;

namespace Test
{

  //Reference from :"http://www.ececs.uc.edu/~franco/C321/html/RedBlack/redblack.html"
  sealed class TestRedBlack
  {
    //create object of redblack class
    static RedBlack redBlack = new RedBlack();
    #if(TEST_RBT)		
    static public void Main()
    {
      // create MyObjs containing key and string data key=Primary Key,data=Row index

      Value obj1 = new IntValue(1, 4000);
      Value obj2 = new IntValue(2, 3300);
      Value obj3 = new IntValue(3, 459);
      Value obj4 = new IntValue(4, 454);
      Value obj5 = new IntValue(5, 4);
      Value obj6 = new IntValue(6, 442);
      Value obj7 = new IntValue(7, 67);
      Value obj8 = new IntValue(8, 1000);
      Value obj9 = new IntValue(9, 133);
      Value obj10 = new IntValue(10, 1466);
      
      //MyObj obj1 = new MyObj(0001, "MyObj 1");

      try
      {
        // format: Add(key, value)
        redBlack.Add(obj1, obj1);
        redBlack.Add(obj2, obj2);
        redBlack.Add(obj3, obj3);
        redBlack.Add(obj4, obj4);
        redBlack.Add(obj5, obj5);
        redBlack.Add(obj6, obj6);
        redBlack.Add(obj7, obj7);
        redBlack.Add(obj8, obj8);
        //redBlack.Add(new MyKey(obj3.Key), obj3);

        TraverseEnumerator();
        Console.WriteLine(Environment.NewLine);



        Console.WriteLine("Search specific Value:" + ((IntValue)obj9).m_PKValue);
        Console.WriteLine("find ?" + redBlack.Search((IntValue)obj9));
        Console.WriteLine(Environment.NewLine);

        Console.WriteLine("Add a NEW Value:" + ((IntValue)obj9).m_PKValue);
        redBlack.Add(obj9, obj9);
        DumpRedBlack(true);
        Console.WriteLine(Environment.NewLine);

        

        Console.WriteLine("Search specific Value:" + ((IntValue)obj2).m_PKValue);
        Console.WriteLine("find ?" + redBlack.Search((IntValue)obj2));
        Console.WriteLine(Environment.NewLine);

        Console.WriteLine("Remove Max Value:" + redBlack.GetMaxValue().ToString());
        redBlack.RemoveMax();
       
        Console.WriteLine("Remove Max Value:" + redBlack.GetMaxValue().ToString());
        redBlack.RemoveMax();
        DumpRedBlack(true);
        Console.WriteLine(Environment.NewLine);

        Console.WriteLine("Remove specific Value:" + ((IntValue)obj1).m_PKValue);
        redBlack.RemoveAt((IntValue)obj1);
        DumpRedBlack(true);
        

 //Console.WriteLine("Remove specific Value:" + ((IntValue)obj1).m_PKValue);
 //       redBlack.Remove((IntValue)obj1);
 //       DumpRedBlack(true);
 //       Console.WriteLine(Environment.NewLine);

Console.WriteLine("Add a NEW Value:" + ((IntValue)obj10).m_PKValue);
        redBlack.Add(obj10, obj10);
        DumpRedBlack(true);
        Console.WriteLine(Environment.NewLine);


        Console.WriteLine("Add a NEW Value:" + ((IntValue)obj3).m_PKValue);
        redBlack.Add(obj3, obj3);
        DumpRedBlack(true);
        Console.WriteLine(Environment.NewLine);


        Console.WriteLine("Remove Max Value:" + redBlack.GetMaxValue().ToString());
        redBlack.RemoveMax();
        Console.WriteLine("Remove Min Value:" + redBlack.GetMinValue().ToString());
        redBlack.RemoveMin();
        Console.WriteLine(Environment.NewLine);

        DumpRedBlack(true);
        Console.WriteLine(Environment.NewLine);


        Console.WriteLine("** Clearing Tree **");
        redBlack.Clear();
        Console.WriteLine(Environment.NewLine);

        DumpRedBlack(false);

        Console.WriteLine("Press enter to terminate");
        Console.ReadLine();

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.WriteLine("Press enter to terminate");
        Console.ReadLine();
      }
    }
    public static void DumpRedBlack(bool boolDesc)
    {
      // returns keys only
      RedBlackEnumerator k = redBlack.Keys(boolDesc);
      // returns data only, in this case, MyObjs
      RedBlackEnumerator e = redBlack.Elements(boolDesc);

      if (boolDesc)
        Console.WriteLine("** Dumping RedBlack: Ascending **");
      else
        Console.WriteLine("** Dumping RedBlack: Descending **");

      Console.WriteLine("RedBlack Size: " + redBlack.Size().ToString() + Environment.NewLine);

      Console.WriteLine("- keys -");
      while (k.HasMoreElements())
        Console.WriteLine(k.NextElement());

      Console.WriteLine("- my objects -");
      Value cmmMyObj;
      while (e.HasMoreElements())
      {
        cmmMyObj = ((Value)(e.NextElement()));
        Console.Write("Key:" + cmmMyObj.ToString());
        Console.WriteLine(" Data:" + cmmMyObj.m_RowIndex);
      }

    }
    public static void TraverseEnumerator()
    {
      Console.WriteLine("** Traversing using Enumerator **");
      Console.WriteLine(Environment.NewLine);

      Console.WriteLine(Environment.NewLine);

      RedBlackEnumerator myEnumerator = redBlack.GetEnumerator();

      while (myEnumerator.MoveNext())
      {
        Console.Write(" Pk value:{0}\t" + " Row Index:{1}\t" + " Color:{2}\t",
        ((IntValue)myEnumerator.Value).m_PKValue, ((IntValue)myEnumerator.Value).m_RowIndex, myEnumerator.Color);

        if (myEnumerator.parentKey.GetType().IsValueType)
        {
          Console.WriteLine(" Parent Key:{0}\n", "0");
        }
        else
        {
          Console.WriteLine(" Parent Key:{0}\n", ((IntValue)myEnumerator.parentKey).m_PKValue);
        }

      }
    }
    public static void DumpMinMaxValue()
    {
      Console.WriteLine("** Dumping Min/Max Values  **");
      Console.WriteLine("Min MyObj with Row Index value: " + ((Value)redBlack.GetMinValue()).m_RowIndex);
      Console.WriteLine("Max MyObj with Row Index value: " + ((Value)redBlack.GetMaxValue()).m_RowIndex);
      Console.WriteLine("Min MyObj key: " + ((Value)redBlack.GetMinKey()).ToString());
      Console.WriteLine("Max MyObj key: " + ((Value)redBlack.GetMaxKey()).ToString());
    }
    #endif
  }
}
