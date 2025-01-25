using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(collision.collider.GetComponent<PlayerController>().Popped());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
    
    }
}
