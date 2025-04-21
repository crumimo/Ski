using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerEvents : MonoBehaviour
{
    public delegate void OnHit();

    public static event OnHit playerHitEvent;

    public static void CallOnHitEvent()
    {
        if (playerHitEvent != null)
        {
            playerHitEvent();
        }
    }
}