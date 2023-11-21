using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Virus : MonoBehaviour
{
    private NavMeshAgent agent;

    public void Kill() {
        Debug.Log("Virus Killed");
        Destroy(gameObject);
    }

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
            heart.OnAttack();
            Destroy(gameObject);
        }
        if (other.TryGetComponent<Tower>(out Tower tower)) {
            tower.OnVirusEnter(this);
        }
    }
}
