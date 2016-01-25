using UnityEngine;
using System.Collections;

public class VectorControl : MonoBehaviour
{
    public float resolution;
    float xcontrol;
    float yControl;
    float zControl;
    public float powerResolution;
    public Rigidbody droid;
    public GameObject arrow;
    public Vector3 direction;
    public float power;
    public int powerDirection = 1;
    public float max;
    public float min;
	
	// Update is called once per frame
	void Update ()
    {
        power += powerResolution * powerDirection;
        if (power >= max)
            powerDirection = -1;
        if (power <= min)
            powerDirection = 1;

        xcontrol += Random.Range(-resolution, resolution);
        yControl += Random.Range(-resolution * 2, resolution * 2);
        zControl += Random.Range(-resolution, resolution);
        direction = new Vector3(xcontrol, yControl, zControl);
        //droid.velocity += direction.normalized * power;
        //droid.AddForce(direction.x, direction.y, direction.z, ForceMode.Impulse);

        Object[] objects = FindObjectsOfType(typeof(GameObject));                          // Find all game objects
        foreach (GameObject go in objects)                                                  // For each of them...
        {
            if (go.tag == "PhysObj")
            {
                Rigidbody body = go.GetComponent<Rigidbody>();
                body.AddForce(direction.x, direction.y, direction.z, ForceMode.Impulse);
            }
        }

        arrow.transform.rotation = Quaternion.Lerp(arrow.transform.rotation, new Quaternion(direction.x, direction.y, direction.z, 0), Time.deltaTime * 10);
	}
}
