using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VikingController : MonoBehaviour
{
    public Vector3 MovingDirection;

    bool start = false, turning = false, canJump = false;
      
    public int map = 0, score = 0;
    //MeshRenderer mr;
    public float movingSpeed = 10f;
    public Vector3 TorqueDirection;
    Vector3 X = new Vector3(1, 0, 0);
    Vector3 neg_X = new Vector3(-1, 0, 0);
    Vector3 Z = new Vector3(0, 0, 1);
    Vector3 neg_Z = new Vector3(0, 0, -1);
    public bool run = false, end = false;
    public float JumpingForce, MovingThreshold, RotationTorque;
    Rigidbody rb;
    Animator animator;
    //NavMeshAgent agent;
    Vector2 velocity = Vector2.zero;
    private float ftime = 0;
    RaycastHit raycastHit;


    public bool hole_1 = false, hole_2 = false, hole_3 = false, hole_4 = false;
    public GameObject hole1, hole2, hole3, hole4, hole5, hole6, hole7, hole8, hole9, hole10, hole11, hole12, hole13, hole14, hole15, hole16;



    void Awake()
    {

    }
    
    // Start is called before the first frame update
    void Start()
    {

        Transform t = GetComponent<Transform>();

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
        //agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -1)
        {
            end = true;
            start = false;
            run = false;
            canJump = false;
            animator.SetBool("End", end);
        }

        if (start)
        {
            ftime += Time.deltaTime;
            if (ftime >= 1f)
            {
                score += 1;
                if (movingSpeed <= 40)
                {
                    movingSpeed += 0.2f;
                }
                ftime = 0f;
            }
        }

        if (Input.GetKey(KeyCode.W) &&  !start && !end)
        {
            start = true;
            run = true;
            canJump = true;
        }
        if (Input.GetKey(KeyCode.A) && start)
        {
            if (MovingDirection == X)
            {
                transform.position += 20 * Time.deltaTime * Z / 2;
            }
            else if (MovingDirection == neg_X)
            {
                transform.position -= 20 * Time.deltaTime * Z / 2;
            }
            else if (MovingDirection == Z)
            {
                transform.position -= 20 * Time.deltaTime * X / 2;
            }
            else if (MovingDirection == neg_Z)
            {
                transform.position += 20 * Time.deltaTime * X / 2;
            }
        }
        if (Input.GetKey(KeyCode.D) && start)
        {
            if (MovingDirection == X)
            {
                transform.position -= 20 * Time.deltaTime * Z / 2;
            }
            else if (MovingDirection == neg_X)
            {
                transform.position += 20 * Time.deltaTime * Z / 2;
            }
            else if (MovingDirection == Z)
            {
                transform.position += 20 * Time.deltaTime * X / 2;
            }
            else if (MovingDirection == neg_Z)
            {
                transform.position -= 20 * Time.deltaTime * X / 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && start)
        {
            if (!turning)
            {
                run = false;
                turning = true;
                StartCoroutine(RotateMe(Vector3.up * -90, 0.25f));
                turn(-1);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && start)
        {
            if (!turning)
            {
                run = false;
                turning = true;
                StartCoroutine(RotateMe(Vector3.up * 90, 0.25f));
                turn(1);
            }
        }
        if (run && start)
        {
            transform.localPosition += movingSpeed * Time.deltaTime * MovingDirection;
        }

        animator.SetBool("Run", run);

       
        if (Input.GetKeyDown(KeyCode.Space) && IsGround() && canJump)
        {
            rb.AddForce(JumpingForce * Vector3.up);
        }
        
        
    }

    void turn(int dir)
    {
        if (dir == 1)
        {
            if (MovingDirection == X)
            {
                MovingDirection = neg_Z;
            }else if (MovingDirection == neg_X)
            {
                MovingDirection = Z;
            }
            else if (MovingDirection == Z)
            {
                MovingDirection = X;
            }
            else if (MovingDirection == neg_Z)
            {
                MovingDirection = neg_X;
            }
        }
        else if (dir == -1)
        {
            if (MovingDirection == X)
            {
                MovingDirection = Z;
            }
            else if (MovingDirection == neg_X)
            {
                MovingDirection = neg_Z;
            }
            else if (MovingDirection == Z)
            {
                MovingDirection = neg_X;
            }
            else if (MovingDirection == neg_Z)
            {
                MovingDirection = X;
            }
        }
    }

    
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
        run = true;
        turning = false;
    }

    bool IsGround()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGround = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f);
        return isGround;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.name == "rock")
        {
            end = true;
            start = false;
            run = false;
            canJump = false;
            animator.SetBool("End", end);
        }
    }

}
