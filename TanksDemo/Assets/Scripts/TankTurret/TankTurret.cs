using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTurret : MonoBehaviour
{
    public int id;

    private bool canShoot = true;

    [SerializeField]
    private float delay;

    [SerializeField]
    private GameObject ammo;

    [SerializeField]
    private float bulletPower;

    [SerializeField]
    private float bulletSpeed;

    public void Shoot()
    {
        if (canShoot)
        {
            GameObject bullet = Instantiate(ammo, gameObject.transform.position, gameObject.transform.rotation);
            bullet.GetComponent<Bullet>().SetBulletPower(this.bulletPower);
            bullet.GetComponent<Bullet>().SetBulletSpeed(this.bulletSpeed);

            bullet.GetComponent<Bullet>().AddSpeed();

            canShoot = false;
        }
        else
        {
            StartCoroutine(waitForReload());
        }
    }

    IEnumerator waitForReload()
    {
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canShoot = true;

    }
}


