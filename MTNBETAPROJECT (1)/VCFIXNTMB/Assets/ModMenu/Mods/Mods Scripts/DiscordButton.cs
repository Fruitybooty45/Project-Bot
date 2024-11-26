using UnityEngine;
using System.Collections;

public class DiscordButton : MonoBehaviour
{

    [Header("made by furnacedev")]

    // var

    public string Url = "";

    void Start()
    {
        Application.OpenURL(Url);
        
        Debug.Log("redirected to " + Url);
    }
}