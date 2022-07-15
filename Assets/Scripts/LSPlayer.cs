using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSPlayer : MonoBehaviour
{
    public MapPoint currentPoint;

    public float moveSpeed = 20f;

    private bool levelLoading;

    public LSManager theManager;
    

    // Start is called before the first frame update
    void Start()
    {
      transform.position = currentPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !levelLoading)
        {

            if(Input.GetAxisRaw("Horizontal") > .5f)
            {
                if(currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }
            }

            if(Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if(currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }
            }

            if(Input.GetAxisRaw("Vertical") > .5f)
            {
                if(currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }
            }

            if(Input.GetAxisRaw("Vertical") < -.5f)
            {
                if(currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }
            }

            if(currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked)
            {
                LSUI.instance.ShowInfo(currentPoint);

                if(Input.GetButtonDown("Jump"))
                {
                    levelLoading = true;

                    theManager.LoadLevel();

                    AudioManager.instance.PlaySFX(4);
                }
            }
        }
    }
    

    public void SetNextPoint(MapPoint nextPoint)
    {
        currentPoint = nextPoint;
        LSUI.instance.HideInfo();

        AudioManager.instance.PlaySFX(5);
    }
}
