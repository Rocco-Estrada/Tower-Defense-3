using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
  [SerializeField] private GameObject bullet;
  void Bang()
  {
    //Debug.Log("Pow");
    Bullet shotJustFired = Instantiate(bullet, transform.position, transform.parent.rotation).GetComponent<Bullet>();
    shotJustFired.myWeapon = transform.parent.GetComponent<WeaponFSM>();
  }
}
