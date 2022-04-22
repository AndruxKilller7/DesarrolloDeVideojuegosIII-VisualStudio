using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PostWebServiceRequest : MonoBehaviour
{
    public InputField ingresaName;
    public InputField ingresarID;
    public void Start()
    {
        StartCoroutine(PostPlayer("http://localhost:8242/api/players/"));
    }

    public void CrearNuevoPlayer()
    {
        
    }

    IEnumerator PostPlayer(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("nickName", "Ninja");
        form.AddField("id", 2);

        using (UnityWebRequest webrequest = UnityWebRequest.Post(url,form))
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
            }
        }
    }
}
