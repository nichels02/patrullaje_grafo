using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grafo : MonoBehaviour
{
    public class elgrafo<T>
    {
        public class node
        {
            T valor;
            node next;
            node previus;
            public ListaDeDobleSentido.listaDeDobleSentido<conexiones>  lista = new ListaDeDobleSentido.listaDeDobleSentido<conexiones>();

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

            

            public conexiones PositionConexion( int position)
            {
                conexiones conexion = lista.Position(position).Valor;
                return conexion;
            }

            public int GetConexionDesgastePosition( int positionConexion)
            {
                conexiones tmp = PositionConexion(positionConexion);
                int x;
                x = tmp.Desgaste;
                return x;
            }

            public T GetConexionNodePosition(int positionConexion)
            {
                conexiones tmp = PositionConexion(positionConexion);
                T x;
                x = tmp.Valor.valor;
                return x;
            }

        }











        public class conexiones
        {
            node valor;
            int desgaste;

            public node Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            public int Desgaste
            {
                get { return desgaste; }
                set { desgaste = value; }
            }


            public conexiones(node valor, int desgaste)
            {
                Valor = valor;
                Desgaste = desgaste;
            }
        }



        node head;
        node tail;
        node especial;
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
        public node Especial
        {
            get { return especial; }
            set { especial = value; }
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
                head.Previous = tail;
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

        public T GetNodeEspecial()
        {
            node tmp = Especial;
            T x;
            x = tmp.Valor;
            return x;
        }

        public void addConexion(int nodo, int conexion, int desgaste)
        {
            node tmp = Position(nodo);
            node tmpConexion = Position(conexion);
            conexiones tmoC = new conexiones(tmpConexion, desgaste);
            tmp.lista.AddNodeEnd(tmoC);

        }

        public void modificarEspecial(int posicionEspecial)
        {
            node node = Position(posicionEspecial);
            Especial=node;
        }

        public void modificarEspecialNext(int posicionEspecial)
        {
            especial = especial.PositionConexion(posicionEspecial).Valor;
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
