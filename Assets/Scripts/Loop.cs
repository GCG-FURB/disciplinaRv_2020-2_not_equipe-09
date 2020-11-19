using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loop : MonoBehaviour
{

    public Button Button;
    public float ShootTime;

    private float startTime;
    private float nextShoot;

    // Start is called before the first frame update
    void Start()
    {
        this.startTime = Time.time;
        this.nextShoot = this.startTime + this.ShootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > this.nextShoot) 
        {
            this.nextShoot = Time.time + this.ShootTime;
            this.Button.onClick.Invoke();
        }
    }
}
