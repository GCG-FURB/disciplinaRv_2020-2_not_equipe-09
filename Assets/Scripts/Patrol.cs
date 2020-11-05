using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour {

	public Transform[] points;
	public string Tag;

	private int destPoint = 0;
	private NavMeshAgent agent;

	void Start()
	{
	    this.agent = GetComponent<NavMeshAgent>();

	    // Disabling auto-braking allows for continuous movement
	    // between points (ie, the agent doesn't slow down as it
	    // approaches a destination point).
	    this.agent.autoBraking = false;

		if (this.Tag != null && "" != this.Tag)
		{
			GameObject[] towers = GameObject.FindGameObjectsWithTag(this.Tag);
			this.points = new Transform[] { towers[0].transform };
		}

	    this.GotoNextPoint();
	}


	void GotoNextPoint() 
	{
	    // Returns if no points have been set up
	    if (this.points.Length == 0)
		{
			return;
		}

	    // Set the agent to go to the currently selected destination.
	    this.agent.destination = this.points[destPoint].position;

	    // Choose the next point in the array as the destination,
	    // cycling to the start if necessary.
	    this.destPoint = (this.destPoint + 1) % this.points.Length;
	}


	void Update()
	{
	    // Choose the next destination point when the agent gets
	    // close to the current one.
	    if (!this.agent.pathPending && this.agent.remainingDistance < 0.5f)
		{
			this.GotoNextPoint();
		}
	}
}
