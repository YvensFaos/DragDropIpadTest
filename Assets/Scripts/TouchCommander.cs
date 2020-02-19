using UnityEngine;

public class TouchCommander : MonoBehaviour
{

    [SerializeField]
    private Rigidbody playerRigidBody;

    [SerializeField]
    private GameObject playerObjectToRotate;

    [SerializeField]
    private Camera screenCamera;

    [SerializeField] 
    private GameObject createOnClick;

    private Vector3 _moveTowards = Vector3.zero;
    private bool _moving = false;
    private Quaternion _rotateTowards = Quaternion.identity;

    private void Update()
    {
        Vector3 playerPosition = playerRigidBody.position;
        playerObjectToRotate.transform.rotation =
            Quaternion.Slerp(playerObjectToRotate.transform.rotation, _rotateTowards, 0.4f);
        if (_moving && (playerPosition - _moveTowards).magnitude < 0.05f)
        {
            _moving = false;
            playerRigidBody.velocity = Vector3.zero;
        }
        
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            Vector3 world = screenCamera.ScreenToWorldPoint(touchPosition);
            world.y = playerRigidBody.position.y;
            _moveTowards = world;
            
            Vector3 direction = world - playerPosition;
            float magnitude = direction.magnitude;
            float strength = Mathf.Max(magnitude, 8.0f);
            direction.Normalize();
            
            _rotateTowards = Quaternion.LookRotation(direction, Vector3.up);

            GameObject clickedHereObject = Instantiate<GameObject>(createOnClick, world, Quaternion.identity);
            Destroy(clickedHereObject, 5);
        
            Debug.DrawRay(playerPosition, direction * magnitude, Color.magenta);
            playerRigidBody.velocity = Vector3.zero;
            playerRigidBody.AddForce(10.0f * strength * direction, ForceMode.Force);
            _moving = true;
        }

        if (Input.touchCount == 2)
        {
            _moving = false;
            playerRigidBody.velocity = Vector3.zero;
        }
    }
}
