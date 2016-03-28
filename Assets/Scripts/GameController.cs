using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController controller;

    // Upgradable stats
    public float rampBoost = 0.1f;
    public float rampClickBonus = 0.1f;
    public float maxBoostTime = 3f;

    void Awake()
    {
        // Simulate a singleton class keeping the same GameObject from scene to scene
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
