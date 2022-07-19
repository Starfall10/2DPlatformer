using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmasherController : MonoBehaviour
{
    public static SmasherController instance;

    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;

    public Transform smasher;
    public Transform point1, point2;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        point1.parent = null;
        point2.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        smasher.position = Vector3.MoveTowards(smasher.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(smasher.position, points[currentPoint].position) < 0.05f)
        {
            currentPoint = 0;
            

        }
        
    }
    public void Smash()
    {
        currentPoint++;
    }
}
