﻿using System;

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
            /*On the execution of the above for loop, prev and
         * current will point to those nodes
         * between which the new node is to be inserted*/
            newNode.next = current;
            newNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
        }
    }
}