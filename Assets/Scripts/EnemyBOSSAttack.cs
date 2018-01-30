using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBOSSAttack : MonoBehaviour
{

    public float movementSpeed = 3.0f;
    public float jumpAmount = 0.0f;
    public bool allowRotate = false;
    public float duration = 3.0f;//how long the attack lasts
    public float bossCooldownDuration = 2.0f;//how long the boss pauses after this attack
    public List<GameObject> enemyPrefabs;//the list of enemies that can spawn on this attack
    public int enemySpawnAmount = 3;//how many random enemies to spawn
    public float enemySpawnDelay = 0.5f;//how long between each enemy spawn
    public float throwScale = 0.5f;

    private float movementDirection;
    private float startTime = 0;//0 = not started
    private float enemiesSpawned = 0;
    private float lastEnemySpawnTime = 0;
    private Quaternion startRotation;
    private JumpAbility ja;
    private Rigidbody rb;
    private PlayerController pc;

    private void Start()
    {
        ja = GetComponent<JumpAbility>();
        rb = GetComponent<Rigidbody>();
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        startRotation = transform.rotation;
    }

    public void startAttack()
    {
        startTime = Time.time;
        lastEnemySpawnTime = 0;
        enemiesSpawned = 0;

        if (allowRotate)
        {
            rb.freezeRotation = false;
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }
        else
        {
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            transform.rotation = startRotation;
        }

        movementDirection = Mathf.Sign(pc.gameObject.transform.position.x - transform.position.x);
    }

    /// <summary>
    /// Called by the EnemyBOSS script
    /// </summary>
	public void processAttack()
    {
        //Spawn enemies
        if (enemyPrefabs.Count > 0
            && enemiesSpawned < enemySpawnAmount
            && Time.time > lastEnemySpawnTime + enemySpawnDelay)
        {
            enemiesSpawned++;
            lastEnemySpawnTime = Time.time;
            int randex = Random.Range(0, enemyPrefabs.Count);
            GameObject enemy = GameObject.Instantiate(enemyPrefabs[randex]);
            enemy.transform.position = transform.position + Vector3.up * transform.localScale.y * 2;
            enemy.GetComponent<Rigidbody>().velocity = 
                rb.velocity 
                + Vector3.up 
                + (Vector3.right * (pc.gameObject.transform.position.x - transform.position.x)*throwScale);
            enemy.GetComponent<Enemy>().stun(1.5f);
            enemy.AddComponent<OnTouchDestroy>();
            SceneManager.MoveGameObjectToScene(enemy, LevelManager.Level);
        }
        if (jumpAmount > 0)
        {
            ja.jump(1);
        }
        if (movementSpeed != 0)
        {
            rb.velocity = new Vector3(movementDirection * movementSpeed, rb.velocity.y);
        }
    }

    /// <summary>
    /// True if this attack should end
    /// </summary>
    /// <returns></returns>
    public bool isFinished()
    {
        return Time.time > startTime + duration;
    }
    public void finish()
    {
        startTime = 0;
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        transform.rotation = startRotation;
    }
}
