using System;
using System.Collections;
using Auki.ConjureKit;
using Auki.ConjureKit.Odal;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class ChristmasFestivity : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform environment;
    [SerializeField] private Button placeButton;
    
    [Header("Configuration")]
    [SerializeField] private float environmentPlaceDistance = 2; // meters from camera

    private bool _isEnvironmentPlaced;
    private Vector3 _envireonmentToCameraOffset;

    private IConjureKit _conjureKit;

    private void Start()
    {
        placeButton.onClick.AddListener(OnPlaceButtonSelected);
        
        _conjureKit = new ConjureKit(
            cameraTransform,
            "a1c33eaf-69ae-43de-950a-151c96dcd840",
            "53c28fbc-1b36-42ef-a05a-7ed169a47b5eab80c4b0-71cd-4ad2-ad1c-df7a05cda461");
        
        _conjureKit.Connect();

        _envireonmentToCameraOffset = environment.position - cameraTransform.position;
    }

    private void OnPlaceButtonSelected()
    {
        _isEnvironmentPlaced = true;
        placeButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!_isEnvironmentPlaced)
        {
            environment.transform.position = cameraTransform.position + _envireonmentToCameraOffset;
            // environment.transform.LookAt(cameraTransform);
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(CreateAddressableAsset());
        }
    }

    private IEnumerator CreateAddressableAsset()
    {
        string key = "panda";
        AsyncOperationHandle<GameObject> loadOp = Addressables.LoadAssetAsync<GameObject>(key);
        yield return loadOp;
        if (loadOp.Status == AsyncOperationStatus.Succeeded)
        {
            var op = Addressables.InstantiateAsync(key);
            if (op.IsDone) // <--- this will always be true.  A preloaded asset will instantiate synchronously. 
            {
                Debug.Log("Done");
            }
        }
        else
        {
            Debug.LogError(loadOp.Status);
        }
    }

    // private void CreateOdalAsset(Entity entity)
    // {
    //     _odal.Instantiate(
    //         "7e463ede-197c-4696-9680-1e85dde96f69",
    //         entity,
    //         () => Debug.Log("Odal asset instantiated"),
    //         Debug.LogError);
    // }
}