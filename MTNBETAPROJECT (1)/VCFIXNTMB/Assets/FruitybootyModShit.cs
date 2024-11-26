using GorillaLocomotion;
using System.Collections.Generic;
using UnityEngine;
using GorillaNetworking;
using UnityEngine.XR;
using Photon.Pun;
using Photon.Realtime;
using easyInputs;
using ExitGames.Client.Photon;
using Steamworks;
using PlayFab.ClientModels;

public class FruitybootyModShit : MonoBehaviour
{
    public bool NoGrav;
    public bool Fly;
    public bool ESP;
    public bool LoudHit;
    public bool MosaSpeed;
    public bool UpAndDown;
    public bool GhostMonkey;
    public bool LowQuality;
    public bool LongArms;
    public bool GorillaCar;
    public bool NoClip;
    private GameObject gorilla;
    private Rigidbody GorillaPlayer;
    private float carSpeed = 10f;
    private Transform CarDirection;
    static bool primaryDown = false;
    static bool no = false;
    static bool  yes = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (NoGrav)
        {
            Physics.gravity = new Vector3(0f, -3f, 0f);
        }
        else 
        {
            Physics.gravity = new Vector3(0f, -9.81f, 0f);
        }
        if (Fly)
        {
            if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
            {
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 36f;

            }
            else
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 30f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        if (ESP)
        {
            Material material = new Material(Shader.Find("GUI/Text Shader"));
            material.color = new Color32(0, 151, 255, 1);

            foreach (VRRig vrrig in (VRRig[])UnityEngine.Object.FindObjectsOfType(typeof(VRRig)))
            {
                if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !vrrig.photonView.IsMine)
                {
                    GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                    gameObject.transform.rotation = Quaternion.identity;
                    gameObject.GetComponent<MeshRenderer>().material = vrrig.mainSkin.material;
                    gameObject.transform.localScale = new Vector3(0.3f, 0.6f, 0.3f);
                    gameObject.transform.position = vrrig.headMesh.transform.position;
                    UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
                }
            }
        }
        if (LoudHit)
        {
            GorillaTagger.Instance.handTapVolume = 10f;
        }
        else
        {
            GorillaTagger.Instance.handTapVolume = 0.1f;
        }
        if (MosaSpeed)
        {
            GorillaGameManager.instance.slowJumpLimit = 8.2f;
            GorillaGameManager.instance.slowJumpLimit = 1.4f;
        }
        if (UpAndDown)
        {
            if (EasyInputs.GetTriggerButtonDown(EasyHand.RightHand))
            {
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 50f, 0f), ForceMode.Acceleration);

            }
            if (EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand))
            {
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(0f, -50f, 0f), ForceMode.Acceleration);
            }
        }
        if (GhostMonkey)
        {
            if (EasyInputs.GetPrimaryButtonDown(EasyHand.LeftHand))
            {
                GorillaTagger.Instance.myVRRig.enabled = false;
            }
            else
            {
                GorillaTagger.Instance.myVRRig.enabled = true;
            }
        }
        if (LowQuality)
        {
            QualitySettings.masterTextureLimit = 999999999;
        }
        if (LongArms)
        {
            gorilla.transform.localScale *= 1.4f;
        }
        else
        {
            gorilla.transform.localScale = Vector3.one;
        }
        if (GorillaCar)
        {
            
            if (EasyInputs.GetTriggerButtonDown(EasyHand.RightHand))
        {
            Vector3 forceDirection = CarDirection.forward.normalized * carSpeed;
            forceDirection.y = 0f;
            GorillaPlayer.AddForceAtPosition(forceDirection, CarDirection.position, ForceMode.Acceleration);
        }

        if (EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand))
        {
            Vector3 forceDirection = -CarDirection.forward.normalized * carSpeed;
            forceDirection.y = 0f;
            GorillaPlayer.AddForceAtPosition(forceDirection, CarDirection.position, ForceMode.Acceleration);
        }
        if (NoClip)
        {
            if (primaryDown)
            {
                if (!no)
                {
                    foreach (MeshCollider mc in Resources.FindObjectsOfTypeAll<MeshCollider>())
                        mc.transform.localScale = mc.transform.localScale / 10000;
                    no = true; 
                    yes = false;
                }
                else
                {
                    if (!yes)
                    {
                        foreach(MeshCollider mc in Resources.FindObjectsOfTypeAll<MeshCollider>())
                            mc.transform.localScale = mc.transform.localScale * 10000;
                        yes = true;
                        no = false;
                    }
                }
            }
        }
        }
    }
}
