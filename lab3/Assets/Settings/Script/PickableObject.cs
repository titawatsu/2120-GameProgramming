using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PowerupCollectible powerupCollectible;

    [SerializeField] private SpriteRenderer sRenderer;

    [SerializeField] private float spawnDelay = 4f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sRenderer.enabled = false;
            Debug.Log(powerupCollectible.GetCollectibleType());
            StartCoroutine(RespawnPickable());
        }
    }
    public IEnumerator RespawnPickable()
    {
        yield return new WaitForSeconds(spawnDelay);
        sRenderer.enabled = true;

    }

}
