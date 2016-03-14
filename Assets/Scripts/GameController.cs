using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController controller;

    public float rampBoost = 0.1f;
    public float rampClickBonus = 0.1f;

    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpgradeRampBoost()
    {
        if(rampBoost < 0.5f)
            rampBoost += 0.05f;
    }

    public void UpgradeRampClick()
    {
        if(rampClickBonus < 0.5f)
            rampClickBonus += 0.05f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
}
