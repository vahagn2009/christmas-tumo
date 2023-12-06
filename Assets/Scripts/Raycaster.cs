using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{

    public Camera camera;
    [SerializeField] private List<Transform> ornamentPositions = new List<Transform>();
    [SerializeField] private List<Material> ornamentMaterials = new List<Material>();
    [SerializeField] private List<Ornament> ornamentPrefabs;

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            Ray ray = camera.ScreenPointToRay(mousePosition);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                GameObject hitObject = hitInfo.collider.gameObject;

                Debug.Log("Hit objects: " + hitObject.name);

                var ornament = Instantiate(ornamentPrefabs{Random.Range(0, 4)}, hitObject.transform.position, Random.rotation);
                Instantiate(ornament, hitObject.transform.position, Quaternion.identity);
            }        
        }
    }
}
