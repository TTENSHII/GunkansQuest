using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private Transform firePoint = null;
    [SerializeField] private float fireRate = 2.0f;
    [SerializeField] private float range = 15.0f;
    
    private GameObject player = null;
    private Animator anim = null;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        StartCoroutine(Fire());
    }

    private bool IsPlayerInRange()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= range &&
        player.transform.position.x < transform.position.x)
        {
            return true;
        }
        return false;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10.0f, ForceMode2D.Impulse);
        anim.SetTrigger("Fire");
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            if (IsPlayerInRange())
            {
                Shoot();
            }
        }
    }
}
