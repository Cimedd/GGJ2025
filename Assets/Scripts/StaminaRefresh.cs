using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StaminaRefresh : MonoBehaviour
{
    public TMP_Text indicator;
    public float fuel = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        indicator.enabled = true;
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if(player.stretch == 100f)
            {
                indicator.text ="Stamina is full";
            }
          
            if(fuel > 0f)
            {
                float add = player.stretch + fuel;
                if (add > 100f)
                {
                    player.stretch = 100f;
                    fuel = add - 100;
                }
                else
                {
                    player.stretch = add;
                }

            }
            else
            {
                indicator.text = "fuel is empty";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        indicator.enabled = false;
    }
}
