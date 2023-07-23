using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float spawnDelay = 10f;

    private bool playersHaveObject = false;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            if (!playersHaveObject)
            {
                // Elegir un objeto aleatorio para spawnear
                int randomIndex = Random.Range(0, objectsToSpawn.Length);
                GameObject objectToSpawn = objectsToSpawn[randomIndex];

                // Instanciar el objeto en una posición aleatoria
                Vector3 spawnPosition = new Vector3(Random.Range(0f, 10f), 0f, Random.Range(0f, 10f));
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

                // Esperar 10 segundos
                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                // Esperar hasta que los jugadores no tengan el objeto
                yield return new WaitUntil(() => !playersHaveObject);
            }
        }
    }

    public void SetPlayersHaveObject(bool value)
    {
        playersHaveObject = value;
    }
}