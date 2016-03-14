using UnityEngine;
using System.Collections;

public class SpawnControlScript : MonoBehaviour {

    public Transform player; // Reference to the player's transform.

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float targetX = player.position.x + 40;

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, 2, transform.position.z);
    }
}
