using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private Text diedText;

    [SerializeField] 
    private Text scoreText;

    [SerializeField]
    private int monsterCount = 10;

    [SerializeField]
    private GameObject[] enemies;

    private GameObject _player;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
	void Start () {

        for (int i = 0; i < monsterCount; i++)
        {
            MonsterSpawn();
        }
	}
	
	// Update is called once per frame
	void Update () {

	    if (_player.GetComponent<CharacterModel>().GetHealth() <= 0)
	    {
            //TODO
            
	    }
	}

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
        {
            MonsterSpawn();
        }
    }

    private void MonsterSpawn()
    {
        Vector3 v3Pos = new Vector3(Random.Range(-3, 3), Random.Range(3,6), -1);

        v3Pos = camera.ViewportToWorldPoint(v3Pos);

        GameObject _enemy = Instantiate(enemies[Random.Range(0, enemies.Length - 1)]);
        _enemy.transform.position = v3Pos;
    }
}
