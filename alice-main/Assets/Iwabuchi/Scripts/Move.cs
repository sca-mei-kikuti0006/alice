using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	private Rigidbody rigid;
	private Vector3 defaultPos;

	[SerializeField] bool beside = false;
	[SerializeField] bool vartical = false;

	void Start()
	{
		rigid = GetComponent<Rigidbody>();
		defaultPos = transform.position;
	}

	void FixedUpdate()
	{
		if(beside == true)
		{
			rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y, defaultPos.z + Mathf.PingPong(Time.time, 2)));
		}
		if (vartical == true)
		{
			rigid.MovePosition(new Vector3(defaultPos.x + Mathf.PingPong(Time.time, 2), defaultPos.y, defaultPos.z));
		}
	}
}
