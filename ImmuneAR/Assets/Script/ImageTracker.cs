using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTracker : MonoBehaviour
{
    public GameObject HeartPrefab;
    public GameObject TCellPrefab;
    public GameObject BCellPrefab;

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
        if (img.referenceImage.name == "BCell") {
            Instantiate(BCellPrefab, img.transform);
            Debug.Log("BCell detected");
        }
        if (img.referenceImage.name == "TCell") {
            Instantiate(TCellPrefab, img.transform);
            Debug.Log("TCell detected");
        }
    }

    public void OnImageUpdated(ARTrackedImage img) {

    }

    public void OnImageRemoved(ARTrackedImage img) {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
