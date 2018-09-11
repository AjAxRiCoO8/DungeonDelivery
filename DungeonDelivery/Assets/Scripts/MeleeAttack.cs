using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    [SerializeField]
    private GameObject weaponSprite;

    private float rotationSpeed;

    private Animator animator;

    private void Start()
    {
        animator = weaponSprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
		// Rotate from 46 to 91 on the z axis

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Debug.Log("MouseClick");
            animator.Play("WeaponRotation");
        }
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Do stuff
        }
    }
}
