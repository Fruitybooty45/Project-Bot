using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;
using UnityEngine.XR;
using GorillaLocomotion;

public class ModsScript : MonoBehaviour
{
    public bool Fly;
    public bool CarMonke;
    public bool NormalSpeed;
    public bool FastSpeed;
    public bool FasterSpeed;
    public Player Player;
    public bool CameraHandbool;
    public GameObject CameraHand;
    public bool NoTagFreeze;
    public bool SlideControl;
    public bool RGB;


    [Header("Fly Objects")]
    private List<InputDevice> list;
    private bool flying = false;

    [Header("Long Arms Stuff")]
    public GameObject targetObject;
    private Vector3 originalScale;
    private Vector3 resetScale;

    [Header("Car Monke")]
    [SerializeField]
    private Rigidbody GorillaPlayer;

    [Range(0f, 500f)]
    [SerializeField]
    private float VroomVroomSpeed = 10f;

    [SerializeField]
    private Transform CarDirection;

    [Header("RGB Stuff")]
    public Material material;
    public Color[] colors;
    private int currentColorindex = 0;
    private int targetColorindex = 1;
    private float targetPoint;
    public float time = 25f;


    private void Awake()
    {
        originalScale = targetObject.transform.localScale;
        resetScale = new Vector3(1.8f, 1.8f, 1.8f);
        ResizeObject();
    }

    private void OnEnable()
    {
        ResizeObject();
    }

    private void OnDisable()
    {
        ResetObject();
    }

    private void ResizeObject()
    {
        targetObject.transform.localScale = resetScale;
    }

    private void ResetObject()
    {
        targetObject.transform.localScale = originalScale;
    }


    void Update()
    {
        if (Fly)
        {
            bool flag6 = false;
            bool flag7 = false;
            list = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
            list[0].TryGetFeatureValue(CommonUsages.primaryButton, out flag6);
            list[0].TryGetFeatureValue(CommonUsages.secondaryButton, out flag7);
            if (flag6)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 30;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                if (!flying)
                {
                    flying = true;
                }
            }
        }
        else if (flying)
        {
            GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 36f;
            flying = false;
        }

        if (CarMonke)
        {
            if (EasyInputs.GetTriggerButtonDown(EasyHand.RightHand))
            {
                Vector3 forceDirection = CarDirection.forward.normalized * VroomVroomSpeed;
                forceDirection.y = 0f;
                GorillaPlayer.AddForceAtPosition(forceDirection, CarDirection.position, ForceMode.Acceleration);
            }

            if (EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand))
            {
                Vector3 forceDirection = -CarDirection.forward.normalized * VroomVroomSpeed;
                forceDirection.y = 0f;
                GorillaPlayer.AddForceAtPosition(forceDirection, CarDirection.position, ForceMode.Acceleration);
            }
        }

        if (NormalSpeed)
        {
            Player.jumpMultiplier = 1.1f;
            Player.maxJumpSpeed = 6.5f;
        }

        if (FastSpeed)
        {
            Player.jumpMultiplier = 2.2f;
            Player.maxJumpSpeed = 13f;
        }

        if (FasterSpeed)
        {
            Player.jumpMultiplier = 4.4f;
            Player.maxJumpSpeed = 26f;
        }

        if (CameraHandbool)
        {
            CameraHand.SetActive(true);
        }
        else
        {
            CameraHand.SetActive(false);
        }

        if (NoTagFreeze)
        {
            GorillaLocomotion.Player.Instance.disableMovement = false;
        }

        if (SlideControl)
        {
            GorillaLocomotion.Player.Instance.slideControl = 1;
        }

        if (RGB)
        {
            Transition();
        }
    }

    void Transition()
    {
        targetPoint += Time.deltaTime / time;
        material.color = Color.Lerp(colors[currentColorindex], colors[targetColorindex], targetPoint);
        if (targetPoint >= 1f)
        {
            targetPoint = 0f;
            currentColorindex = targetColorindex;
            targetColorindex++;
            if (targetColorindex == colors.Length)
            targetColorindex = 0;
        }
    }
}
