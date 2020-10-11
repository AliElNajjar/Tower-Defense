using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public Transform enemy;
    public Transform spawnPoint;
    public float restTime = 5f;
    private float countdown = 2f;
    public Text timerText;
    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(Spawn());
            countdown = restTime;
        }

        countdown -= Time.deltaTime;

        timerText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator Spawn()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

}
