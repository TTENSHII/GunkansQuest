using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private AudioClip lightAttackSound = null;
    [SerializeField] private AudioClip heavyAttackSound = null;
    [SerializeField] private GameObject shuriKenPrefab = null;

    [SerializeField] private float heavyAttackCooldown = 1.0f;
    [SerializeField] private float lightAttackCooldown = 0.3f;
    [SerializeField] private float shurikenThrowForce = 30.0f;

    private AudioSource audioSource = null;
    private Inventory playerInventory = null;
    private Animator anim = null;
    private bool canSwordAttack = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        playerInventory = GetComponent<Inventory>();
    }

    private void OnAttackCoolDownEnd()
    {
        canSwordAttack = true;
    }

    private void OnLightAttackAnimationEnd()
    {
        anim.SetBool("LightAttack", false);
        Invoke("OnAttackCoolDownEnd", lightAttackCooldown);
    }

    private void OnHeavyAttackAnimationEnd()
    {
        anim.SetBool("HeavyAttack", false);
        Invoke("OnAttackCoolDownEnd", heavyAttackCooldown);
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
    
    private void CheckSwordAttackTrigger()
    {
        if (!canSwordAttack) return;

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("LightAttack", true);
            audioSource.PlayOneShot(lightAttackSound);
            canSwordAttack = false;
            CheckAttackHitbox(1);
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("HeavyAttack", true);
            audioSource.PlayOneShot(heavyAttackSound);
            canSwordAttack = false;
            CheckAttackHitbox(2);
        }
    }

    private void CheckShurikenThrowTrigger()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerInventory.shurikens > 0)
        {
            GameObject shuriken = Instantiate(shuriKenPrefab, transform.position, Quaternion.identity);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;
            shuriken.GetComponent<Rigidbody2D>().velocity = direction * shurikenThrowForce;
            shuriken.transform.localScale = new Vector3(0.17799f, 0.17799f, 0.17799f);
            playerInventory.RemoveShuriken(1);
        }
    }

    private void Update()
    {
        CheckSwordAttackTrigger();
        CheckShurikenThrowTrigger();
    }
}
