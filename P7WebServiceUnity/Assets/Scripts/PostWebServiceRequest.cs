using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostWebServiceRequest : MonoBehaviour
{
    public InputField ingresaEmail;
    public InputField ingresarPasword;
    public static string idPlayer;
    public void Start()
    {
        //StartCoroutine(PostPlayer("http://localhost:8242/api/players/"));
        //StartCoroutine(Authenticate("http://localhost:8242/api/usersApi1"));
       
    }

    public void VerificarUsuario()
    {
        StartCoroutine(Authenticate("http://localhost:8242/api/usersApi1"));
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

    IEnumerator Authenticate(string url)
    {
        WWWForm form = new WWWForm();
        //form.AddField("Email", ingresaEmail.text);
        //form.AddField("Pasword", ingresarPasword.text);
        form.AddField("Email", 1);
        form.AddField("Pasword", 1234);

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
                    idPlayer = webrequest.downloadHandler.text;
                    SceneManager.LoadScene(1);
                    //SceneManager.LoadScene(1);
                    //User user = JsonUtility.FromJson<User>(webrequest.downloadHandler.text);

                    //print(user.Player.id);
                    break;
            }
        }
    }
}
