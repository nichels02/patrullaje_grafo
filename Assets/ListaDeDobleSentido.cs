using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDeDobleSentido : MonoBehaviour
{
    public class listaDeDobleSentido<T>
    {
        public class node
        {
            T valor;
            node next;
            node previus;
            public T Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            public node Next
            {
                get { return next; }
                set { next = value; }
            }
            public node Previous
            {
                get { return previus; }
                set { previus = value; }
            }


            public node(T valor)
            {
                Valor = valor;
            }
        }


        node head;
        node tail;
        int cantidad;

        public node Head
        {
            get { return head; }
            set { head = value; }
        }
        public node Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public void AddNodeStar(T valou)
        {
            if (head == null)
            {
                node newnode = new node(valou);
                head = newnode;
                tail = newnode;
                cantidad = cantidad + 1;
            }
            else
            {
                node newnode = new node(valou);
                node tmp = head;
                head = newnode;
                newnode.Next = tmp;
                tmp.Previous = newnode;
                head.Previous = tail;
                tail.Next = head;
                cantidad = cantidad + 1;
            }
        }

        public void AddNodeEnd(T valou)
        {
            if (head == null)
            {
                AddNodeStar(valou);
            }
            else
            {
                node newnode = new node(valou);
                node tmp = tail;
                tail = newnode;
                tmp.Next = newnode;
                newnode.Previous = tmp;
                head.Previous= tail;
                tail.Next = head;
                cantidad = cantidad + 1;
            }
        }
        public node Position(int position)
        {
            int recorrido = 0;
            node tmp = head;
            while (recorrido < position - 1)
            {
                tmp = tmp.Next;
                recorrido = recorrido + 1;
            }
            return tmp;
        }


        public T GetNodePositin(int position)
        {
            node tmp = Position(position);
            T x;
            x = tmp.Valor;
            return x;
        }


    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
