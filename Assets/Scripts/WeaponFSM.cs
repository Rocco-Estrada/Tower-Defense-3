using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponStates
{
  Idle,
  Target,
  Shoot
}

public enum WeaponParameters
{
  isTarget,
}

public class WeaponFSM : MonoBehaviour
{
  [SerializeField] private Animator weapon;
  public GameObject target;
  public List<iMovement> enemies;

  void Awake()
  {
    enemies = new List<iMovement>();
  }
  void Update()
  {
    if (target) transform.LookAt(target.transform);
  }

  void SetTarget()
  {
    bool newTarget = (enemies.Count > 0);  //evaluates whether or not their is a new target
    target = (newTarget) ? enemies[0].getGameObject() : null;   // sets a new target if there is one
    weapon.SetBool(WeaponParameters.isTarget.ToString(), newTarget); //sends message to FSM whether or not their is a new target for animation
  }

  public void BookKeepEnemy(iMovement enemy)
  {
    enemies.Remove(enemy); //this gets called from an enemy when they die
    SetTarget();
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Enemy")
    {
      enemies.Add(other.GetComponent<iMovement>());

      if (enemies.Count > 0) SetTarget();
    }
  }

  void OnTriggerExit(Collider other)
  {
    if (other.tag == "Enemy")
    {
      enemies.Remove(other.GetComponent<iMovement>());
      SetTarget();
    }
  }
}
