using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(TankScript))]
public class PlayerControlls : MonoBehaviour
{
    float gas = 0;
    float rotate = 0;

    private Rigidbody2D tankRigidbody;
    private TankScript tankScript;

    void Awake()
    {
        tankRigidbody = gameObject.GetComponent<Rigidbody2D>();
        tankScript = gameObject.GetComponent<TankScript>();

        if (tankRigidbody == null)
        {
            Debug.LogError("Missed Rigidbody");
        }

        if (tankScript == null)
        {
            Debug.LogError("Missed tankScript");
        }
    }

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    GetTankMoves();
	    ChangeTankWeapon();
	    Shoot();
	}

    void FixedUpdate()
    {
        //Move
        Vector2 move = (Vector2) transform.up * gas * Time.deltaTime * tankScript.GetTankSpeed();
        tankRigidbody.MovePosition(tankRigidbody.position + move);

        //Rotate
        tankRigidbody.MoveRotation(tankRigidbody.rotation - rotate * tankScript.GetTankSpeed() * 10 * Time.fixedDeltaTime);
    }

    private void GetTankMoves()
    {
        gas = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");
    }

    private void ChangeTankWeapon()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            tankScript.ChangeTurret(false);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            tankScript.ChangeTurret(true);
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            tankScript.Shoot();
        }
    }
}
