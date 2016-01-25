using UnityEngine;
using System.Collections;

public class RollControl : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody body;

	// Use this for initialization
	void Start ()
    {
        body = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            body.AddForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.Force);
            //transform.Rotate(3,0,0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            body.AddForce(Vector3.forward * -moveSpeed * Time.deltaTime, ForceMode.Force);
            //transform.Rotate(-3, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector3.right * -moveSpeed * Time.deltaTime, ForceMode.Force);
        }

        else
        {
            body.AddForce(-body.velocity, ForceMode.Force);
            if (body.velocity.magnitude <= 0.1f)
                body.velocity = Vector3.zero;
        }
            
        
	}
}
