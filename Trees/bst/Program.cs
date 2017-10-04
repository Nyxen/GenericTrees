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
            tree.Insert(5);
            tree.Insert(1);
            tree.Insert(3);
            tree.Insert(4);
            Console.WriteLine($"Found: {tree.Find(7)}");

            Console.ReadKey();

        }
    }
}
