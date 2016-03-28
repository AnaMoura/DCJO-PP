using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class BoostPickupScript : NetworkBehaviour {
    
    public float boostPickupValue = 0.1f; // Percentage of boost regained from pickup

    SpriteRenderer[] renderers;
    Collider2D collider;

    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControllerScript pcScript = other.GetComponent<PlayerControllerScript>();
        float maxBoostTime = pcScript.maxBoostTime;
        pcScript.boostTimeLeft += maxBoostTime * boostPickupValue;
        CmdPickupBoost(gameObject);
    }

    [Command]
    void CmdPickupBoost(GameObject pickup)
    {
        RpcResolvePickup(pickup);
    }

    [ClientRpc]
    void RpcResolvePickup(GameObject pickup)
    {
        ToggleRenderer(false);
        ToggleCollider(false);

        Invoke("Respawn", 2f);
    }

    void ToggleCollider(bool active)
    {
        collider.enabled = active;
    }

    void ToggleRenderer(bool active)
    {
        for (int i = 0; i < renderers.Length; i++)
            renderers[i].enabled = active;
    }

    void Respawn()
    {
        ToggleCollider(true);
        ToggleRenderer(true);
    }
}
