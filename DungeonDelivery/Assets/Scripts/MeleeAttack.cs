using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    [SerializeField]
    private GameObject weaponSprite;

    private float rotationSpeed;
    private bool isAttacking;

    private Animator animator;

    private void Start()
    {
        isAttacking = false;
        animator = weaponSprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        // Rotate from 46 to 91 on the z axis

        if (Input.GetKey(KeyCode.Mouse0) && !animator.GetCurrentAnimatorStateInfo(0).IsName("WeaponRotation"))
        {
            animator.Play("WeaponRotation");
            isAttacking = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 && animator.IsInTransition(0))
            isAttacking = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (isAttacking)
            {
                collision.GetComponent<Health>().TakeDamage(20);
                isAttacking = false;
            }
        }
    }
}
