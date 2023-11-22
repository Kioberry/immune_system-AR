using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Virus : MonoBehaviour
{
    //private NavMeshAgent agent;

    private VirusManager vm => VirusManager.Instance;

    public void Kill() {
        Debug.Log("Virus Killed");
        vm.VirusBeingKilled(this);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.SetDestination(Heart.Instance.transform.position);
        Vector3 dir = (Heart.Instance.transform.position - transform.position).normalized;
        GetComponent<Rigidbody>().velocity = (dir * 0.2f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<Heart>(out Heart heart)) {
            heart.OnAttack();
            vm.VirusBeingKilled(this);
            Destroy(gameObject);
        }
    }
}
