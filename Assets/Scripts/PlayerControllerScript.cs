using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

    public float rotation;
    public float maxRotation = 90.0f;
    public float minRotation = -90.0f;
    public float rotationIncrement;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float rot = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -rot * rotationIncrement * Time.deltaTime);
	}
}
