using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	// Start is called before the first frame update
	Transform m_target;
	void Start()
	{
		m_target = GameObject.FindWithTag("Player").transform;
	}

	// Update is called once per frame
	void Update()
    {
		transform.LookAt(m_target);
    }
}
