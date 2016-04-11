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
        //turning
        //jumping
        Move();
    }

    void Move()
    {
        anim.SetFloat("Forward", Input.GetAxisRaw("Vertical"));
    }
}
