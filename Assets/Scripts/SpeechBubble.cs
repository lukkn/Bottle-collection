using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{

	private Quaternion rotation;

	void Awake()
	{
		rotation = transform.rotation;
	}
	
	void LateUpdate () 
	{
		transform.rotation = rotation;	
	}
}
