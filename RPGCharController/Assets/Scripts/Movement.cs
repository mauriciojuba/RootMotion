using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Animator anim;
    Camera viewCamera;

    void Awake()
    {
        anim = GetComponent<Animator>();
        viewCamera = Camera.main;
    }

    void Update()
    {
        Turning();
        //jumping
        Move();
        lookAt();
    }

    void Move()
    {
        anim.SetFloat("Forward", Input.GetAxis("Vertical"));
    }
    void Turning()
    {
        anim.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }
    void lookAt()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        if(groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);
            transform.LookAt(heightCorrectedPoint);
        }
    }


}
