﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AgentController : MonoBehaviour 
{
	// the types of agent we will have
	public enum AgentType 
	{
		Idle = 0,
		Patrolling,
		Chasing
	}

	// what type is this agent?
	public AgentType type;

	// the waypoints the agent will follow 
	public Transform[] waypoints;
	public float distanceToStartHeadingToNextWaypoint = 1;
	private int waypointId = 0;

	// NavmeshAgent reference
	public NavMeshAgent navMeshAgent;

	// animator reference and hashid for walkingSpeed parameter
	public Animator animController;
	private int speedHashId;

	public Transform target;
	public float distanceToStartChasingTarget = 15f;
	public int distanceToStartAttackingTarget = 7;
	int attackHashId;

	void Awake()
	{
		// create hashid for the "speed" param of the Animator
		speedHashId = Animator.StringToHash ("walkingSpeed");
		attackHashId = Animator.StringToHash ("attack");

		// if no waypoints have been assigned (so many students forget to do this so this will throw an informative error for you!
		if (waypoints.Length == 0) 
		{
			Debug.LogError("ARGHHHHHHHH!!! You need to assign some waypoints within the Inspector!");
			enabled = false;
			return;
		}
	}

	void Chase () 
	{
		Vector3 directionToTarget = transform.position - target.position;
		navMeshAgent.SetDestination (target.position);
		int angleToTarget = (int) Mathf.Abs (Vector3.Angle (transform.forward, directionToTarget));

		if (navMeshAgent.remainingDistance < distanceToStartAttackingTarget) Attack ();

		if (angleToTarget >= 90 && navMeshAgent.remainingDistance < distanceToStartChasingTarget && navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance) 
		{
			navMeshAgent.Resume ();
			animController.SetFloat (speedHashId, 1.0f);
		} 
		else 
		{
			Idle ();
		}
	}

	void Attack() 
	{
		animController.SetTrigger (attackHashId);
	}

	void Update()
	{
		if (type == AgentType.Idle) Idle();

		// TODO: add an else test for if the type is Patrolling and call the Patrol method
		else if (type == AgentType.Patrolling) Patrol();
		else if (type == AgentType.Chasing) Chase();
	}

	void Idle() 
	{
		// TODO: stop navmesh to stop movement
		navMeshAgent.Stop();

		// set speed to 0 to stop anim
		animController.SetFloat (speedHashId, 0.0f);
	}

	void Patrol()
	{
		// TODO: tell the navmeshagent to resume (when idling we tell it to stop)
		navMeshAgent.Resume();

		// set Animator "speed" parameter to 1.0f to trigger walking anim
		animController.SetFloat (speedHashId, 1.0f);

		// TODO: if remainingDistance from navMeshAgent is less than distanceToStartHeadingToNextWaypoint	
		if (navMeshAgent.remainingDistance < distanceToStartHeadingToNextWaypoint)
		{
			// TODO: then start heading toward next waypoint...
			waypointId++;

			// TODO: loop to first waypoint if out of waypoints
			if (waypointId >= waypoints.Length) waypointId = 0;

			// TODO: set the NavMesh Destination property with the new waypoint position
			navMeshAgent.SetDestination(waypoints[waypointId].position);
		}
	}


}