using Photon.Pun;
using UnityEngine;

public class SnowBallSpam : MonoBehaviour
{
	[Header("Made By Moose Do Not Steal")]
	public GameObject SnowBall;

	public Transform RightHandController;

	public Transform LeftHandController;

	public bool RightHand;

	public bool LeftHand;

	public float spawnSpeed;

	private float speedWatcherRight;

	private float speedWatcherLeft;

	private void Update()
	{
	}

	[PunRPC]
	private void SpawnRight()
	{
	}

	[PunRPC]
	private void SpawnLeft()
	{
	}
}
