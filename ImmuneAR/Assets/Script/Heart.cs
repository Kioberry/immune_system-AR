using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public static Heart Instance;
    private void Awake() {
        Instance = this;
    }

    public Transform ModelContainer;
    public Transform HPIndicator;

    public int MaxHP;
    public int HP;

    public void OnAttack() {
        if (HP > 0) {
            HPIndicator.GetChild(MaxHP - HP).gameObject.SetActive(false);
            HP--;
            Debug.Log("HeartAttacked");
            if (HP <= 0) {
                HP = 0;
                // Fail
                Debug.Log("Dead");
                VirusManager.Instance.HeartFail();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!ModelContainer) ModelContainer = transform.GetChild(0);
        if (!HPIndicator) HPIndicator = transform.GetChild(1);
        MaxHP = HPIndicator.childCount;

        transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        VirusManager.Instance.SetupHeart(transform);
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
