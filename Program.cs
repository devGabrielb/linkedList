using System;
using linkedList;

namespace linkedList
{

    public class Node
    {
        internal string data;
        internal Node next;

        public Node(string data)
        {
            this.data = data;
            this.next = null;
        }
        public Node() { }
    }


    public class LinkedList
    {
        private Node head;


        private Node getLastNode()
        {
            var lastNode = this.head;

            while (lastNode.next != null)
            {
                lastNode = lastNode.next;
            }

            return lastNode;
        }

        public void AddInFirstPosition(string data)
        {
            var node = new Node(data);
            node.next = this.head;
            this.head = node;

        }

        public void AddInLastPosition(string data)
        {
            var node = new Node(data);

            if (this.head == null)
            {
                this.head = node;
                return;
            }
            var lastNode = getLastNode();
            node.next = lastNode.next;
            lastNode.next = node;

        }

        public void printData()
        {
            var lastNode = head;
            var result = "";

            while (lastNode != null)
            {

                result += $"{lastNode.data}\n";
                lastNode = lastNode.next;
            }

            Console.Write(result);
        }
        public void deleteNode(string data)
        {

            var currentNode = this.head;
            var prevNode = currentNode;
            if (currentNode != null && currentNode.data == data)
            {
                this.head = currentNode.next;
                return;
            }
            while (currentNode != null && currentNode.data != data)
            {
                prevNode = currentNode;
                currentNode = currentNode.next;
            }
            if (currentNode == null)
            {
                return;
            }
            prevNode.next = currentNode.next;

        }

        public void deleteByIndex(int index)
        {
            var currentNode = this.head;
            var prevNode = currentNode;
            var count = 0;
            if (currentNode != null && index == 0)
            {
                this.head = currentNode.next;
                return;
            }
            while (currentNode != null && count != index)
            {
                prevNode = currentNode;
                currentNode = currentNode.next;

                count++;
            }
            if (currentNode == null)
            {
                return;
            }
            prevNode.next = currentNode.next;
        }
        public void reverse()
        {
            var currentNode = this.head;
            Node newNode = new Node();

            while (currentNode != null)
            {

                var node = new Node(currentNode.data);
                node.next = newNode;
                newNode = node;

                currentNode = currentNode.next;
            }

            this.head = newNode;

        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        var linkList = new LinkedList();

        linkList.AddInFirstPosition("J");
        linkList.AddInLastPosition("A");
        linkList.AddInLastPosition("B");
        linkList.AddInLastPosition("C");
        linkList.AddInLastPosition("D");


        linkList.printData();
        linkList.deleteByIndex(3);
        Console.WriteLine("--------------------deleteByIndex------------------");
        linkList.printData();
        linkList.reverse();
        Console.WriteLine("--------------------reverse------------------");
        linkList.printData();
    }

}
