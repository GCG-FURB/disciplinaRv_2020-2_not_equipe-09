using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private static int deathSoundCount = 0;

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
        GameObject.Find("NewProjectileSound").GetComponent<AudioSource>().Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        this.animation += Time.deltaTime;
        this.transform.position = MathParabola.Parabola(this.initialPosition, this.target, this.Height, this.animation / this.ShootDuration);

        // Gives 1s more then shoot duration to destroy this object
        if (this.startTime + this.ShootDuration + 1 < Time.time || this.transform.position.y < 0.1)
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
            this.DestroyViking(collision.gameObject);
        }

        if (!collision.gameObject.CompareTag("Tower")) 
        {
            Debug.Log("Projectile - Destroyed by Target hit");
            Destroy(this.gameObject);
        }
    }

    void DestroyViking(GameObject gameObject) {
        Debug.Log("Projectile - Destroying Viking");

        GameObject.Find("txtScore").GetComponent<Score>().IncreaseScore();

        string sound = this.GetDeathSound();
        GameObject.Find(sound).GetComponent<AudioSource>().Play(0);

        Destroy(gameObject);
    }

    string GetDeathSound() {
        Projectile.deathSoundCount++;
        int weight = Random.Range(0, 5);

        Debug.Log("Projectile - {weight=" + weight + ", deathSoundCount=" + Projectile.deathSoundCount + "}");

        if (System.Math.Max(weight, Projectile.deathSoundCount) >= 5) {
            Projectile.deathSoundCount = 0;
            return "DeathSoundWilhelm";
        }
        return "DeathSound";
    }
}
