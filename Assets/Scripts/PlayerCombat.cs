using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack1();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Attack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
       
    }
    void Attack1()
    {
        animator.SetTrigger("Attack1");
       
    }
    void Attack2()
    {
        animator.SetTrigger("Attack2");
    }
}
