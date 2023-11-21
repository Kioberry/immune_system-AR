using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public static Heart Instance;
    private void Awake() {
        Instance = this;
    }

    public int MaxHP;
    public int HP;

    public void OnAttack() {
        if (HP > 0) {
            HP--;
            Debug.Log("HeartAttacked");
            if (HP <= 0) {
                HP = 0;
                // TODO Dead
                Debug.Log("Dead");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        VirusManager.Instance.SetupHeart(transform);
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
