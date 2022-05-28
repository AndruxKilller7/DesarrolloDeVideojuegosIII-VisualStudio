using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class InstanciarPersonajes : MonoBehaviour
{
    public Skins skinsDispobibles;
    GameObject[] contenedorDePersonajes;
    public GameObject contenedor;
    public GameObject padre;
    ComprarPersonajes controller;
    public Text[] tectoPersonaje;
    public GameObject[] pruebas;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void botonDeActivasion()
    {
        StartCoroutine(GetRequest("http://localhost:8242/api/skins"));

    }

    IEnumerator GetRequest(string url)
    {

        using (UnityWebRequest webrequest = UnityWebRequest.Get(url))
        {
            yield return webrequest.SendWebRequest();
            switch (webrequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:
               
                    skinsDispobibles = JsonUtility.FromJson<Skins>("{\"skins\":" + webrequest.downloadHandler.text + "}");
                    contenedorDePersonajes = new GameObject[skinsDispobibles.skins.Length];
                    tectoPersonaje = new Text[skinsDispobibles.skins.Length];
                    Debug.Log(skinsDispobibles.skins.Length);
                    Debug.Log(contenedorDePersonajes.Length);
                    pruebas = new GameObject[contenedorDePersonajes.Length];
                    for (int i = 0; i < skinsDispobibles.skins.Length; i++)
                    {
                        contenedorDePersonajes[i] = contenedor;
                        contenedorDePersonajes[i].GetComponent<Botones>().nombreSkin.text = skinsDispobibles.skins[i].name;
                        Debug.Log(i);
                        contenedorDePersonajes[i].GetComponent<Botones>().id = skinsDispobibles.skins[i].id;

                        Instantiate(contenedorDePersonajes[i], padre.transform.position, transform.rotation, padre.transform);
                        
                       
                        
                    }
                   






                    break;
            }
        }
    }

    
    

}
