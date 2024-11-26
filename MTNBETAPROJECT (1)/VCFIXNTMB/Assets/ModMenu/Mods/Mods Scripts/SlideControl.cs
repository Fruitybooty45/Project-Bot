using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SlideControl : MonoBehaviour
{
    private void OnEnable()
    {
        GorillaLocomotion.Player.Instance.slideControl = 0.05f;
    }

    // This method is called when the script is disabled
    private void OnDisable()
    {
        GorillaLocomotion.Player.Instance.slideControl = 0.006f;
    }
}
