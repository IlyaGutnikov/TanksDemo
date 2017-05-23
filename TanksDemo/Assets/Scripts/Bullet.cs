using System.Collections;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Enemy"))
        {
            IDamage d = (IDamage)col.gameObject.GetComponent(typeof(IDamage));
            d.TakeDamage(bulletPower);

            Destroy(this.gameObject);
        }
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
