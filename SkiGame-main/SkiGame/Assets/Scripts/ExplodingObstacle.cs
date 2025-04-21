using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingObstacle : Obstacle
{

    protected override void PlayerDetection()
    {
        Debug.Log("Player collided with: " +name);
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
    }
}
