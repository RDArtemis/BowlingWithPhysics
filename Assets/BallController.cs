using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour

{
    [SerializeField] private float force = 1f;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    private InputManager inputManager;
    private bool isBallLaunched;
    private Rigidbody ballRB;

    void Start()
    {
        //get reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        //Listener to launch ball on spacekey
        inputManager.OnSpacePressed.AddListener(LaunchBall);
        transform.parent = ballAnchor;
        transform.localPosition = Vector3.zero;
        ballRB.isKinematic = true;

    }

    private void LaunchBall()
    {
        if (isBallLaunched) return;
        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }
}
