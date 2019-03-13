using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
	public Transform[] feet;
    CharacterController controller = null;
    Animator animator = null;
	Ragdoll ragdoll = null;
    public float speed = 20.0f;

    // Use this for initialization 
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
		ragdoll = GetComponent<Ragdoll>();
    }

    // Update is called once per frame 
    void Update ()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

		if (animator.parameterCount > 0)
		{
			if (animator.parameters[0].type == AnimatorControllerParameterType.Float)
			{
				int id = animator.parameters[0].nameHash;
				animator.SetFloat(id, vertical * 2);
			}
		}

		var pos = transform.position;
		Physics.Raycast(pos, Vector3.down, 1.0f);
		if (!Physics.Raycast(pos, Vector3.down, 1.0f))
		{
			ragdoll.RagdollOn = true;
		}

		if (controller.enabled)
		{
			var rot = speed;
			if (vertical < 0)
				rot *= -1;
			transform.Rotate(transform.up, horizontal * rot * Time.deltaTime);
			controller.SimpleMove(Physics.gravity);
		}
    }
}
