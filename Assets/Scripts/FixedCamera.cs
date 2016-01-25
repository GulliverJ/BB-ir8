using UnityEngine;
using System.Collections;

public class FixedCamera : MonoBehaviour
{
    public GameObject target;
    public float distance;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = target.transform.position;
        transform.Translate(Vector3.forward * distance);
	}
}
