using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;

public class Fly : MonoBehaviour
{
    [Header("Fly")]
    [Header("gorilla player.")]
    public Rigidbody gorillaPlayer;
    [Header("hand?.")]
    public EasyHand hand;
    [Header("speed recomended 10.")]
    public float speed = 15.0f;
    [Header("controller, if you put in hand right, put in your right hand controller.")]
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
