using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDatesSkin : MonoBehaviour
{
   
    public Text nameS;
    public Text code;
    public Image spriteSkin;
    public skins dates;
    public int id;
    public GameObject enPropiedad;

   void Start()
    {
        nameS.text = dates.Name;
        code.text = dates.Code ;
        spriteSkin.sprite = dates.icon;
        id = dates.idSkin;

    }
    
   
    void Update()
    {

      
    }
}
