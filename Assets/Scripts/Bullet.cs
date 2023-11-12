﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public bool playerBullet;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Xu ly va cham cua bullet voi player, enemy
        if (other.CompareTag("Player") && !playerBullet)
        {
            int damage = Random.Range(minDamage, maxDamage);
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Enemy") && playerBullet)
        {
            int damage = Random.Range(minDamage, maxDamage);
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        // Xu ly va cham cua bullet voi obstacle
        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}