using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class Request : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("http://localhost:11045/api/Players1"));
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    print(player.playerName);
                    //Ranks ranks = JsonUtility.FromJson<Ranks>(webrequest.downloadHandler.text);
                    //print(ranks.finalRank);

                    break;
            }
        }
    }
}
