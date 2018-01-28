using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVirus : Enemy
{

    public float growSpeed = 0.1f;//multiplied to the local scale
    public float sightRange = 3.0f;

    private Vector3 startSize;

    protected override void Start()
    {
        base.Start();
        startSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).sqrMagnitude <= sightRange * sightRange)
        {
            Vector3 cs = transform.localScale;
            transform.localScale += Vector3.one * (growSpeed * Time.deltaTime);
        }
        else
        {
            if (transform.localScale.sqrMagnitude > startSize.sqrMagnitude)
            {
                transform.localScale -= Vector3.one * (growSpeed * Time.deltaTime);
            }
        }
    }
}
