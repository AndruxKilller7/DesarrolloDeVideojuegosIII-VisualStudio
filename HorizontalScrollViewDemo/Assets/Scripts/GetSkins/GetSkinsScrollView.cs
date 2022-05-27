using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = System.Random;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GetSkinsScrollView : MonoBehaviour
{
    [SerializeField] Text levelNumberText;
    [SerializeField] GameObject BtnPref;
    [SerializeField] Transform BtnParent;
    [SerializeField] Text Error;
    List<GameObject> availableSkinsBtnObjets = new List<GameObject>();

    [SerializeField] GameObject playerSkinsObject;




    public int idPlayer;
    public string nick;
    public Skins skinsDispobibles;
    public Text error;
    public static int contadorDePersonajes;


    public void Start()
    {
        StartCoroutine(GetRequest("http://localhost:8242/api/skins1"));
        nick = GameManager.instance.playerData.nickName;
        idPlayer = GameManager.instance.playerData.id;

        if (GameManager.instance.playerData.id == -1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine(GetRequestSkins("http://localhost:8242/api/skins"));
        }
       
    }

    public void LoadSkinButtons()
    {
        Skin[] skins = GameManager.instance.availableSkins;
        for (int i = 0; i < skins.Length; i++)
        {
            GameObject availableSkinBtnObj = Instantiate(BtnPref, BtnParent) as GameObject;
            availableSkinBtnObj.GetComponent<SkinButtonItem>().skinName = skins[i].name;
            availableSkinBtnObj.GetComponent<SkinButtonItem>().id = skins[i].id;
            foreach (var item in GameManager.instance.playerData.playerSkins)
            {
                if (item.skinId == skins[i].id)
                {
                    availableSkinBtnObj.GetComponent<SkinButtonItem>().button.interactable = false;
                }
            }
            availableSkinBtnObj.GetComponent<SkinButtonItem>().skinsScrollView = this;
            availableSkinsBtnObjets.Add(availableSkinBtnObj);
        }
    }

    public void ClearAvailableSkinsButtons()
    {
        foreach (var item in availableSkinsBtnObjets)
        {
            Destroy(item);
        }
        availableSkinsBtnObjets.Clear();
    }

    IEnumerator GetRequestSkins(string url)
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
                    Skins skins = JsonUtility.FromJson<Skins>("{ \"skins\":" + webrequest.downloadHandler.text + "}");
                    GameManager.instance.availableSkins = skins.skins;
                    LoadSkinButtons();
                    break;

            };
        }
    }
    public void VerificarPersonajes()
    {
        if (contadorDePersonajes >= 3)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log("No tiene skins Suficientes");
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
                    for (int i = 0; i < skinsDispobibles.skins.Length; i++)
                    {
                        Debug.Log(skinsDispobibles.skins[i].disponible);
                    }






                    break;
            }
        }
    }
    public void OnAvailableSkinButtonClick(int id)
    {
        if (skinsDispobibles.skins[id - 1].disponible == true)
        {
            StartCoroutine(BuySkin("http://localhost:8242/api/playerSkins", id));
            contadorDePersonajes += 1;
        }
        else
        {
            Debug.Log("Personaje No Disponible para su compra");
        }
        //levelNumberText.text = "SkinId: " + (id);
        //StartCoroutine(BuySkin("http://localhost:8242/api/playerSkins", id));
    }

    public void OnButtonClickRefresh()
    {
        StartCoroutine(Refresh("http://localhost:8242/api/players/" + GameManager.instance.playerData.id));
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
                    skinsDispobibles.skins[id].disponible = false;
                    print("success");
                    break;

            };
        }
    }

    IEnumerator Refresh(string url)
    {
        using (UnityWebRequest webrequest = UnityWebRequest.Get(url))
        {
            yield return webrequest.SendWebRequest();

            switch (webrequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                case UnityWebRequest.Result.ProtocolError:
                    Error.text = "Error en el servidor";
                    break;
                case UnityWebRequest.Result.Success:
                    if (webrequest.downloadHandler.text == "")
                    {
                        Error.text = "El Player no existe";
                    }
                    else
                    {
                        GameManager.instance.playerData = JsonUtility.FromJson<Player>(webrequest.downloadHandler.text);
                        ClearAvailableSkinsButtons();
                        LoadSkinButtons();

                        playerSkinsObject.GetComponent<PlayerSkinsScrollView>().ClearPlayerSkinsButtons();
                        playerSkinsObject.GetComponent<PlayerSkinsScrollView>().LoadPlayerSkinsButtons();

                    }
                    break;

            };
        }
    }
}