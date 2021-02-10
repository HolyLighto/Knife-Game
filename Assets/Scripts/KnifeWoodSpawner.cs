using UnityEngine;

public class KnifeWoodSpawner : MonoBehaviour
{

    public SpawnData _spawnData;
        private Knife _knife;
    void Start()
    {
        if (Random.Range(0f, 100f) <= _spawnData.SpawnChance)
        {
            var temp = Instantiate(_spawnData.SpawnObject, transform.position, transform.rotation, transform);
        }
    }
}
