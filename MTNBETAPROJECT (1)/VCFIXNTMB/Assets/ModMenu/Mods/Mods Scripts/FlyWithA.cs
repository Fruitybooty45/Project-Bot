using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class FlyWithA : MonoBehaviour
{
    [Header("FLY WITH A.")]
    [Header("gorilla player.")]
    public Rigidbody gorillaPlayer;
    [Header("hand?.")]
    public EasyHand hand;
    [Header("speed recomended 20.")]
    public float speed = 15.0f;
    [Header("controller, if you put in hand left, put in your left hand controller.")]
    public GameObject Controller;

    void Update()
    {
        if (EasyInputs.GetPrimaryButtonDown(hand))
        {
             Vector3 forceDirection = Controller.transform.forward;
             Vector3 force = speed * forceDirection;
            gorillaPlayer.velocity = speed * forceDirection;
        }
    }
}
