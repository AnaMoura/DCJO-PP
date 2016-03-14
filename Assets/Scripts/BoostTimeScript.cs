using UnityEngine;
using System.Collections;

public class BoostTimeScript : MonoBehaviour {

    Rigidbody2D rb;
    SpriteRenderer sr;
    public float boostFactor = 1;
    public float clickFactor = 1;
    float speedMultiplier;

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
        if (inArea && rb != null && Input.GetMouseButtonDown(0))
        {
            speedMultiplier += clickFactor * GameController.controller.rampClickBonus;
            BoostMe();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("entrei");
        rb = other.GetComponent<Rigidbody2D>();
        inArea = true;
        sr.enabled = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        BoostMe();
    }

    void BoostMe()
    {
        print("sai");
        inArea = false;
        rb.velocity = new Vector2(rb.velocity.x * speedMultiplier, rb.velocity.y * speedMultiplier);
        GetComponent<BoostTimeScript>().enabled = false;
        sr.enabled = false;
    }
}
