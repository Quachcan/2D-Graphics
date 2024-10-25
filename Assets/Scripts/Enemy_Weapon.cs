using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Weapon : MonoBehaviour
{
    public Transform EnemyFirePoint;
    public GameObject EnemyBulletPrefab;

//Animator animator;
    Rigidbody2D rb;
    Transform player;
    Animator animator;
    //Behemoth_Run behemoth_run;
    private float RangedAttackRange = 3f;
    private float MeleeAttack = 1f;
    float nextAttackTime = 0f;
    public float attackRate = 2f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player")?.transform;
        if (player == null )
        {
            Debug.LogError("No object found with tag 'Player' found.");
        }
        //behemoth_run = GetComponent<Behemoth_Run>();
        //if ( behemoth_run == null )
        //{
        //    Debug.LogError("Behemoth_Run component not found.");
        //}

    }
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position, rb.position);
        if (distanceToPlayer <= MeleeAttack && Time.time >= nextAttackTime)
        {
            animator.SetTrigger("Attack");
            nextAttackTime = Time.time + 1f / attackRate;
        }
        else if (distanceToPlayer > RangedAttackRange && Time.time >= nextAttackTime)
        {
            Debug.Log("shooting");
            Shoot();
            animator.SetTrigger("Attack2");
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot method called");
        Instantiate(EnemyBulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
    }
}
