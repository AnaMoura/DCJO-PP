using UnityEngine;
using System.Collections;

public class LeaveRampScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerControllerScript>().enabled = true; // Enable the player controller
        other.GetComponent<Rigidbody2D>().drag = 0.7f;
    }
}
