using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	[SerializeField, DisappearAttachedField]
	Rigidbody rigidbody = null;

	void Reset()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
}
