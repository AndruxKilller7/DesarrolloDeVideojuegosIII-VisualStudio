using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SkinRequest : MonoBehaviour
{

    public Text playerName;
    public Text skinName;
    public Text skinCode;
    public int indiceSkin;
    public Sprite[] sprites;
    public Image contenedorDeSkins;
   
    void Start()
    {
        
        StartCoroutine(GetRequest("http://localhost:8242/api/players/1"));

    }

    
    void Update()
    {
       
        contenedorDeSkins.sprite = sprites[indiceSkin];
        
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
                  
                    print(player.nickName);
                    playerName.text = player.nickName;
                    skinName.text = player.playerSkins[indiceSkin].skin.name;
                    skinCode.text = player.playerSkins[indiceSkin].skin.code;
                    print(player.playerSkins[indiceSkin].skin.name);
                    print(indiceSkin);




                    break;
            }
        }
    }
}
