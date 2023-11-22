using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCell : Tower
{
    public Antibody AntibodyPrefab;

    public float ShootSpeed;

    protected override void Attack() {
        var virus = VirusInRange.Count > 0 ? VirusInRange[0] : null;
        //if (virus == null) virus = VirusInRange[1];

        if (virus != null) {
            var antibody = Instantiate(AntibodyPrefab, transform.position, Quaternion.identity);
            antibody.transform.LookAt(virus.transform);
            antibody.GetComponent<Rigidbody>().velocity = antibody.transform.forward * ShootSpeed;
        } else {
            var antibody = Instantiate(AntibodyPrefab, transform.position, transform.rotation);
            antibody.GetComponent<Rigidbody>().velocity = antibody.transform.forward * ShootSpeed;
        }


        //StartCoroutine(AttackCoroutine());
    }

    protected override void OnVirusEnter(Virus virus) {
        base.OnVirusEnter(virus);
    }

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
        if (VirusInRange.Count > 0) {
            TryAttack();
        }
        // debug
        if (Input.GetKeyDown(KeyCode.B)) {
            TryAttack();
        }
    }

    private IEnumerator AttackCoroutine() {
        yield return null;
    } 
}
