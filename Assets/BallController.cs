using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour

{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private Rigidbody  ballRB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        //Listener to launch ball on spacekey
        inputManager.OnSpacePressed.AddListener(LaunchBall);

    }

    private void LaunchBall()
    {
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
