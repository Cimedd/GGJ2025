using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayGate : MonoBehaviour
{
    public SpriteRenderer sprite;
    public BoxCollider2D boxCol;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sprite.enabled = true;
            boxCol.isTrigger = false;
        }
    }
}
