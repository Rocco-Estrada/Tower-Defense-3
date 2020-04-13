using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
  void Update()
  {
    transform.parent.rotation = Camera.main.transform.rotation;
  }

  public void UpdateHealthBar(float heath, float maxHealth)
  {
    transform.localScale = new Vector3( (heath/maxHealth), transform.localScale.y, transform.localScale.z);
  }


}
