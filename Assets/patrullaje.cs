using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullaje : MonoBehaviour
{
    grafo.elgrafo<GameObject> lista;
    [SerializeField] GameObject prefabs;
    [SerializeField] int[] desgaste= new int[4];
    [SerializeField] Vector3[] vectores= new Vector3[4];



    [SerializeField] Rigidbody2D jugador;
    [SerializeField] GameObject elJugador;
    [SerializeField] int velocidad;
    float energia = 100;
    int elDesgaste;
    float distancia;
    int elsegimiento=0;
    GameObject segimiento;


    private void Awake()
    {
        lista = new grafo.elgrafo<GameObject>();

        //crear nodos

        lista.AddNodeEnd(prefabs,1);
        lista.GetNodePositin(0).name = "1";
        GameObject objeto_1=Instantiate(lista.Position(0).Valor);
        lista.Position(0).Valor.transform.position = vectores[0];
        //objeto_1.transform.position = vectores[0];

        lista.AddNodeEnd(prefabs,2);
        lista.GetNodePositin(1).name = "2";
        GameObject objeto_2 = Instantiate(lista.Position(1).Valor);
        lista.Position(1).Valor.transform.position = vectores[1];
        //objeto_2.transform.position = vectores[1];

        lista.AddNodeEnd(prefabs,3);
        lista.GetNodePositin(2).name = "3";
        GameObject objeto_3 = Instantiate(lista.Position(2).Valor);
        lista.Position(2).Valor.transform.position = vectores[2];
        //objeto_3.transform.position = vectores[2];

        lista.AddNodeEnd(prefabs,4);
        lista.GetNodePositin(3).name = "4";
        GameObject objeto_4 = Instantiate(lista.Position(3).Valor);
        lista.Position(3).Valor.transform.position = vectores[3];
        //objeto_4.transform.position = vectores[3];


        /*
        GameObject objeto_1 = Instantiate(prefabs, transform);
        objeto_1.transform.position = vectores[0];
        objeto_1.name = "1";
        lista.AddNodeEnd(objeto_1);



        GameObject objeto_2 = Instantiate(prefabs, transform);
        objeto_2.transform.position = vectores[1];
        objeto_2.name = "2";
        lista.AddNodeEnd(objeto_2);


        GameObject objeto_3 = Instantiate(prefabs, transform);
        objeto_3.transform.position = vectores[2];
        objeto_3.name = "3";
        lista.AddNodeEnd(objeto_3);


        GameObject objeto_4 = Instantiate(prefabs, transform);
        objeto_4.transform.position = vectores[3];
        objeto_4.name = "4";
        lista.AddNodeEnd(objeto_4);
        */

        //crear conexiones
        int nodo = 1;
        int conexion = 2;
        lista.addConexion(nodo,conexion, desgaste[0]);
        // Current -> NextNode
        // 1 -> 2
        // 2 -> 3
        Debug.Log("conexion 1");
        Debug.Log(lista.Position(1).Valor.transform.position);
        Debug.Log(lista.Position(1).lista.Position(1).Valor.Valor.Valor.transform.position);
        //lista.Position(1).orden


        Debug.Log("conexion 2");
        nodo = 2;
        conexion = 3;
        lista.addConexion(nodo,conexion, desgaste[1]);
        Debug.Log(lista.Position(2).Valor.transform.position);
        Debug.Log(lista.Position(2).lista.Position(1).Valor.Valor.Valor.transform.position);


        Debug.Log("conexion 3");
        nodo = 3;
        conexion = 4;
        lista.addConexion(nodo,conexion, desgaste[2]);
        Debug.Log(lista.Position(3).Valor.transform.position);
        Debug.Log(lista.Position(3).lista.Position(1).Valor.Valor.Valor.transform.position);


        Debug.Log("conexion 4");
        nodo = 4;
        conexion = 1;
        lista.addConexion(nodo,conexion, desgaste[3]);
        Debug.Log(lista.Position(4).Valor.transform.position);
        Debug.Log(lista.Position(4).lista.Position(1).Valor.Valor.Valor.transform.position);


    }

    void Start()
    {
        lista.modificarEspecial(elsegimiento);
        segimiento = lista.GetNodeEspecial();
        jugador.velocity = (segimiento.transform.position - elJugador.transform.position).normalized * velocidad;
        elDesgaste = lista.Especial.GetConexionDesgastePosition(0);
        distancia = LaDistancia(elJugador.transform.position, segimiento.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        energia = energia - (elDesgaste/distancia)*Time.deltaTime;
        segimiento = lista.GetNodePositin(elsegimiento);

    }

    float LaDistancia(Vector3 vector1, Vector2 vector2)
    {
        float y1 = vector2.x - vector1.x;
        float y2 = vector2.y - vector1.y;
        float x=Mathf.Sqrt(Mathf.Pow(vector2.x - vector1.x, 2)+ Mathf.Pow(vector2.y - vector1.y, 2));
        return x;
    }

    
    public void cambio()
    {
        Debug.Log(lista.Especial.lista.Head.Valor.Valor.orden);
        lista.modificarEspecialNext(2);
        segimiento = lista.GetNodeEspecial();
        Debug.Log(lista.Especial.lista.Head.Valor.Valor.orden);
        Debug.Log(lista.Especial.Valor.name);
        elDesgaste = lista.Especial.GetConexionDesgastePosition(0);
        distancia = LaDistancia(elJugador.transform.position, segimiento.transform.position);
        jugador.velocity = (segimiento.transform.position - elJugador.transform.position).normalized * velocidad;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "punto")
            {
                


                /*
                if (posicion == 3)
                {
                    posicion = 0;
                }
                else
                {
                    posicion = posicion + 1;
                }
                segimiento = puntosDePatrullaje[posicion];
                distancia = segimiento.transform.position - transform.position;
                objetoSegimiento = segimiento.GetComponent<puntoDePatrullaje>();
                Debug.Log(objetoSegimiento.gameObject.name);
                eltiempo = objetoSegimiento.Tiempo;
                Debug.Log(eltiempo);
                myRGB2d.velocity = distancia / eltiempo;
                */
            }
        }
    }


}
