using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkedPlayerScript : NetworkBehaviour {

    CameraControllerScript cameraControllerScript;
    public PlayerControllerScript playerControllerScript;
    public SpriteRenderer spriteRenderer;

    public Sprite sprite;

    void Awake()
    {
        cameraControllerScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraControllerScript>();
    }

    public override void OnStartLocalPlayer()
    {
        playerControllerScript.enabled = true;
        cameraControllerScript.player = transform;
        spriteRenderer.sprite = sprite;

        gameObject.name = "LOCAL Player";
        base.OnStartLocalPlayer();
    }
}
