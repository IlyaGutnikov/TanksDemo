using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterModel : MonoBehaviour {

    [SerializeField]
    private float health;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float armor;

    [SerializeField]
    private float speed;

    protected float maxHealth;

    void Awake() {

        maxHealth = GetHealth();

    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float _health)
    {
        health = _health;
    }

    public float GetArmor()
    {
        return armor;
    }

    public void SetArmor(float _armor)
    {
        armor = _armor;
    }

    public float GetSpeed()
    {
        return speed;
    }

}
