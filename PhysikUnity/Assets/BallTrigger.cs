using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour {

	new private MeshRenderer renderer = null;
	public Material off;
	public Material hover;
	public Material on;

	private bool isOn = false;

	// Use this for initialization
	void Start ()
	{
		renderer = GetComponent<MeshRenderer>();
		renderer.material = off;
	}

	public void Hover()
	{
		if (!isOn)
			renderer.material = hover;
	}

	public void Off()
	{
		if (!isOn)
			renderer.material = off;
	}

	public void On()
	{
		if (!isOn)
		{
			isOn = true;
			renderer.material = on;
			GetComponent<BridgeRelease>().Release();
		}
	}
}
