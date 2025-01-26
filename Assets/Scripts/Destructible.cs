using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    // Start is called before the first frame update
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
            Debug.Log("no");
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            if (player.powerUp)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("no");
            }
        }
    }
}
