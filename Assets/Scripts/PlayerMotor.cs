using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controler;
    private Vector3 velocity;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        controler = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y; //Z is into the screen for some reason
        controler.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
    }
}
