using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : CharacterModel, IDamage
{
    private Transform playerTransform;

    [SerializeField]
    private int HitValueToPlayer = 10;

    [SerializeField]
    private GameObject healthKeeper;

    // Use this for initialization
    void Awake ()
	{
	    playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        maxHealth = GetHealth();
    }

    public void TakeDamage(float _hitValue)
    {
        float _hit = _hitValue * GetArmor();

        this.SetHealth(GetHealth() - _hit);

        if (GetHealth() <= 0)
        {
            Destroy(this.gameObject);
        }

        Vector3 startScale = healthKeeper.GetComponent<SpriteRenderer>().transform.localScale;

        float percentToHealth = (100 / maxHealth) * _hit;
        float healthBarHit = (startScale.x / 100) * percentToHealth;

        healthKeeper.GetComponent<SpriteRenderer>().transform.localScale = startScale - new Vector3(healthBarHit, 0, 0);

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
            d.TakeDamage(HitValueToPlayer);

            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        GameManager.Instance.CountKilledEnemy();
    }
}
