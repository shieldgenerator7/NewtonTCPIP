using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBOSS : Enemy {

    public GameObject internalCheckpoint;
    public Vector3 deadScale = Vector3.one;
    private Vector3 startScale;

    private List<EnemyBOSSAttack> attacks;
    private EnemyBOSSAttack currentAttack;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        attacks = new List<EnemyBOSSAttack>();
        attacks.AddRange(GetComponents<EnemyBOSSAttack>());
        startScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isStunned() && !dead)
        {
            if (currentAttack == null)
            {
                currentAttack = attacks[Random.Range(0, attacks.Count - 1)];
                currentAttack.startAttack();
            }
            currentAttack.processAttack();
            if (currentAttack.isFinished())
            {
                currentAttack.finish();
                currentAttack = null;
            }
        }
        if (dead)
        {
            if (transform.localScale.sqrMagnitude > deadScale.sqrMagnitude)
            {
                transform.localScale *= 0.9f;
                //transform.localScale = Vector3.MoveTowards(
                //    transform.localScale,
                //    deadScale,
                //    0.25f);
            }
        }
	}

    public void kill()
    {
        dead = true;
        internalCheckpoint.transform.parent = null;
        currentAttack.finish();
        currentAttack = null;
        GetComponent<JumpAbility>().cancelJump();
    }
}
