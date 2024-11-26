using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GorillaNetworking;
using GorillaLocomotion;
using easyInputs;

public class GhostMonkey : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
        {
            GorillaTagger.Instance.myVRRig.enabled = false;
        }

        else
        {
            GorillaTagger.Instance.myVRRig.enabled = true;
        }
    }
}
