using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MSMSTEMP.Mods
{
    public class ESp : MonoBehaviour
    {
        public static void BoxESP()
        {
            Material material = new Material(Shader.Find("GUI/Text Shader"));
            material.color = Color.magenta;
            foreach (VRRig vrrig in (VRRig[])UnityEngine.Object.FindObjectsOfType(typeof(VRRig)))
            {
                bool flag = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer;
                if (flag)
                {
                    GameObject gameObject = GameObject.CreatePrimitive((PrimitiveType)3);
                    UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(gameObject.GetComponent<Collider>());
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.GetComponent<MeshRenderer>().material = material;
                    gameObject.transform.localScale = new Vector3(0.3f, 0.6f, 0.3f);
                    gameObject.transform.position = vrrig.head.rigTarget.position;
                    UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
                }
            }
        }
    }
}
