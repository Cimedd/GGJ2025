using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool isOpening = false;
    public float countTime = 0;
    public float maxTime = 5;
    [SerializeField] private Vector3 originalPostion;
    // Start is called before the first frame update
    void Start()
    {
        originalPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(maxTime != countTime)
        {
            if (isOpening)
            {
                if (countTime < maxTime)
                {
                    transform.Translate(0, -2 * Time.deltaTime, 0);
                    countTime += Time.deltaTime * 1;
                }
            }
        }

        if (!isOpening && transform.position != originalPostion)
        {
            if(countTime < maxTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, originalPostion, 2 * Time.deltaTime);
                countTime -= Time.deltaTime * 1;
                countTime = Mathf.Clamp(countTime, 0, maxTime);
            }
          
        }
    }
}
