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
        GameObject objeto_1 = Instantiate(prefabs, transform);
        objeto_1.transform.position = vectores[0];
        lista.AddNodeStar(objeto_1);


        GameObject objeto_2 = Instantiate(prefabs, transform);
        objeto_2.transform.position = vectores[1];
        lista.AddNodeStar(objeto_2);


        GameObject objeto_3 = Instantiate(prefabs, transform);
        objeto_3.transform.position = vectores[2];
        lista.AddNodeStar(objeto_3);


        GameObject objeto_4 = Instantiate(prefabs, transform);
        objeto_4.transform.position = vectores[3];
        lista.AddNodeStar(objeto_4);


        //crear conexiones
        int nodo = 0;
        int conexion = 1;
        lista.addConexion(nodo,conexion, desgaste[0]);


        nodo = 1;
        conexion = 2;
        lista.addConexion(nodo,conexion, desgaste[1]);


        nodo = 2;
        conexion = 3;
        lista.addConexion(nodo,conexion, desgaste[2]);


        nodo = 3;
        conexion = 0;
        lista.addConexion(nodo,conexion, desgaste[3]);
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
        lista.modificarEspecialNext(1);
        segimiento = lista.GetNodeEspecial();
        Debug.Log(lista.Especial.Valor.transform.position.x+" "+ lista.Especial.Valor.transform.position.y + " "+ lista.Especial.Valor.transform.position.z);
        elDesgaste = lista.Especial.GetConexionDesgastePosition(0);
        distancia = LaDistancia(elJugador.transform.position, segimiento.transform.position);
        jugador.velocity = Vector2.zero.normalized * velocidad;
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
