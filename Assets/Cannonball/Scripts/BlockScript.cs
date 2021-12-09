using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockScript : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.tag=="CannonBall")
    //     {
    //         print("hit");
    //     }
    // }   
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="CannonBall")
        {
            score += 10;
            scoreText.text= "Score: "+score.ToString();
        }
    }
}
