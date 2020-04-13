﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHP : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private float maxLife = 100;
    [SerializeField] private float currentLife;

    void Start()
    {
        currentLife = maxLife;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Enemy enemyThatHitMe = collision.transform.GetComponent<Enemy>();
            currentLife -= 20;

            healthBar.UpdateHealthBar(currentLife, maxLife);

            if (currentLife <= 0) //Game Over ... Restart?
            {
                print("Game Over");
            }
            Destroy(enemyThatHitMe.gameObject);

        }
    }

}