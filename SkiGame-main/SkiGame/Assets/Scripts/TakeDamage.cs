using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private float backwardForce, upForce, stunTime;
    public bool isHurt = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        PLayerEvents.playerHitEvent += TakeDmg;
    }

    private void OnDisable()
    {
        PLayerEvents.playerHitEvent -= TakeDmg;
    }

    public void TakeDmg()
    {
        if (rb != null)
        {
            rb.AddForce(transform.up * upForce);
            rb.AddForce(transform.forward * backwardForce);
        }
        isHurt = true;
        StartCoroutine(Recover());
    }

    public IEnumerator Recover()
    {
        yield return new WaitForSeconds(stunTime);
        isHurt = false;
    }
}
