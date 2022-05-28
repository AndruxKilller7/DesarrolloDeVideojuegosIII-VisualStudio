using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class ComprarPersonajes : MonoBehaviour
{
    public int idPlayer;

    public string nick;
    public Skins skinsDispobibles;
    public Text error;
    public int contadorDePersonajes;
    public GameObject panel;
    public GameObject mainMenu;
    public bool noDisponible =false;

    void Start()
    {
        StartCoroutine(GetRequest("http://localhost:8242/api/skins"));
        nick = GameManager.instance.playerData.nickName;
        idPlayer = GameManager.instance.playerData.id;
        //moneyPlayer=GameManager.instance.playerData.money ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComprarDinero(int valorDeDinero)
    {
        //moneyPlayer = valorDeDinero + moneyPlayer;
        //StartCoroutine(PutPlayer("http://localhost:8242/api/players/" + idPlayer));
    }

    public void ComprarPersonajesButton(int idSkin)
    {
        if(skinsDispobibles.skins[idSkin-1].disponible==true)
        {
            StartCoroutine(BuySkin("http://localhost:8242/api/playerSkins", idSkin));
            StartCoroutine(PutSkins("http://localhost:8242/api/skins/"+idSkin.ToString(), idSkin));

          
            contadorDePersonajes += 1;
        }
        else
        {
            Debug.Log("Personaje No Disponible para su compra");
        }
         

    }

    IEnumerator BuySkin(string url, int id)
    {
        
        WWWForm form = new WWWForm();
        form.AddField("Id", id);
        form.AddField("PlayerId", GameManager.instance.playerData.id);
        form.AddField("SkinId", id);
   
        using (UnityWebRequest webrequest = UnityWebRequest.Post(url, form))
        {
            yield return webrequest.SendWebRequest();

            switch (webrequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    //error.text = "Error en el servidor";
                    break;
                case UnityWebRequest.Result.Success:
                    //OnButtonClickRefresh();
                 
                    print("success");
                    break;

            };
        }
    }

    IEnumerator PutSkins(string url,int id)
    {
      Debug.Log(id);
      
        string json = "{\"Id\":" + id.ToString() + ", \"Name\":'" + skinsDispobibles.skins[id-1].name+ "', \"disponible\":'" + noDisponible+ "' }";
        Debug.Log(json);
        byte[] body = Encoding.UTF8.GetBytes(json);


        using (UnityWebRequest webrequest = UnityWebRequest.Put(url, body))
        {
            webrequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(body);
            webrequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webrequest.SetRequestHeader("Content-Type", "application/json");
            yield return webrequest.SendWebRequest();
            switch (webrequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    print("error");
                    break;
                case UnityWebRequest.Result.Success:




                    break;
            }
        }
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
                    print(webrequest.downloadHandler.text);
                  skinsDispobibles = JsonUtility.FromJson<Skins>("{\"skins\":" + webrequest.downloadHandler.text + "}");
                   for(int i=0;i<skinsDispobibles.skins.Length;i++)
                    {
                        Debug.Log(skinsDispobibles.skins[i].disponible);
                    }

                
                  
                


                    break;
            }
        }
    }


    public void VerificarPersonajes()
    {
        if(contadorDePersonajes>=3)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("No tiene skins Suficientes");
        }

    }

    public void ActiveList()
    {
        panel.SetActive(true);
        mainMenu.SetActive(false);
    }





   

   
}
