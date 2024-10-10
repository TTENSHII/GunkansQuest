using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public AudioClip lightAttackSound = null;
    public AudioClip heavyAttackSound = null;
    private AudioSource audioSource = null;

    private Animator anim = null;

    public float attackCountDown = 0.2f;
    private float animationCountDown = 0.0f;

    private bool isAttacking = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnLightAttackAnimationEnd()
    {
        anim.SetBool("LightAttack", false);
        animationCountDown = attackCountDown;
        isAttacking = false;
    }

    private void OnHeavyAttackAnimationEnd()
    {
        anim.SetBool("HeavyAttack", false);
        animationCountDown = attackCountDown;
        isAttacking = false;
    }

    private void Update()
    {
        if (animationCountDown > 0)
        {
            animationCountDown -= Time.deltaTime;
            return;
        }
        if (isAttacking)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("LightAttack", true);
            audioSource.PlayOneShot(lightAttackSound);
            isAttacking = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("HeavyAttack", true);
            audioSource.PlayOneShot(heavyAttackSound);
            isAttacking = true;
        }
    }
}
