using UnityEngine;
using System.Collections;

public class BoostAreaScript : MonoBehaviour {

    Rigidbody2D rb;
    SpriteRenderer sr;

    // Factors for the boost area
    public float boostFactor = 1;
    public float clickFactor = 1;

    float speedMultiplier; // Total speed multiplier for the boost area (normal boost + click bonus)

    bool inArea = false;

	// Use this for initialization
	void Start ()
    {
        sr = GetComponent<SpriteRenderer>();
        speedMultiplier = 1 + boostFactor * GameController.controller.rampBoost;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Check if the player clicks while in the area
        if (inArea && rb != null && Input.GetMouseButtonDown(0))
        {
            speedMultiplier += clickFactor * GameController.controller.rampClickBonus; // Add click bonus to speed multiplier
            BoostMe();
        }
    }

    // Start boost event
    void OnTriggerEnter2D(Collider2D other)
    {
        print("entrei");
        rb = other.GetComponent<Rigidbody2D>();
        inArea = true;
        sr.enabled = true;
    }

    // End boost event
    void OnTriggerExit2D(Collider2D other)
    {
        BoostMe();
    }

    // Apply boost and end boost event
    void BoostMe()
    {
        print("sai");
        inArea = false;
        rb.velocity = new Vector2(rb.velocity.x * speedMultiplier, rb.velocity.y * speedMultiplier);
        GetComponent<BoostAreaScript>().enabled = false;
        sr.enabled = false;
    }
}
