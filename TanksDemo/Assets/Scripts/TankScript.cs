using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour {

    [SerializeField]
    private int tankHealth = 20;

    [SerializeField]
    private int tankArmor = 10;

    [SerializeField]
    private int tankSpeed = 4;

    [SerializeField]
    private TankTurret[] turrets;

    [SerializeField]
    private GameObject turretKeeper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

    public int GetTankHealth()
    {
        return tankHealth;
    }

    public void SetTankHealth(int _tankHealth)
    {
        tankHealth = _tankHealth;
    }

    public int GetTankArmor()
    {
        return tankArmor;
    }

    public void SetTankArmor(int _tankArmor)
    {
        tankArmor = _tankArmor;
    }

    public int GetTankSpeed()
    {
        return tankSpeed;
    }
}
