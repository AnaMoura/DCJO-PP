using UnityEngine;
using System.Collections;

public class BoostTimeScript : MonoBehaviour {

    Rigidbody2D rb;
    public float boostFactor = 1;
    public float clickBonus = 1;

    bool inArea = false;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (inArea && rb != null && Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector2(rb.velocity.x * clickBonus, rb.velocity.y * clickBonus);
            GetComponent<PlayerStartScript>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("entrei");
        rb = other.GetComponent<Rigidbody2D>();
        inArea = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        print("sai");
        inArea = false;
        rb.velocity = new Vector2(rb.velocity.x * boostFactor, rb.velocity.y * boostFactor);
        GetComponent<BoostTimeScript>().enabled = false;
    }
}
