using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, iMovement
{
  public Waypoint currentDestination;
  public WaypointManager waypointManager;
  [SerializeField] private HealthBar healthBar;
  [SerializeField] private float maxLife = 100;
  [SerializeField] private float currentLife = 0;
  private int currentIndexWaypoint = 0;
  public float speed = 1;

    public AudioClip deathSound;
    public AudioSource speaker;

    public void Initialize(WaypointManager waypointManager)
  {
    currentLife = maxLife;
    healthBar.UpdateHealthBar(currentLife, maxLife);

    this.waypointManager = waypointManager;
    GetNextWaypoint();
    transform.position = currentDestination.transform.position; // Move to WP0
    GetNextWaypoint();
  }


  void Update()
  {
    Vector3 direction = currentDestination.transform.position - transform.position;
    if (direction.magnitude < .2f)
    {
      GetNextWaypoint();
    }

    transform.Translate(direction.normalized * speed * Time.deltaTime);
  }

  private void GetNextWaypoint()
  {
    if (currentIndexWaypoint < waypointManager.waypoints.Length)
    {
      currentDestination = waypointManager.GetNeWaypoint(currentIndexWaypoint);
      currentIndexWaypoint++;
    }
    
  }

  public GameObject getGameObject()
  {
    return gameObject;
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.transform.tag == "Weapon")
    {
      Bullet bulletThatHitMe = collision.transform.GetComponent<Bullet>();
      currentLife -= bulletThatHitMe.Damage;
      
      healthBar.UpdateHealthBar(currentLife, maxLife);

      if (currentLife <= 0) //We are dead ... need to do book keeping
      {
        //update purse
        collision.transform.GetComponent<Bullet>().myWeapon.BookKeepEnemy(this); //sends a message to the weapon to update list...
        speaker.PlayOneShot(deathSound);
        Destroy(gameObject);//if there is more than 1 weapon you have to account for it somehow
      }
      Destroy(bulletThatHitMe.gameObject);
      
    }
  }
}
