using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Botones : MonoBehaviour
{
    ComprarPersonajes controller;
    public int id;
    public Text nombreSkin;
    void Start()
    {
        controller = GameObject.Find("Main Camera").GetComponent<ComprarPersonajes>();
    }

  
    void Update()
    {
        
    }

    public void ComprarCharacter()
    {
        controller.ComprarPersonajesButton(id);
    }
}
