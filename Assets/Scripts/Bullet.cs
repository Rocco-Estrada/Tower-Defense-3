using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
  public float speed = 5;
  public float lifeTime = 5;
  private Rigidbody rb;
  [SerializeField] private float damage = 20;
  private WeaponFSM _myWeapon; //keep reference to pass for book keeping if enemy dies

  public float Damage
  {
    get { return damage; }
  }

  public WeaponFSM myWeapon
  {
    get { return _myWeapon; }
    set { _myWeapon = value; }
  }

  void Awake()
  {
    rb = GetComponent<Rigidbody>(); 
    rb.velocity = transform.TransformDirection(new Vector3(0,0, speed)); // sets velocity of bullet
  }
  void FixedUpdate()
  {
    lifeTime -= Time.deltaTime;
    if (lifeTime < 0) Destroy(gameObject);
  }
}
