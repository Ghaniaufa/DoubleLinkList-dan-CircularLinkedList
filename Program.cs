using System;

namespace double_linked_list
{
    class Node
    {
        /* Node class represent the node of doubly linked list
         * It consists of the information part and links to
         * * Its succeding and preceeding
         * * In terms of next and previous*/
        public int noMhs;
        public string name;
        //point to the succeding node
        public Node next;
        //point to the preceeding node
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node START;

        //Constructor

        public void addNode()
        {
            int nim;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newNode = new Node();
            newNode.noMhs = nim;
            newNode.name = nm;

            //check if the list empty
            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = newNode;
                newNode.next = null;
                START = newNode;
                return;
            }
            /*if the node is to be inserted at beetwen to Node*/
            Node previous, current;
            for (current = previous = START;
                current != null && nim >= current.noMhs;
                previous = current, current = current.next)
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                }
            }
            //* current will point to those nodes
            //*between which the new node is to be inserted*/
            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            previous.next = newNode;

        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = current = START;
            while (current != null && rollNo != current.noMhs)
            {
                previous = current;
                current = current.next;
            }
            return (current != null);


        }
        public bool dellNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            // the begining of data
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            //Node between two nodes in the list
            if (current == START )
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }

            //*if the to be deleted is in between the list then the following lines ofix executed. */
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }

        public void asceding()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "Roll number are:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + currentNode.name + "\n");
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecord in the descending order of" + "Roll number are:\n");
                Node currentNode;
                //membawa currentNode ke node paling belakang
                currentNode = START;
                while(currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                //Membaca data dari last node ke first node
                while (currentNode != null)
                {
                    Console.Write(currentNode.noMhs + " " + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }   
            }
        }
    }
}