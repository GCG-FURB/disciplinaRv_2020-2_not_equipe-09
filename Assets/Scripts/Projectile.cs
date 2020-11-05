using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector3 initialPosition;
    private Vector3 target;
    private float animation;
    private float startTime;

    public float Height;
    public float ShootDuration;

    public void Setup(Vector3 target) 
    {
        this.target = target;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.startTime = Time.time;
        this.initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.animation += Time.deltaTime;
        this.transform.position = MathParabola.Parabola(this.initialPosition, this.target, this.Height, this.animation / this.ShootDuration);

        // Gives 1s more then shoot duration to destroy this object
        if (this.startTime + this.ShootDuration + 1 < Time.time)
        {
            Debug.Log("Projectile - Destroyed by timeout");
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) 
    { 
        Debug.Log("Projectile - Collision {name=" + collision.gameObject.name + ", tag=" + collision.gameObject.tag + "}");
    	if (collision.gameObject.CompareTag("Viking"))
        {
            Debug.Log("Projectile - Destroying Viking");
            Destroy(collision.gameObject);
        }

        if (!collision.gameObject.CompareTag("Tower")) 
        {
            Debug.Log("Projectile - Destroyed by Target hit");
            Destroy(this.gameObject);
        }
    }
}
