using UnityEngine;
using System.Collections;

public class CameraControllerScript : MonoBehaviour {

    public Transform player; // Reference to the player's transform.

    public float yMargin = 1f; // Distance in the y axis the player can move before the camera follows.
    public float minY; // The minimum y coordinate the camera can have.

    private bool CheckYMargin()
    {
        // Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        float targetX = player.position.x + 15;
        float targetY = transform.position.y;

        // If the player has moved beyond the y margin then the camera must follow the player but keep the margin
        if (transform.position.y - player.position.y > yMargin) // the player is below the camera
        {
            targetY = player.position.y + yMargin; // the target y coordinate should be the player's current y position plus the y margin
        }
        else if(transform.position.y - player.position.y < -yMargin) // the player is above the camera
        {
            targetY = player.position.y - yMargin; // the target y coordinate should be the player's current y position minus the y margin
        }

        // The target y coordinates should not be smaller than the minimum.
        targetY = Mathf.Max(targetY, minY);

        // Set the camera's position to the target position with the same z component.
        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
