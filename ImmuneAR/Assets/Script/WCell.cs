using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCell : Tower
{
    protected override void Attack() {
        StartCoroutine(AttackCoroutine());
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
        if (Input.GetKeyDown(KeyCode.W)) {
            TryAttack();
        }
    }

    private IEnumerator AttackCoroutine() {
        Vector3 origScale = transform.localScale;
        transform.localScale = origScale * 1.1f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = origScale;

        var virusToKill = new List<Virus>(VirusInRange);
        foreach (var virus in virusToKill) {
            virus?.Kill();
        }
    }
}
