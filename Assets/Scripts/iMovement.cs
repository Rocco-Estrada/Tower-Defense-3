using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface iMovement
{
  void Initialize(WaypointManager waypointManager);
  GameObject getGameObject();
}
