using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDDOS : Enemy {

    private JumpAbility ja;

    protected override void Start()
    {
        base.Start();
        ja = GetComponent<JumpAbility>();
    }

    // Update is called once per frame
    void Update () {
        if (!isStunned())
        {
            ja.jump(1);
        }
	}
}
