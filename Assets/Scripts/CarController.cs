using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    public float maxMotorTorque;

    public float breakForce;
    private float currentBreakForce;
    private bool isBreaking;

    public float maxSteerAngle;
    private float currentSteerAngle;

    public float currentSpeed;
    public float maxSpeed;

    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public Transform[] wheelTransforms = new Transform[4];

    public GameObject speedDisplay;

    private GameManager gameManager;
    private CountDown countDown;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        countDown = GameObject.Find("Count Down").GetComponent<CountDown>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // If game is active then car contoller functions will execute
        if (gameManager.isGameActive && countDown.isCountDownEnd)
        {
            GetInput();
            HandleMotor();
            HandleSteering();
            AnimateWheels();

        }
        else
        {
            wheelColliders[2].motorTorque = 0;
            wheelColliders[3].motorTorque = 0;
            currentSpeed = 0;
        }
    }

    // This function is used to take input to drive car
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        isBreaking = Input.GetKey(KeyCode.Space);
    }

    // This function is used to control motor torque
    private void HandleMotor()
    {
        currentSpeed = 2 * Mathf.PI * wheelColliders[2].radius * wheelColliders[2].rpm * 60 / 1000;
        int currentSpeedInt = Convert.ToInt32(currentSpeed);
        speedDisplay.GetComponent<TextMeshProUGUI>().text = currentSpeedInt.ToString() + " Km/h";

        if (currentSpeed < maxSpeed)
        {
            wheelColliders[2].motorTorque = verticalInput * maxMotorTorque;
            wheelColliders[3].motorTorque = verticalInput * maxMotorTorque;
        }
        else
        {
            wheelColliders[2].motorTorque = 0;
            wheelColliders[3].motorTorque = 0;
        }

        currentBreakForce = isBreaking ? breakForce : 0;
        ApplyBreaking();
    }

    // This function is used to apply car brakes
    private void ApplyBreaking()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].brakeTorque = currentBreakForce;
        }
    }

    // This function is used to steer car accoring to input
    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;

        wheelColliders[0].steerAngle = currentSteerAngle;
        wheelColliders[1].steerAngle = currentSteerAngle;
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
