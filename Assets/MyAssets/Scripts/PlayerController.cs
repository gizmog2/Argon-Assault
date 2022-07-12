using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] InputAction movement;
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    
    /*private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }*/

    // Update is called once per frame
    void Update()
    {

        /*float horizontalThrow = movement.ReadValue<Vector2>().x;
        Debug.Log(horizontalThrow);
        float verticalThrow = movement.ReadValue<Vector2>().y;
        Debug.Log(verticalThrow);*/

        float xThrow = Input.GetAxis("Horizontal");
        
        float yThrow = Input.GetAxis("Vertical");

        float xPos = xThrow * moveSpeed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xPos;
        float clampXPos = Mathf.Clamp(newXPos, -xRange, xRange);

        float yPos = yThrow * moveSpeed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yPos;
        float clampYPos = Mathf.Clamp(newYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, transform.localPosition.z);
    }
}
