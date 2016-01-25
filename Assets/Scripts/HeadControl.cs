using UnityEngine;
using System.Collections;

public class HeadControl : MonoBehaviour
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
        lookTarget = Quaternion.LookRotation(Vector3.right);

        if(lookTarget != transform.rotation)
            transform.rotation = Quaternion.Slerp(transform.rotation, lookTarget, Time.deltaTime * speed);
	}
}
