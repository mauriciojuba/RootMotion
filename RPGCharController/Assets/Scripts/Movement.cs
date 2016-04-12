using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Turning();
        //jumping
        Move();
    }

    void Move()
    {
        anim.SetFloat("Forward", Input.GetAxis("Vertical"));
    }
    void Turning()
    {
        anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }


}
