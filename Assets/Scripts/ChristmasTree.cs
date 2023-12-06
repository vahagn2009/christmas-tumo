
using System.Collections.Generic;
using UnityEngine;

public class ChristmasTree : MonoBehaviour
{
    [SerializeField] private List<Transform> ornamentPositions = new List<Transform>();
    [SerializeField] private List<Material> ornamentMaterials = new List<Material>();
    [SerializeField] private List<Ornament> ornamentPrefabs;
    
    private void Start()
    {
        foreach (var ornamentPosition in ornamentPositions)
        {
            if (Random.value < 1f)
            {
                var ornament = Instantiate(ornamentPrefabs[Random.Range(0, ornamentPrefabs.Count)], ornamentPosition);
                ornament.BodyRenderer.sharedMaterial = ornamentMaterials[Random.Range(0, ornamentMaterials.Count)];
                // ornament.SphereRigidbody.AddForce(Random.onUnitSphere);
            }
        }
    }
}