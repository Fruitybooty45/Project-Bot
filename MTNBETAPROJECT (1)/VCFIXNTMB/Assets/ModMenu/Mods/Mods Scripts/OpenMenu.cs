using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class OpenMenu : MonoBehaviour
{
    // Public

    [Header("PROJECT GREG ON TOP")]
    [Header("https://discord.gg/dawBw7nYxM")]

    [Header("Open Menu Parent")]
    public GameObject OpenMenuParent;

    [Header("Hand")]
    public EasyHand Hand;

    // Private

    void Start()
    {
        OpenMenuParent.SetActive(false);
    }

    void Update()
    {
        if (EasyInputs.GetPrimaryButtonDown(Hand))
        {
            OpenMenuParent.SetActive(true);
        }

        else
        {
            OpenMenuParent.SetActive(false);
        }
    }
}