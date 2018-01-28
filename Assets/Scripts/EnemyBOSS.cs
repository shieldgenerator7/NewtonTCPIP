using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBOSS : Enemy {

    private List<EnemyBOSSAttack> attacks;
    private EnemyBOSSAttack currentAttack;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        attacks = new List<EnemyBOSSAttack>();
        attacks.AddRange(GetComponents<EnemyBOSSAttack>());
	}
	
	// Update is called once per frame
	void Update () {
        if (!isStunned())
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
	}
}
