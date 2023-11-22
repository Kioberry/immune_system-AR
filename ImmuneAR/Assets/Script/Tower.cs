using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum Type
    {
        None,
        BCell,
        TCell,
        WCell
    }

    public Type TowerType;

    public float AttackCD;
    protected float AttackTimer = 0f;

    protected List<Virus> VirusInRange = new();

    public bool TryAttack() {
        if (AttackTimer <= 0) {
            AttackTimer = AttackCD;
            Attack();
            return true;
        }
        return false;
    }

    protected virtual void Attack() {
        
    }

    protected virtual void OnVirusEnter(Virus virus) {
        
    }

    // Start is called before the first frame update
    protected virtual void Start() {
        VirusManager.Instance.OnVirusKilled += OnVirusKilled;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        if (AttackTimer > 0f) {
            AttackTimer -= Time.deltaTime;
        } else {
            AttackTimer = 0f;
        }
    }

    protected void OnDestroy() {
        VirusManager.Instance.OnVirusKilled -= OnVirusKilled;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent<Virus>(out Virus virus)) {
            if (!VirusInRange.Contains(virus)) {
                VirusInRange.Add(virus);
            }
            OnVirusEnter(virus);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.TryGetComponent<Virus>(out Virus virus)) {
            if (VirusInRange.Contains(virus)) {
                VirusInRange.Remove(virus);
            }
        }
    }

    private void OnVirusKilled(Virus virus) {
        if (VirusInRange.Contains(virus)) {
            VirusInRange.Remove(virus);
        }
    }
}
