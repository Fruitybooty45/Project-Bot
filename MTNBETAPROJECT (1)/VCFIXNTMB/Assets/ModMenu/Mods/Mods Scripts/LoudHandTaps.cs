using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoudHandTaps : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        
            GorillaTagger.Instance.handTapVolume = 5f;
        
    }

    // Update is called once per frame
    void OnDisable()
    {
        {
            GorillaTagger.Instance.handTapVolume = 0.1f;
        }
    }
}
