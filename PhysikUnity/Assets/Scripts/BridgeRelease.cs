using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeRelease : MonoBehaviour {

	public Rigidbody rb1;
	public Rigidbody rb2;

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponentInParent<Player>())
			Release();
	}

	public void Release()
	{
		rb1.isKinematic = false;
		rb2.isKinematic = false;
	}
}
