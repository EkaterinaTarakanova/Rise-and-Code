using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgrammManager : MonoBehaviour
{
    [Header("Put your PlaneMarker here")]
    [SerializeField] private GameObject PlaneMarkerPrefab;

    [Header("Put your Object here")]
    public GameObject ObjectToSpawn;

    private ARRaycastManager ARRaycastManagerScript; 
    private bool hasSpawned = false; // Флаг для отслеживания создания объекта

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        PlaneMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ShowMarker();
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }

        if (!hasSpawned && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation); // Спавним объект
            hasSpawned = true; // Устанавливаем флаг, что объект создан
        }
        else if (hasSpawned && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Destroy(ObjectToSpawn); // Удаляем объект
            hasSpawned = false; // Устанавливаем флаг, что объект удален
        }
    }
}