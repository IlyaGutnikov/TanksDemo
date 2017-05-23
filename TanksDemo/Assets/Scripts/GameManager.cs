using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonGameObject<GameManager>
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

    private int killedCount = 0;

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

    public void CountKilledEnemy()
    {
        killedCount = killedCount + 1;
    }

    public void EndGameState()
    {
        diedText.enabled = true;
        scoreText.enabled = true;

        scoreText.text = "You killed " + killedCount + " monsters";
        Time.timeScale = 0;
    }

}
