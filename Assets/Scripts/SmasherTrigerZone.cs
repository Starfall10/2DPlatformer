using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherTrigerZone : MonoBehaviour
{
    public static SmasherTrigerZone instance;

    public Transform TriggerZone;

    

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            TriggerZone.parent = null;
            SmasherController.instance.Smash();
            
        }
    }
}
