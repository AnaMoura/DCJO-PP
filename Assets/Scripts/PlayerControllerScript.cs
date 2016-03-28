using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

    Rigidbody2D rb;

    public float maxSpeed = 5f; // Maximum speed for the player (maximum magnitude of the velocity vector)
    float boostValue; // The force of the boost (value from axis with low sensitivity)
    public float boostTimeLeft; // Amount of boost the player has
    public float maxBoostTime; // Maximum amount of boost allowed
    public float boostRegenValue = 0.01f; // Percentage of boost regained per second

    public float maxRotation = 90.0f; // Maximum angle value for a rotation (upper bound)
    public float minRotation = -90.0f; // Minimum angle value for a rotation (lower bound)
    public float rotationIncrement; // Amount of rotation per frame

    public float boostIncrement = 0.01f; // Amount of speed the player gains each frame from boost

    // Use this for initialization
    void Start ()
    {
        maxBoostTime = GameController.controller.maxBoostTime;
        boostTimeLeft = maxBoostTime;

        if (maxRotation < 0)
            maxRotation = 360 + maxRotation;
        if (minRotation < 0)
            minRotation = 360 + minRotation;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Get the input values from the axis
        boostValue = Input.GetAxis("Boost");
        float rot = Input.GetAxis("Horizontal");

        // Rotate the player
        transform.Rotate(0, 0, -rot * rotationIncrement * Time.deltaTime);

        // Check if player rotates off bounds and clamp the rotation
        float zAngle = transform.eulerAngles.z;
        if (zAngle > maxRotation && zAngle <= 180)
        {
            zAngle = maxRotation;
        }
        else if (zAngle < minRotation && zAngle > 180)
        {
            zAngle = minRotation;
        }
        transform.eulerAngles = new Vector3(0, 0, zAngle);
        
        // Restrict the max speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        BoostRegen(Time.deltaTime);
	}

    void FixedUpdate()
    {
        // Add the boost to the player
        if(boostValue != 0 && boostTimeLeft > 0)
        {
            boostTimeLeft -= Time.fixedDeltaTime;
            if (boostTimeLeft < 0)
                boostTimeLeft = 0;
            rb.velocity = (Vector2)transform.right * boostIncrement * boostValue + rb.velocity;
        }
    }

    void BoostRegen(float timeSinceLastFrame)
    {
        if(boostTimeLeft < maxBoostTime)
        {
            boostTimeLeft += maxBoostTime * boostRegenValue * timeSinceLastFrame;
            Mathf.Min(boostTimeLeft, maxBoostTime);
        }
    }
}
