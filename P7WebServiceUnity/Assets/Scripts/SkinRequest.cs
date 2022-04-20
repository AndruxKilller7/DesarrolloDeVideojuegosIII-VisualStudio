using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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
    
    void Start()
    {
        
        StartCoroutine(GetRequest("http://localhost:8242/api/players/3"));

    }

    
    void Update()
    {
       
        //contenedorDeSkins.sprite = sprites[indiceSkin];
        
    }

    public void AnteriorSkin()
    {
        if (indiceSkin > 0)
        {
            indiceSkin -= 1;
            
        }
        else
        {
            Debug.Log("Ya no hay mas Skins");
        }
        StartCoroutine(GetRequest("http://localhost:8242/api/players/1"));
    }


    public void SiguienteSkin()
    {
        if (indiceSkin < 2)
        {
            indiceSkin += 1;
            
        }
        else
        {
            Debug.Log("Ya no hay mas Skins");
        }
        StartCoroutine(GetRequest("http://localhost:8242/api/players/1"));
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
                    }
                  
                    //print(player.playerSkins[indiceSkin].skin.name);
                    //print(indiceSkin);

                    ViewSkinDate(skins);


                    break;
            }
        }
    }

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
}
