using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{
	private BallTrigger last;

	void Update()
	{
		Camera cam = Camera.main;
		Vector3 mousePos = Input.mousePosition;

		Ray ray = cam.ScreenPointToRay(mousePos);
		Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 100), Color.black);

		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100))
		{
			BallTrigger ballTrigger = hit.collider.gameObject.GetComponent<BallTrigger>();
			if (ballTrigger)
			{
				if (last)
					last.Off();
				last = ballTrigger;

				ballTrigger.Hover();

				if (Input.GetButtonDown("Fire1"))
				{
					ballTrigger.On();
				}
			}
		}
		else
		{
			if (last)
				last.Off();
		}
	}
}

