using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject Projectile;
    public GameObject Source;
    public GameObject Camera;

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
        Vector3 targetPosition = this.Camera.transform.position;
        while (targetPosition.y > 0)
        {
            targetPosition += this.Camera.transform.forward;
        }
        return targetPosition;
    }
}
