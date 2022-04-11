using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Request : MonoBehaviour
{
    //public Text time;
    //public Text orbs;
    //public Text damage;
    //public Text itemUse;
    //public Text stylishPTS;
    //public Text devilHunterRank;
    //public Text rankBonus;

    public Text containerText;
    void Start()
    {
        StartCoroutine(GetRequest("http://localhost:8242/api/players"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MostrarDatos()
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
                    //Ranks ranks = JsonUtility.FromJson<Ranks>(webrequest.downloadHandler.text);
                    //Player player = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
                    Players players = JsonUtility.FromJson<Players>("{\"players\":" + webrequest.downloadHandler.text + "}");
                    //damage.text = ranks.damage;
                    //orbs.text = ranks.orbs;
                    //time.text = ranks.time;
                    //itemUse.text = ranks.itemUse;
                    //stylishPTS.text = ranks.stylishPTS;
                    //rankBonus.text = ranks.rankBonus;
                    //devilHunterRank.text = ranks.devilHunterRank;
                    for(int i=0; i<players.players.Length;i++)
                    {

                        print(players.players[i].nickName);
                    }
                    
                    //Users players = JsonUtility.FromJson<Users>(webrequest.downloadHandler.text);
                    //print(players.firstName);
                    //Ranks ranks = JsonUtility.FromJson<Ranks>(webrequest.downloadHandler.text);
                    //print(ranks.finalRank);

                    break;
            }
        }
    }
}
