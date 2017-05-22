﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int bulletPower = 0;
    private int bulletSpeed = 0;

    void Start()
    {
        StartCoroutine(destroyBullet());
    }

    public void SetBulletPower(int _power)
    {
        bulletPower = _power;
    }

    public void SetBulletSpeed(int _speed)
    {
        bulletSpeed = _speed;
    }

    public int GetBulletPower()
    {
        return bulletPower;
    }

    public void AddSpeed()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}