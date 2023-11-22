using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusManager : MonoBehaviour
{
    public static VirusManager Instance;
    private void Awake() {
        Instance = this;
    }

    public delegate void OnVirusKilledDelegate(Virus virus);
    public event OnVirusKilledDelegate OnVirusKilled;


    public Virus VirusPrefab;

    public List<Transform> SpawnSpots;

    public bool GameOn = false;
    public int gameStage = 0;
    public int currentVirusCount = 0;

    public void VirusBeingKilled(Virus virus) {
        currentVirusCount--;
        OnVirusKilled(virus);
    }

    public void SetupHeart(Transform heartTransform) {
        transform.position = heartTransform.position;
        GameOn = true;
        StartCoroutine(MainGameCoroutine());
    }

    public void HeartFail() {
        GameOn = false;
        Debug.Log("Fail");
    }

    IEnumerator MainGameCoroutine() {
        yield return new WaitForSeconds(3f);
        gameStage++;

        while (GameOn) {
            if (gameStage == 1) {
                yield return SpawnVirusCoroutine(SpawnSpots[0], 3, 0.5f, 1f);
                yield return new WaitUntil(() => currentVirusCount <= 0);
                Debug.Log($"Finished stage {gameStage}");
                yield return new WaitForSeconds(1f);
                gameStage++;
            }
            else if (gameStage == 2) {
                yield return SpawnVirusCoroutine(SpawnSpots[0], 5, 0.7f, 1f);
                yield return new WaitForSeconds(1f);
                yield return SpawnVirusCoroutine(SpawnSpots[1], 5, 0.7f, 1f);
                yield return new WaitForSeconds(1f);
                yield return SpawnVirusCoroutine(SpawnSpots[2], 5, 0.7f, 1f);
                yield return new WaitUntil(() => currentVirusCount <= 0);
                Debug.Log($"Finished stage {gameStage}");
                yield return new WaitForSeconds(1f);
                gameStage++;
            }
            else if (gameStage == 3) {
                yield return SpawnVirusCoroutine(SpawnSpots[0], 7, 1f, 1f);
                yield return SpawnVirusCoroutine(SpawnSpots[1], 7, 1f, 1f);
                yield return SpawnVirusCoroutine(SpawnSpots[2], 7, 1f, 1f);
                yield return SpawnVirusCoroutine(SpawnSpots[0], 7, 1f, 1f);
                yield return new WaitUntil(() => currentVirusCount <= 0);
                Debug.Log($"Finished stage {gameStage}");
                yield return new WaitForSeconds(1f);
                gameStage++;
            }
            else {
                GameOn = false;
                Debug.Log("Victory");
            }
        }

    }

    IEnumerator SpawnVirusCoroutine(Transform spot, int num, float delta, float time) {
        float deltaTime = time / num;
        for (int i = 0; i < num; i++) {
            SpawnVirus(spot, delta);
            yield return new WaitForSeconds(deltaTime);
        }
    }

    private void SpawnVirus(Transform spot, float delta) {
        Virus virus = Instantiate(VirusPrefab, spot.position + GetRandomRange(delta, 0f, delta), spot.rotation);
        currentVirusCount++;
    }

    private Vector3 GetRandomRange(float deltaX, float deltaY, float deltaZ) {
        return new Vector3(Random.Range(-deltaX, deltaX), Random.Range(-deltaY, deltaY), Random.Range(-deltaZ, deltaZ));
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
