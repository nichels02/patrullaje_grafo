using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullaje : MonoBehaviour
{
    ListaDeDobleSentido.listaDeDobleSentido<GameObject> lista;
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
        lista = new ListaDeDobleSentido.listaDeDobleSentido<GameObject>();

        GameObject objeto_1 = Instantiate(prefabs, transform);
        objeto_1.transform.position = vectores[0];
        lista.AddNodeStar(objeto_1, desgaste[0]);


        GameObject objeto_2 = Instantiate(prefabs, transform);
        objeto_2.transform.position = vectores[1];
        lista.AddNodeStar(objeto_2, desgaste[1]);


        GameObject objeto_3 = Instantiate(prefabs, transform);
        objeto_3.transform.position = vectores[2];
        lista.AddNodeStar(objeto_3, desgaste[2]);


        GameObject objeto_4 = Instantiate(prefabs, transform);
        objeto_4.transform.position = vectores[3];
        lista.AddNodeStar(objeto_4, desgaste[3]);
    }

    void Start()
    {
        segimiento = lista.Head.Valor;
        jugador.velocity = (segimiento.transform.position - elJugador.transform.position).normalized * velocidad;
        elDesgaste = lista.Head.Desgaste;
        distancia = LaDistancia(elJugador.transform.position, segimiento.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        energia = energia - (elDesgaste/distancia)*Time.deltaTime;
    }

    float LaDistancia(Vector3 vector1, Vector2 vector2)
    {
        float y1 = vector2.x - vector1.x;
        float y2 = vector2.y - vector1.y;
        float x=Mathf.Sqrt(Mathf.Pow(vector2.x - vector1.x, 2)+ Mathf.Pow(vector2.y - vector1.y, 2));
        return x;
    }

    void aleatorio()
    {
        int random = Random.Range(0,1);
        int desicion;
        if(random == 0)
        {
            desicion = -1;
            elsegimiento = elsegimiento - 1;
            segimiento = lista.GetNodePositin(elsegimiento);
        }
        else
        {
            desicion = 1;
            elsegimiento = elsegimiento + 1;
            segimiento = lista.GetNodePositin(elsegimiento);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "punto")
            {
                
                
                
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
            }
        }
    }

}
