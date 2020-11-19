using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        this.count = 0;
    }

    public void IncreaseScore() 
    {
        this.count++;
        this.GetComponent<Text>().text = "Score: " + this.count;
    }
}
