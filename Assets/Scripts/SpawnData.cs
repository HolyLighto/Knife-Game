using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "Data/SpawnData")]
public class SpawnData : ScriptableObject
{
    [SerializeField, Range(0f, 100f)] private float _spawnChance;

    [SerializeField] public GameObject SpawnObject;
    public float SpawnChance { get => _spawnChance; }
}
