using GorillaLocomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class GripIronMonke : MonoBehaviour
{
    bool flag = false;
    bool flag2 = false;
    // Start is called before the first frame update
    public static void ProcessIronMonke()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool flag = false;
        bool flag2 = false;
        List<InputDevice> list = new List<InputDevice>();
        List<InputDevice> list2 = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list2);
        list[0].TryGetFeatureValue(CommonUsages.gripButton, out flag);
        list2[0].TryGetFeatureValue(CommonUsages.gripButton, out flag2);
        if (flag)
        {
            GorillaTagger.Instance.StartVibration(false, GorillaTagger.Instance.tapHapticStrength / 3f, GorillaTagger.Instance.tapHapticDuration);
            GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(25f * GorillaLocomotion.Player.Instance.rightHandTransform.right.x, 25f * GorillaLocomotion.Player.Instance.rightHandTransform.right.y, 25f * GorillaLocomotion.Player.Instance.rightHandTransform.right.z), ForceMode.Acceleration);
        }
        if (flag2)
        {

            GorillaTagger.Instance.StartVibration(true, GorillaTagger.Instance.tapHapticStrength / 4f, GorillaTagger.Instance.tapHapticDuration);
            GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(new Vector3(25f * GorillaLocomotion.Player.Instance.leftHandTransform.right.x * -1f, 25f * GorillaLocomotion.Player.Instance.leftHandTransform.right.y * -1f, 25f * GorillaLocomotion.Player.Instance.leftHandTransform.right.z * -1f), ForceMode.Acceleration);
        }
    }
}
