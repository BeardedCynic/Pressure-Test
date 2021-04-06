using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronautAnimator : MonoBehaviour
{
    private Vector3 previousPosition;
    public float speed;
    [SerializeField] Animator anim;
    private bool walking;
    private bool running;
    private bool idle;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curMove = transform.position - previousPosition;
        speed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        if (speed == 0)
        {
            anim.SetBool("idle", true);
        }
        else
        {
            anim.SetBool("idle", false);
        }
        
        if (speed > 0 && speed <= 5)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

        if (speed > 5)
        {
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
