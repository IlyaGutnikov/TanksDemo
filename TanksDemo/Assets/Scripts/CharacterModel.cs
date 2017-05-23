using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterModel : MonoBehaviour {

    [SerializeField]
    private int health = 20;

    [SerializeField]
    private int armor = 10;

    [SerializeField]
    private int speed = 4;

    protected int maxHealth;

    void Awake() {

        maxHealth = GetHealth();

    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int _health)
    {
        health = _health;
    }

    public int GetArmor()
    {
        return armor;
    }

    public void SetArmor(int _armor)
    {
        armor = _armor;
    }

    public int GetSpeed()
    {
        return speed;
    }

}
