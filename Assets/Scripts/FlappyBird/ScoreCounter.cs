using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score=0;
    // Start is called before the first frame update
    public void GameOver() 
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
    public void IncreaseScore()
    {
        score++;
        print("lulz");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
