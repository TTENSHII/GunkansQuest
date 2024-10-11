using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public AudioClip lightAttackSound = null;
    public AudioClip heavyAttackSound = null;
    private AudioSource audioSource = null;

    public GameObject shuriKenPrefab = null;

    private Animator anim = null;
    private Inventory playerInventory = null;

    public float attackCountDown = 0.2f;
    private float animationCountDown = 0.0f;

    private bool isAttacking = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerInventory = GetComponent<Inventory>();
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

    private void CheckAttackTrigger()
    {
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
        if (Input.GetKeyDown(KeyCode.Q) && playerInventory.GetShuriken() > 0)
        {
            GameObject shuriken = Instantiate(shuriKenPrefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;
            shuriken.GetComponent<Rigidbody2D>().velocity = direction * 25;
            shuriken.transform.localScale = new Vector3(0.17799f, 0.17799f, 0.17799f);
            playerInventory.RemoveShuriken(1);
        }
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
        CheckAttackTrigger();
    }
}
