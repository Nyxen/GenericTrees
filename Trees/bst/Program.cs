using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bst
{
    

    class Program
    {
        static void Main(string[] args)
        {
            
        
            BinarySearchTree<int> tree = new BinarySearchTree<int>();
            tree.Add(554);
            tree.Add(78);
            tree.Add(4);
            tree.Add(121);
            tree.Add(222);
            tree.Add(86);
            tree.Add(80);
            tree.Add(79);
            tree.Add(89);
            tree.Add(91);
            tree.Add(100);
            tree.Add(234);
            tree.Add(678);
            tree.Add(642);
            tree.Add(721);
            tree.Add(892);
            tree.Add(90);
            ;
            //tree.Remove();

            Console.WriteLine($"Found: {tree.Find(3)}");
            foreach (var item in tree.InOrder())
            {
                Console.WriteLine(item.Value);
            }
                Console.ReadKey();



        }

        //static IEnumerable<int> GetEnumerator()
        //{
        //    var current = head;
        //    while (current != null)
        //    {
        //        yield return current.Data;
        //        current = current.next;
        //    }
        //}
    }
}
