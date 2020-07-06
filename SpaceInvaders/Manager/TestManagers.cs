using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class TestManagers
    {
        NodeManager nMan = new NodeManager();

        //Nodes
        Node d1 = new Node(Node.DataNames.Dog, 20);
        Node c1 = new Node(Node.DataNames.Cat, 30);
        Node f1 = new Node(Node.DataNames.Fish, 60);
        Node d2 = new Node(Node.DataNames.Dog, 9001);
        
    }
}
