using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : CharacterModel, IDamage
{
    [SerializeField]
    private TankTurret[] turrets;

    [SerializeField]
    private GameObject turretKeeper;

    [SerializeField]
    private GameObject healthKeeper;

    void Awake()
    {
        maxHealth = GetHealth();
    }

    // Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(float _hitValue)
    {

        float _hit = _hitValue * GetArmor();

        SetHealth(GetHealth() - _hit);

        if (GetHealth() <= 0)
        {
           GameManager.Instance.EndGameState();
        }

        Vector3 startScale = healthKeeper.GetComponent<SpriteRenderer>().transform.localScale;

        float percentToHealth = (100 / maxHealth) * _hit;
        float healthBarHit = (startScale.x / 100) * percentToHealth;

        healthKeeper.GetComponent<SpriteRenderer>().transform.localScale = startScale - new Vector3(healthBarHit, 0, 0);
    }

    public void Shoot()
    {
        TankTurret turret = turretKeeper.GetComponentInChildren<TankTurret>();
        turret.Shoot();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nextWeapon">If true - next weapon, if false - previous weapon</param>
    public void ChangeTurret(bool nextWeapon)
    {
        int turretCounter = 0;
        int nextTurret = 0;

        TankTurret prevTankTurret = turretKeeper.GetComponentInChildren<TankTurret>();

        for (int i = 0; i < turrets.Length; i++)
        {
            if (turrets[i].id == prevTankTurret.id)
            {
                turretCounter = i;
            }
        }

        Destroy(prevTankTurret.gameObject);

        if (nextWeapon)
        {
            if (turretCounter == turrets.Length - 1)
            {
                nextTurret = 0;
            }
            else
            {
                nextTurret = turretCounter + 1;
            }
        }
        else
        {
            if (turretCounter == 0)
            {
                nextTurret = turrets.Length - 1;
            }
            else
            {
                nextTurret = turretCounter - 1;
            }
        }

        Instantiate(turrets[nextTurret], turretKeeper.transform);
    }
}
