using GorillaLocomotion;
using System.Collections.Generic;
using UnityEngine;
using GorillaNetworking;
using UnityEngine.XR;
using Photon.Pun;
using Photon.Realtime;
using easyInputs;
using ExitGames.Client.Photon;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Diagnostics;

public class PCVRMODS : MonoBehaviour
{
    [Header("PCVR MODS MADE BY TIMMY")]
    [Header(" ")]

    public bool SpinHeadY;
    public bool SpinHeadX;
    public bool BrokenNeck;
    public bool TwinWhereHaveYouBeen;
    public bool FPSBOOSTER;
    public bool UpAndDown;
    public bool InstantTaps;
    public bool Helicopter;
    public bool GhostMonkey;
    public bool LoudHandTaps;
    public bool LeftTriggerDisconnect;
    public bool RightTriggerDisconnect;
    public bool SilentHandTaps;
    public bool GrabRig;
    public bool Sizechanger;

    public float SIZECHANGERSCALE = 1f;
    public float SIZECHANGERSPEED = 6f;
    public float SIZECHANGERJUMPFORCE = 10f;
    private Transform playerTransform;
    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalVelocity;
    bool rightGrab = EasyInputs.GetGripButtonDown(EasyHand.RightHand);
    bool leftGrab = EasyInputs.GetGripButtonDown(EasyHand.LeftHand);
    bool rightTrigger = EasyInputs.GetTriggerButtonDown(EasyHand.RightHand);
    bool leftTrigger = EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand);



    void Start()
    {
        playerTransform = GetComponent<Transform>();
        characterController = GetComponent<CharacterController>();
        playerTransform.localScale *= SIZECHANGERSCALE;
    }


    void Update()
    {


        if (FPSBOOSTER)
        {
            QualitySettings.masterTextureLimit = 99999;
        }

        else
        {
            QualitySettings.masterTextureLimit = 0;
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

        if (LoudHandTaps)
        {
            GorillaTagger.Instance.handTapVolume = 10f;
        }
        else
        {
            GorillaTagger.Instance.handTapVolume = 0.50f;
        }

        if (SilentHandTaps)
        {
            GorillaTagger.Instance.handTapVolume = 0f;
        }
        else
        {
            GorillaTagger.Instance.handTapVolume = 0.50f;
        }


        if (InstantTaps)
        {
            GorillaTagger.Instance.tapCoolDown = 0f;
        }
        else
        {
            GorillaTagger.Instance.tapCoolDown = 0.75f;
        }

        if (GhostMonkey)
        {
            GhostMonke();
        }

        if (Helicopter)
        {
            HelicopterMonk();
        }

        if (GrabRig)
        {
            Holddarig();
        }


        void Holddarig()
        {
            if (rightGrab)
            {
                GameObject pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointer.GetComponent<Renderer>().material.color = Color.green;
                pointer.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                pointer.transform.position = GorillaTagger.Instance.rightHandTransform.position + new Vector3(0, 1, 0);
                UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                UnityEngine.Object.Destroy(pointer, Time.deltaTime);
                if (rightTrigger)
                {
                    pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    pointer.GetComponent<Renderer>().material.color = Color.red;
                    pointer.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                    pointer.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position;
                    pointer.transform.position = GorillaTagger.Instance.myVRRig.transform.position;

                    GorillaTagger.Instance.offlineVRRig.enabled = false;
                    GorillaTagger.Instance.offlineVRRig.transform.position = pointer.transform.position;
                    GorillaTagger.Instance.myVRRig.transform.position = pointer.transform.position;
                    GorillaTagger.Instance.offlineVRRig.transform.rotation = pointer.transform.rotation;
                    GorillaTagger.Instance.myVRRig.transform.rotation = pointer.transform.rotation;

                    GameObject left = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    GameObject right = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                    left.transform.localScale = new Vector3(0.075f, 0.075f, 0.075f);
                    right.transform.localScale = new Vector3(0.075f, 0.075f, 0.075f);
                    left.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                    right.transform.position = GorillaTagger.Instance.rightHandTransform.position;

                    left.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);
                    right.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);

                    UnityEngine.Object.Destroy(pointer.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(pointer.GetComponent<Collider>());
                    UnityEngine.Object.Destroy(pointer, Time.deltaTime);

                    UnityEngine.Object.Destroy(left.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(left.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(right.GetComponent<Rigidbody>());
                    UnityEngine.Object.Destroy(right.GetComponent<BoxCollider>());
                    UnityEngine.Object.Destroy(left, Time.deltaTime);
                    UnityEngine.Object.Destroy(right, Time.deltaTime);
                }
                else
                {
                    GorillaTagger.Instance.offlineVRRig.enabled = true;
                }
            }
        }



        void GhostMonke()
        {
            bool rightControllerSecondaryButton = (EasyInputs.GetSecondaryButtonDown(EasyHand.RightHand)); 
            if ((EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand)))
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GameObject gameObject = GameObject.CreatePrimitive(0);
                UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 1);
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                UnityEngine.Object.Destroy(gameObject2.GetComponent<Rigidbody>());
                UnityEngine.Object.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 1);
                UnityEngine.Object.Destroy(gameObject, Time.deltaTime);
                UnityEngine.Object.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;

            }
        }

        

























        void HelicopterMonk()
        {
            if ((EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand)))
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GorillaTagger.Instance.offlineVRRig.transform.position
                    += new Vector3(0f, 0.075f, 0f);
                GorillaTagger.Instance.offlineVRRig.transform.rotation = Quaternion.Euler(GorillaTagger.Instance.offlineVRRig.transform.rotation.eulerAngles
                    + new Vector3(0f, 10f, 0f));
                GorillaTagger.Instance.offlineVRRig.head.rigTarget.transform.rotation = GorillaTagger.Instance.offlineVRRig.transform.rotation;
                GorillaTagger.Instance.offlineVRRig.leftHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * -1f;
                GorillaTagger.Instance.offlineVRRig.rightHand.rigTarget.transform.position = GorillaTagger.Instance.offlineVRRig.transform.position + GorillaTagger.Instance.offlineVRRig.transform.right * 1f;
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }


        




        void HandleMovement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (characterController.isGrounded)
            {
                verticalVelocity = -0.5f;

                if (Input.GetButtonDown("Jump"))
                {
                    verticalVelocity = SIZECHANGERJUMPFORCE;
                }
            }
            else
            {
                verticalVelocity -= 9.81f * Time.deltaTime;
            }

            Vector3 moveDirection = new Vector3(horizontalInput, verticalVelocity, verticalInput);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= SIZECHANGERSPEED;

            characterController.Move(moveDirection * Time.deltaTime);
        }

        void SpinHeadXMod()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 10f;
        }



        void SpinHeadYMod()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 10f;
        }

        void NameCycleTwinwerehaveyoubeen()
        {
            SetName("Twin"); Mathf.PingPong(Time.time, 1f);
            SetName("Were"); Mathf.PingPong(Time.time, 1f);
            SetName("Have"); Mathf.PingPong(Time.time, 1f);
            SetName("You"); Mathf.PingPong(Time.time, 1f);
            SetName("Been"); Mathf.PingPong(Time.time, 1f);
        }

        void SetName(string PlayerName)
        {
            PhotonNetwork.LocalPlayer.NickName = PlayerName;
            PhotonNetwork.NickName = PlayerName;
            PhotonNetwork.NetworkingClient.NickName = PlayerName;
            GorillaComputer.instance.currentName = PlayerName;
            GorillaComputer.instance.savedName = PlayerName;
            GorillaComputer.instance.offlineVRRigNametagText.text = PlayerName;
            GorillaLocomotion.Player.Instance.name = PlayerName;
            PlayerPrefs.SetString("playerName", PlayerName);
            PlayerPrefs.Save();
        }

        if (SpinHeadY)
        {
            SpinHeadYMod();
        }

        if (TwinWhereHaveYouBeen)
        {
            NameCycleTwinwerehaveyoubeen();
        }

        if (SpinHeadX)
        {
            SpinHeadXMod();
        }

        if (BrokenNeck)
        {
            BrokenNeckMod();
        }

        void VOIDTriggerDisconnect()
        {
            if (leftTrigger)
            {
                PhotonNetwork.Disconnect();
            }
        }

        if (LeftTriggerDisconnect)
        {
          VOIDTriggerDisconnect();
        }



        void VOIDRightTriggerDisconnect()
        {
            if (rightTrigger)
            {
                PhotonNetwork.Disconnect();
            }
        }

        if (RightTriggerDisconnect)
        {
                VOIDRightTriggerDisconnect();
        }

        void BrokenNeckMod()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z = 90f;
        }

        if (Sizechanger)
        {
            if (rightTrigger)
            {
                SIZECHANGERSCALE += 0.5f;
                SIZECHANGERJUMPFORCE += 0.5f;
                SIZECHANGERSPEED += 0.5f;
            }

            if (leftTrigger)
            {
                SIZECHANGERSCALE -= 0.5f;
                SIZECHANGERJUMPFORCE -= 0.5f;
                SIZECHANGERSPEED -= 0.5f;
            }

            HandleMovement();
        }




    }


}
