using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTracker : MonoBehaviour
{
    public bool WindowsDebug => Application.platform == RuntimePlatform.WindowsEditor;

    public GameObject HeartPrefab;
    public GameObject TCellPrefab;
    public GameObject BCellPrefab;
    public GameObject WCellPrefab;

    private ARTrackedImageManager TrackerManager;

    private void Awake() {
        TrackerManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable() {
        TrackerManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable() {
        TrackerManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args) {
        foreach(ARTrackedImage trackedImage in args.added) {
            OnImageAdded(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in args.updated) {
            OnImageUpdated(trackedImage);
        }
        foreach (ARTrackedImage trackedImage in args.removed) {
            OnImageRemoved(trackedImage);
        }
    }

    public void OnImageAdded(ARTrackedImage img) {
        if (img.referenceImage.name == "Heart") {
            Instantiate(HeartPrefab, img.transform);
            Debug.Log("Heart detected");
        }
        else if (img.referenceImage.name == "BCell") {
            Instantiate(BCellPrefab, img.transform);
            Debug.Log("BCell detected");
        }
        else if (img.referenceImage.name == "TCell") {
            Instantiate(TCellPrefab, img.transform);
            Debug.Log("TCell detected");
        } 
        else if (img.referenceImage.name == "WCell") {
            Instantiate(WCellPrefab, img.transform);
            Debug.Log("WCell detected");
        } else {
            Debug.Log($"Unknown detected: {img.referenceImage.name}");
        }
    }

    public void OnImageUpdated(ARTrackedImage img) {

    }

    public void OnImageRemoved(ARTrackedImage img) {

    }

    // Start is called before the first frame update
    void Start()
    {
        if (WindowsDebug) {
            Instantiate(HeartPrefab);

            Instantiate(BCellPrefab, new Vector3(0.3f, 0f, 0f), Quaternion.identity);

            Instantiate(TCellPrefab, new Vector3(0f, 0f, 0.3f), Quaternion.identity);

            Instantiate(WCellPrefab, new Vector3(-0.3f, 0f, 0f), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
