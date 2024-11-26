using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyHead : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        
            GorillaTagger.Instance.myVRRig.head.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 360), (float)Random.Range(0, 360)) * Time.deltaTime;
				GorillaTagger.Instance.myVRRig.head.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 0), (float)Random.Range(0, 0), (float)Random.Range(0, 0)) * Time.deltaTime;
    }

    // Update is called once per frame
    void OnDisable()

    {
 
	    GorillaTagger.Instance.myVRRig.head.rigTarget.eulerAngles = new Vector3((float)Random.Range(0, 360), (float)Random.Range(0, 180), (float)Random.Range(0, 180));
    }
}
