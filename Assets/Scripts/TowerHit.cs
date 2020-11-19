using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHit : MonoBehaviour {

    public Text TowerHealthText;
    public GameObject GameOverText;

    public int TowerHealthLimit;
    private int towerHealth;

    void Awake()
    {
    	Debug.Log("TowerHit - Starting");
    	this.towerHealth = this.TowerHealthLimit;
    	this.updateTowerHealthText();
    }


    void OnCollisionEnter(Collision collision)
    {
    	if (collision.gameObject.CompareTag("Viking")) //  TODO Implements a delay for another Hit --- Map<GameObject, Time> nextHitTimeByObject
        {
            Debug.Log("Tower HIT!");
            this.towerHealth--;
            this.updateTowerHealthText();

            if (this.towerHealth <= 0)
            {
                this.gameOver();
            }
        }
    }
    
    private void updateTowerHealthText()
    {
        this.TowerHealthText.text = "Tower Energy: " + this.towerHealth.ToString() + "/" + this.TowerHealthLimit.ToString();
    }

    private void gameOver()
    {
        Time.timeScale = 0;
        this.GameOverText.SetActive(true);
        this.GameOverText.GetComponent<AudioSource>().Play(0);
    }
}
