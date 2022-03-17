using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPickup : Pickup
{
    public override void OnPickup(Collider other)
    {
        GameManager.Instance.GameIsOver();
    }

}
