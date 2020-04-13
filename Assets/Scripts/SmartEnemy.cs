using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class SmartEnemy : MonoBehaviour, iMovement
{

  private NavMeshAgent agent;

  void Awake()
  {
    agent = GetComponent<NavMeshAgent>();
  }

  public void Initialize(WaypointManager waypointManager)
  {
    NavMeshHit closestHit;
    if (NavMesh.SamplePosition(waypointManager.waypoints[0].transform.position, out closestHit, 100f, NavMesh.AllAreas))
    {
      transform.position = closestHit.position;
      StartCoroutine(Spawn(waypointManager));
    }

  }

  IEnumerator Spawn(WaypointManager waypointManager)
  {
    yield return new WaitForSeconds(.2f);
    agent.enabled = true;
    agent.SetDestination(waypointManager.waypoints[waypointManager.waypoints.Length - 1].transform.position);
  }

  public GameObject getGameObject()
  {
    return gameObject;
  }
}
