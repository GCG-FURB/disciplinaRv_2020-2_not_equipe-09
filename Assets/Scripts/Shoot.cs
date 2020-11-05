using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Projectile;
    public GameObject Source;

    // Update is called once per frame
    public void NewShoot()
    {
        Debug.Log("Shoot - New Projectile");

        Vector3 targetPosition = this.getTargetPosition();

        GameObject newProjectile = Instantiate(this.Projectile, this.Source.transform.position, this.Source.transform.rotation);
        newProjectile.GetComponent<Projectile>().Setup(targetPosition);
    }

    private Vector3 getTargetPosition()
    {
        GameObject aim = GameObject.Find("imgAim");
        return aim.transform.position;
    }
}
