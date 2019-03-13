using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour {

	public bool FixX;
	public bool FixY;
	public bool FixZ;

	public Vector3 initial;

	// Use this for initialization
	void Start ()
	{
		initial = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update ()
	{
		var temp = transform.rotation.eulerAngles;

		if (FixX)
			temp.x = initial.x;
		if (FixY)
			temp.y = initial.y;
		if (FixZ)
			temp.z = initial.z;

		transform.rotation = Quaternion.Euler(temp);
	}
}
