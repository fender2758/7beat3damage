using System.Collections;
using UnityEngine;

public class BattleCanvasManager : MonoBehaviour
{
    public GameObject heroPrefab;
    public GameObject enemyPrefab;

    public Transform heroSpawnPoint;
    public Transform enemySpawnPoint;

    private GameObject heroInstance;
    private GameObject enemyInstance;

    void Start()
    {
        StartCoroutine(SpawnCharactersWithDelay());
    }

    IEnumerator SpawnCharactersWithDelay()
    {
        yield return new WaitForSeconds(2f); // 2초 대기

        heroInstance = Instantiate(heroPrefab, heroSpawnPoint.position, Quaternion.identity, transform);
        enemyInstance = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity, transform);
    }

    void Update()
    {
        // 생성된 경우에만 회전
        if (heroInstance != null)
        {
            heroInstance.transform.Rotate(0f, 0f, 90f * Time.deltaTime); // z축 기준 회전
        }
        if (enemyInstance != null)
        {
            enemyInstance.transform.Rotate(0f, 0f, -90f * Time.deltaTime); // 반대 방향 회전
        }
    }
}
