using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antibody : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // 1 sec lifespan
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<Virus>(out Virus virus)) {
            Debug.Log("Hit");
            virus?.Kill();
            Destroy(gameObject);
        }
    }
}
