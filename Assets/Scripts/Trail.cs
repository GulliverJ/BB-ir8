using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour
{
    Transform bodyPosition;
    public float speed;
    Quaternion lookTarget;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        lookTarget = Quaternion.LookRotation(-Vector3.right);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookTarget, Mathf.Infinity);
	}
}
