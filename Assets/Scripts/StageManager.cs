using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public int collected = 0;
    public GameObject winPanel;
    public TMP_Text amount;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collected == 3)
            {
                winPanel.SetActive(true);
                collision.GetComponent<PlayerController>().isPaused= true;
            }
        }
    }

    public void setUI()
    {
        collected++;
        amount.text = $"{collected}/3";
    }
}
