using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamage
{
    private Transform playerTransform;

    float moveSpeed = 3;
    float rotationSpeed = 3;

    [SerializeField]
    private int HitValue = 10;

    // Use this for initialization
    void Awake ()
	{
	    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

	}

    public void Hit(int _hitValue)
    {

    }

    // Update is called once per frame
	void Update () {

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            IDamage d = (IDamage) col.gameObject.GetComponent(typeof(IDamage));
            d.Hit(HitValue);

            Destroy(gameObject);
        }
    }
}
