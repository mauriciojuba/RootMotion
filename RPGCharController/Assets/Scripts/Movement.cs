using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    Animator anim;
    Camera viewCamera;
    Attacking attack;
    public bool isMoving;
    float newDirection, previousDirection;
    float turnValue;

    void Awake()
    {
        anim = GetComponent<Animator>();
        viewCamera = Camera.main;
        attack = GetComponent<Attacking>();
    }
    void Start()
    {
        previousDirection = Mathf.Floor(transform.eulerAngles.y);
    }

    void Update()
    {
        lookAt();
        //jumping
        Move();
        Turning();


        //criar um script apenas para attack
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            attack.Attack();
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
        //Nao esquecer


    }


    void FixedUpdate()
    {
        newDirection = Mathf.Round(transform.eulerAngles.y);
    }



    void Move()
    {
        anim.SetFloat("Forward", Input.GetAxis("Vertical"));
        anim.SetFloat("Side", Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
        {
            isMoving = true;
        }
    }


    void Turning()
    {
        float turnvelocity = 0.01f;
        if (previousDirection != newDirection)
        {
            if (previousDirection < newDirection - 1f)
            {
                turnValue = Mathf.SmoothDamp(turnValue, 0.8f, ref turnvelocity, 2 * Time.deltaTime);
            }
            else if (previousDirection > newDirection + 1f)
            {
                turnValue = Mathf.SmoothDamp(turnValue, -0.8f, ref turnvelocity, 2 * Time.deltaTime);
            }
        }
        else if (turnValue != 0f)
        {
            turnValue = Mathf.SmoothDamp(turnValue, 0f, ref turnvelocity, 4 * Time.deltaTime);
        }
        anim.SetFloat("Turn", turnValue);
        previousDirection = newDirection;
    }


    void lookAt()
    {
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);
            transform.LookAt(heightCorrectedPoint);
        }
    }
}
