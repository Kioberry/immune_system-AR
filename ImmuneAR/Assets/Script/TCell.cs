using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCell : Tower
{
    public Transform Sword;

    protected override void Attack() {
        StartCoroutine(AttackCoroutine());
    }

    protected override void OnVirusEnter(Virus virus) {
        base.OnVirusEnter(virus);
    }

    protected override void Start() {
        base.Start();
        if (!Sword) Sword = transform.GetChild(1);
    }

    protected override void Update() {
        base.Update();
        if (VirusInRange.Count > 0) {
            TryAttack();
        }
        // debug
        if (Input.GetKeyDown(KeyCode.T)) {
            TryAttack();
        }
    }

    private IEnumerator AttackCoroutine() {
        yield return new WaitForSeconds(0.2f);
        Sword.gameObject.SetActive(true);
        for (float t = 0f; t < 0.2f; t += Time.deltaTime) {
            transform.Rotate(Vector3.up, Time.deltaTime * 360f / 0.2f, Space.Self);
            yield return null;
        }
        Sword.gameObject.SetActive(false);
        var virusToKill = new List<Virus>(VirusInRange);
        foreach(var virus in virusToKill) {
            virus?.Kill();
        }
    } 
}
