using UnityEngine;

public class ClickTracker : MonoBehaviour
{

    [SerializeField] private float speed;

    private bool isClicked;

    private Camera mainCamera;
    private new Rigidbody rigidbody;
    private new Transform transform;
    private Vector3 zeroVelocity;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        isClicked = false;

        rigidbody = gameObject.GetComponent<Rigidbody>();
        transform = gameObject.transform;
        zeroVelocity = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isClicked = true;
        }
        else
        {
            isClicked = false;
        }
    }

    void FixedUpdate()
    {
        if (isClicked)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Cube"))
                {
                    moveCube(hit.transform.position);
                }
            }
        }
        else
        {
            rigidbody.velocity = zeroVelocity;
        }

    }

    private void moveCube(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        rigidbody.velocity = direction.normalized * speed;
    }
}
