using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private Spawn spawnprefab;
    [SerializeField] private float spawnDurationInSeconds = 2f;

    private SpawnShooter spawnShooter;

    // Start is called before the first frame update
    void Start()
    {
        spawnShooter = GetComponent<SpawnShooter>();
        NewSpawn();
    }

    void NewSpawn()
    {
        spawnShooter.ChangeCurrentSpawn(Instantiate(spawnprefab.gameObject, transform.position, transform.rotation).GetComponent<Spawn>());
    }

    private void OnTriggerExit(Collider other)
    {
        Invoke(nameof(NewSpawn), spawnDurationInSeconds);
    }

}
