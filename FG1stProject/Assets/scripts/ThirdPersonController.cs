using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private float walkingSpeed = 2f;
    [SerializeField] private int playerIndex;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    [SerializeField] private float pitchClamp = 90;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()

    {
        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex))
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Translate(transform.right * walkingSpeed * Time.deltaTime * Input.GetAxis("Horizontal"),
                    Space.World);
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(transform.forward * walkingSpeed * Time.deltaTime * Input.GetAxis("Vertical"),
                    Space.World); 
            }


            ReadRotationInput();
        }
    }

    public void ReadRotationInput()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);

        characterCamera.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
}
