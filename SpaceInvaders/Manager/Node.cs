using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Node : DLink
    {
        public enum DataNames
        {
            Bird,
            Cat,
            Dog,
            Fish,
            Rabbit,
            Uninitialized
        }

        //member fields
        public DataNames name;
        public int x;

        //constructors
        public Node(DataNames name, int val) : base()
        {
            this.Set(name, val);
        }

        public Node() :base()
        {
            this.WashNode();
        }

        public void Set(DataNames name, int num)
        {
            this.name = name;
            this.x = num;
        }

        public void WashNode()
        {
            this.name = DataNames.Uninitialized;
            this.x = 0;
        }

        public void Print()
        {
            Debug.WriteLine("name: "+this.name + " val: "+this.x);
        }
        
    }
}
