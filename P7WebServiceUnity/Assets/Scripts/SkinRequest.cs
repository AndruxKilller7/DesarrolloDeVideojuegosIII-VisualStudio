using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class SkinRequest : MonoBehaviour
{
   
    public Text playerName;
    public Text[] skinsName;
    public Text[] skinsCode;
    public Text nPlayer;
    public int indiceSkin;
    public Sprite[] sprites;
    public Image[] contenedorDeSkins;
    public GameObject skinConteiner;
    public GameObject[] skinView;
    public Transform pivotTextSkin;
    public GameObject padreTextCanvas;
    public skins dates;
    public GameObject[] skinsDates;
    static int indicePlayer;
    static bool usuarioConfirmado;
    static bool verPerfil;
    static bool tiendaDeSkins;
    public InputField ingresaEmail;
    public InputField ingresarPasword;
    public static string idPlayer;
    public int skinsCantidad;
    PlayerSkins[] playercontainer; 
    static int idsSkin =7;
    public InputField leerEmail;
    public InputField leerNombre;
    public InputField leerMiddlName;
    public InputField leerLastName;

    void Start()
    {
       
        Debug.Log("Skins:" + idsSkin);
        if (usuarioConfirmado && tiendaDeSkins)
        {
            StartCoroutine(GetRequestPlayersList("http://localhost:8242/api/playersSkin"));
            StartCoroutine(GetRequest("http://localhost:8242/api/players/"+idPlayer));
            
        }
        if (usuarioConfirmado && verPerfil)
        {
            StartCoroutine(GetRequestPlayer("http://localhost:8242/api/players/1"));
            
        }

        //Debug.Log(idPlayer);
        //Debug.Log(skinsCantidad);
        //Debug.Log(usuarioConfirmado);
        //Debug.Log(tiendaDeSkins);
        //Debug.Log("http://localhost:8242/api/players/" + idPlayer);
        //StartCoroutine(Authenticate("http://localhost:8242/api/players"));

    }

    
    void Update()
    {
       
        //contenedorDeSkins.sprite = sprites[indiceSkin];
        
    }

    public void VerificarUsuario()
    {
        
        StartCoroutine(Authenticate("http://localhost:8242/api/usersApi1"));
    }

    public void VerTiendaDeSkins()
    {
        tiendaDeSkins = true;
        SceneManager.LoadScene(2);
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
                 
                    Player player = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
                    nPlayer.text = player.id.ToString();
                    print(player.nickName);
                    playerName.text = player.nickName;
                    Skin[] skins = new Skin[player.playerSkins.Length];
                    for(int i=0; i<skins.Length; i++)
                    {
                        skins[i] = player.playerSkins[i].skin;
                        skinsDates[skins[i].id].GetComponent<GetDatesSkin>().enPropiedad.SetActive(true);

                    }

                    idsSkin = skins.Length;
                  
                    //print(player.playerSkins[indiceSkin].skin.name);
                    //print(indiceSkin);

                    //ViewSkinDate(skins);


                    break;
            }
        }
    }
    IEnumerator GetRequestPlayer(string url)
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


                    Player player = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
                    leerNombre.text = player.nickName;





                    break;
            }
        }
    }

    IEnumerator Authenticate(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("Email", ingresaEmail.text);
        form.AddField("Pasword", ingresarPasword.text);

        using (UnityWebRequest webrequest = UnityWebRequest.Post(url, form))
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
                    usuarioConfirmado = true;

                    idPlayer = webrequest.downloadHandler.text;
                    SceneManager.LoadScene(1);

                    break;
            }
        }
    }

    IEnumerator GetRequestPlayersList(string url)
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
                   
                    PlayerSkins players = JsonUtility.FromJson<PlayerSkins>("{\"playerSkins\":" + webrequest.downloadHandler.text + "}");
                 
                    playercontainer = new PlayerSkins[players.playerSkins.Length];
                    skinsCantidad = playercontainer.Length;
                    Debug.Log(skinsCantidad);
                  
                    break;
            }
        }
    }

//IEnumerator Authenticate(string url)
//{
//    WWWForm form = new WWWForm();
//    form.AddField("nickName", "VirtualXI");
//    form.AddField("id", 1003);
//    using (UnityWebRequest webrequest = UnityWebRequest.Post(url, form))
//    {
//        yield return webrequest.SendWebRequest();

//        switch (webrequest.result)
//        {
//            case UnityWebRequest.Result.ConnectionError:
//            case UnityWebRequest.Result.DataProcessingError:
//            case UnityWebRequest.Result.ProtocolError:
//                print("error");
//                break;
//            case UnityWebRequest.Result.Success:
//                print(webrequest.downloadHandler.text);
//                Player player = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
//                print(player.nickName);
//                break;

//        };
//    }
//}

public void ViewSkinDate(Skin[] skins)
    {
        skinView = new GameObject[skins.Length];
        contenedorDeSkins = new Image[skins.Length];
        
        for (int i = 0; i < skins.Length; i++)
        {
            skinView[i] = skinConteiner;
            skinView[i].GetComponent<GetDatesSkin>().nameS.text = skins[i].name;
            skinView[i].GetComponent<GetDatesSkin>().code.text = skins[i].code;
            skinView[i].GetComponent<GetDatesSkin>().spriteSkin.sprite = sprites[skins[i].id];
            Instantiate(skinView[i], new Vector3(pivotTextSkin.transform.position.x, pivotTextSkin.transform.position.y - 30 * (i + 1), pivotTextSkin.transform.position.z), transform.rotation, padreTextCanvas.transform);

            Debug.Log("Nombre: "+skins[i].name + "Code: " + skins[i].code);
            
        }

        //    skinName.text = skin.name;
        //skinCode.text = skin.code;
    }

    public void ComprarSkin(int id)
    {
       
        StartCoroutine(PostPlayerSkins("http://localhost:8242/api/playersSkin", id,skinsCantidad+1));
        

       
    }

    public void TiendaDeSkins()
    {
        SceneManager.LoadScene(2);
    }

    public void ProfielView()
    {
        SceneManager.LoadScene(4);
        verPerfil = true;
    }

    public void UpdateProfile()
    {
        StartCoroutine(PutPlayer("http://localhost:8242/api/players/"+idPlayer));
    }

    IEnumerator PutPlayer(string url)
    {
        string json = "{\"Id\":\"1\", \"NickName\":\"Nerdo\" }";
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



    IEnumerator PostPlayerSkins(string url,int idSkin,int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerId", int.Parse(idPlayer));
        form.AddField("skinId", idSkin);
        form.AddField("Id", id);
        using (UnityWebRequest webrequest = UnityWebRequest.Post(url, form))
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
                    Player player = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
                    print(player.nickName);
                    break;

            };
        }
    }
}
