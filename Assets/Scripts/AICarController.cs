using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    public Transform path;

    public float maxMotorTorque;

    public float maxSteerAngle;

    public float currentSpeed;
    public float maxSpeed;

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public Transform[] wheelTransforms = new Transform[4];


    private List<Transform> nodes;
    private int currentNode = 0;

    private GameManager gameManager;
    private CountDown countDown;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        countDown = GameObject.Find("Count Down").GetComponent<CountDown>();

        // Taking path object childrens(nodes) to drive ai car on defined path
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // If game is active then ai car controller functions will execute
        if (gameManager.isGameActive && countDown.isCountDownEnd)
        {
            AIApplySteer();
            AIDrive();
            CheckWaypointDistance();
            AnimateWheels();
        }
        else
        {
            wheelColliders[2].motorTorque = 0;
            wheelColliders[3].motorTorque = 0;
            currentSpeed = 0;
        }
    }

    // This function is used to steer ai car
    private void AIApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float currentSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        wheelColliders[0].steerAngle = currentSteer;
        wheelColliders[1].steerAngle = currentSteer;

        print(relativeVector);
    }

    // This function is used to drive ai car
    private void AIDrive()
    {
        currentSpeed = 2 * Mathf.PI * wheelColliders[2].radius * wheelColliders[2].rpm * 60 / 1000;

        if (currentSpeed < maxSpeed)
        {
            wheelColliders[2].motorTorque = maxMotorTorque;
            wheelColliders[3].motorTorque = maxMotorTorque;
        }
        else
        {
            wheelColliders[2].motorTorque = 0;
            wheelColliders[3].motorTorque = 0;
        }
    }

    // This function is used to check waypoint distance
    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.5)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }

    // This function is used to animate car wheels
    private void AnimateWheels()
    {
        Vector3 wheelPosition;
        Quaternion wheelRotation;

        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].GetWorldPose(out wheelPosition, out wheelRotation);

            wheelTransforms[i].position = wheelPosition;
            wheelTransforms[i].rotation = wheelRotation;
        }
    }
}
