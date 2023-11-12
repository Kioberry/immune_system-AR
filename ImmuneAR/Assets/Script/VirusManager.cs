using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusManager : MonoBehaviour
{
    public static VirusManager Instance;
    private void Awake() {
        Instance = this;
    }


    public GameObject VirusPrefab;

    public List<Transform> SpawnSpots;

    public bool GameOn = false;

    public void SetupHeart(Transform heartTransform) {
        transform.position = heartTransform.position;
        GameOn = true;
        StartCoroutine(GenerateVirus());
    }

    IEnumerator GenerateVirus() {
        while (GameOn) {
            yield return new WaitForSeconds(3f);
            SpawnVirus(SpawnSpots[Random.Range(0, SpawnSpots.Count)]);
        }
    }

    private void SpawnVirus(Transform spot) {
        Instantiate(VirusPrefab, spot.position, spot.rotation);
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
