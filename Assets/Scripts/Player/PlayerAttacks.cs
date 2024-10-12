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
    private float attackForce = 30.0f;

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

    private void CheckAttackHitbox(int damage)
    {
        bool isFacingRight = transform.localScale.x > 0;
        Vector3 hitboxPosition = Vector3.zero;
    
        if (isFacingRight)
        {
            hitboxPosition = transform.position + transform.right * 0.75f;
        }
        else 
        {
            hitboxPosition = transform.position - transform.right * 0.75f;
        }
    
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(hitboxPosition, 0.5f);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemies>().ReceiveDamage(damage);
            }
        }
    }

    private void CheckAttackTrigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("LightAttack", true);
            audioSource.PlayOneShot(lightAttackSound);
            isAttacking = true;
            CheckAttackHitbox(1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("HeavyAttack", true);
            audioSource.PlayOneShot(heavyAttackSound);
            isAttacking = true;
            CheckAttackHitbox(2);
        }
        if (Input.GetKeyDown(KeyCode.Q) && playerInventory.GetShuriken() > 0)
        {
            GameObject shuriken = Instantiate(shuriKenPrefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;
            shuriken.GetComponent<Rigidbody2D>().velocity = direction * attackForce;
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
