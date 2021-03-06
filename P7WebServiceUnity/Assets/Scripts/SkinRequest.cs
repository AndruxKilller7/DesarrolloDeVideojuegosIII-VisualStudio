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
    static bool verificarPlayerskin;
    public InputField ingresaEmail;
    public InputField ingresarPasword;
    public static string idPlayer;
    public int skinsCantidad;
    PlayerSkins[] playercontainer; 
    static int idsSkin =7;
    public InputField leerEmail;
    public InputField leerNickName;
    public InputField leerName;
    public InputField leerMiddlName;
    public InputField leerLastName;
    static int playerskinid;
    static int playerskinidVeryfy;

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
            StartCoroutine(GetRequestPlayer("http://localhost:8242/api/players/"+idPlayer));
            StartCoroutine(GetRequestUser("http://localhost:8242/api/usersApi1/"+idPlayer));
           
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
        Debug.Log(tiendaDeSkins);
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
                    leerNickName.text = player.nickName;





                    break;
            }
        }
    }
    IEnumerator GetRequestUser(string url)
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


                    User user = JsonUtility.FromJson<User>(webrequest.downloadHandler.text);
                    leerEmail.text = user.email;
                    leerName.text = user.firstName;
                    leerLastName.text = user.lastName;
                    leerMiddlName.text = user.middleName;





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

    public void DeleteSkin(int idPlayerSkin)
    {
        playerskinid = idPlayerSkin;
        StartCoroutine(VerifyPlayer("http://localhost:8242/api/players/" + idPlayer));
       
        
    }



    IEnumerator VerifyPlayer(string url)
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
                    
                    for(int i=0; i<player.playerSkins.Length;i++)
                    {
                        if(playerskinid== player.playerSkins[i].skin.id)
                        {
                            verificarPlayerskin = true;
                            playerskinid = player.playerSkins[i].skin.id;
                            playerskinidVeryfy = player.playerSkins[i].id;
                            Debug.Log(playerskinid);
                            Debug.Log(player.playerSkins[i].skin.id);
                            Debug.Log(playerskinidVeryfy);

                        }
                    }

                    if (verificarPlayerskin)
                    {
                        StartCoroutine(Delete("http://localhost:8242/api/playersSkin/" + playerskinidVeryfy));
                    }




                    break;
            }
        }
    }
    IEnumerator PutPlayer(string url)
    {
        //PlayerSkins players = JsonUtility.FromJson<PlayerSkins>("{\"playerSkins\":" + webrequest.downloadHandler.text + "}");
        string nick = leerNickName.text;
      
        string json = "{\"Id\":"+idPlayer.ToString()+", \"NickName\":'"+nick +"' }";
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

    IEnumerator Delete(string url)
    {
      


        using (UnityWebRequest webrequest = UnityWebRequest.Delete(url))
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
                    print("SkinEliminada");



                    break;
            }
        }
    }

    public void ComprarSkin(int id)
    {
        skinsCantidad++;
        StartCoroutine(PostPlayerSkins("http://localhost:8242/api/playersSkin", id));
        Debug.Log(skinsCantidad);
        Debug.Log(idPlayer);
        Debug.Log(id);

    }
    IEnumerator PostPlayerSkins(string url, int idSkin)
    {
        WWWForm form = new WWWForm();
        form.AddField("playerId", idPlayer);
        form.AddField("skinId", idSkin);
        form.AddField("Id", skinsCantidad);
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
                    //Player player = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
                    //print(player.nickName);
                    break;

            };
        }
    }

}
