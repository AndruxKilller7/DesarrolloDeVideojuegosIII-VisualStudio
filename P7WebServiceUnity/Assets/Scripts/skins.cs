using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "New DatesSkin", menuName = "Dskin")]
public class skins: ScriptableObject
{
 
    public string Name;
    public string Code;
    public Sprite icon;
    public int idSkin;
}
