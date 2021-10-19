using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private float speedInput, turnInput;
    private bool grounded;
    private float emissionRate;

    public float forwardAccel = 8f;
    public float reverseAccel = 4f;
    public float maxSpeed = 50f;
    public float turnStrength = 180;
    public float gravityForce = 10f;
    public float dragOnGround = 3f; 
    public float maxWheelTurn = 25f;

    public Rigidbody theRB;
    public LayerMask whatIsGround;
    public float groundRayLength = 0.5f;
    public Transform groundRayPoint;
    public Transform leftFrontWheel;
    public Transform rightFrontWheel;
    public ParticleSystem[] dustTrail;
    public DetectSwipe detectSwipe;
    public float maxEmission = 25f;
    public Transform car;

    void Start()
    {
        theRB.transform.parent = null;
    }

    private void Update()
    {  
        speedInput = 1 * forwardAccel * 1000f;

        turnInput = detectSwipe.xAxis;

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime , 0f));
            if (detectSwipe.xAxis > 0)
                car.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 15, 0));
            else if (detectSwipe.xAxis < 0)
                car.rotation = Quaternion.Euler(transform.rotation.eulerAngles +new Vector3(0, -15, 0));
            else
                car.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, 0));

        }

        leftFrontWheel.localRotation = Quaternion.Euler(leftFrontWheel.localRotation.eulerAngles.x, (turnInput * maxWheelTurn) - 180, leftFrontWheel.localRotation.eulerAngles.z);
        rightFrontWheel.localRotation = Quaternion.Euler(rightFrontWheel.localRotation.eulerAngles.x, turnInput * maxWheelTurn, rightFrontWheel.localRotation.eulerAngles.z);


        transform.position = theRB.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        emissionRate = 0;

        if (grounded) 
        {
            theRB.drag = dragOnGround;

            if(Mathf.Abs(speedInput)> 0 )
            {
                theRB.AddForce(transform.forward * speedInput);

                emissionRate = maxEmission;
            }
            else
            {
                theRB.drag = 0.1f;
                theRB.AddForce(Vector3.up * -gravityForce * 100f);
            }

            foreach(ParticleSystem part in dustTrail)
            {
                var emissionModule = part.emission;
                emissionModule.rateOverTime = emissionRate;
            }
        }
    }
    
}
