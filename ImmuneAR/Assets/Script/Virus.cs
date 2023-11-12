using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Virus : MonoBehaviour
{
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Heart.Instance.transform.position);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<Heart>(out Heart heart)) {
            Debug.Log("HeartAttacked");
            Destroy(gameObject);
        }
    }
}
