using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : CharacterModel, IDamage
{
    private Transform playerTransform;

    [SerializeField]
    private int HitValue = 10;

    [SerializeField]
    private GameObject healthKeeper;

    // Use this for initialization
    void Awake ()
	{
	    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        maxHealth = GetHealth();
    }

    public void TakeDamage(int _hitValue)
    {
        Vector3 startScale = healthKeeper.GetComponent<SpriteRenderer>().transform.localScale;
        SetHealth(maxHealth - _hitValue);

        float percentToHealth = (100 / maxHealth) * _hitValue;
        float healthBarHit = (startScale.x / 100) * percentToHealth;

        healthKeeper.GetComponent<SpriteRenderer>().transform.localScale = startScale - new Vector3(healthBarHit, 0, 0);

        if (GetHealth() <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
	void Update () {

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, GetSpeed() * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            IDamage d = (IDamage) col.gameObject.GetComponent(typeof(IDamage));
            d.TakeDamage(HitValue);

            Destroy(gameObject);
        }
    }
}
