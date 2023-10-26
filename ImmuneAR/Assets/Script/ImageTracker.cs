using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTracker : MonoBehaviour
{
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
