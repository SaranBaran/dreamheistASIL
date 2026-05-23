using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class CameraManager : MonoBehaviour
{
    #region Variables

    private Vector2 _delta;
    private bool _isMoving;
    private bool _isRotating;
    private bool _isBusy;

    private float _xRotation;

    private Camera camera;
    private float zoomTarget;
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private Vector2 minmax = new Vector2(1,20);
    [SerializeField]private float multiplier = 2f, smoothTime = .1f;
    private float velocity = 0f;
    private Vector3 velocity_vec = new Vector3(0f, 0f, 0f);
    private bool camMoving = false;

    #endregion

    void Start()
    {
        camera = GetComponent<Camera>();
        zoomTarget = camera.orthographicSize;
    }
    void Update()
    {
        /*
        if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
             camera.orthographicSize += 1; //Change values according to your requirements
         }
        if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
             camera.orthographicSize -= 1;
         }
         */
        zoomTarget -= Input.GetAxisRaw("Mouse ScrollWheel")*multiplier;
        zoomTarget = Mathf.Clamp(zoomTarget, minmax.x, minmax.y);
        camera.orthographicSize = Mathf.SmoothDamp(camera.orthographicSize, zoomTarget,
        ref velocity, smoothTime);
    }
    private void Awake()
    {
        _xRotation = transform.rotation.eulerAngles.x;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _delta = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _isMoving = context.started || context.performed;
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (_isBusy) return;
        
        _isRotating = context.started || context.performed;

        if (context.canceled)
        {
            _isBusy = true;
            SnapRotation();
        }
    }

    private void LateUpdate()
    {
        if (_isMoving)
        {
            var position = transform.right * (_delta.x * -movementSpeed);
            position += transform.up * (_delta.y * -movementSpeed);
            transform.position += position * Time.deltaTime;
        }

        if (_isRotating)
        {
            transform.Rotate(new Vector3(_xRotation, -_delta.x * rotationSpeed, 0.0f));
            transform.rotation = Quaternion.Euler(_xRotation, transform.rotation.eulerAngles.y, 0.0f);
        }
    }

    private void SnapRotation()
    {
        transform.DORotate(SnappedVector(), 0.5f)
            .SetEase(Ease.OutBounce)
            .OnComplete(() =>
            {
                _isBusy = false;
            });
    }
    
    private Vector3 SnappedVector()
    {
        var endValue = 0.0f;
        var currentY = Mathf.Ceil(transform.rotation.eulerAngles.y);

        endValue = currentY switch
        {
            >= 0 and <= 90 => 45.0f,
            >= 91 and <= 180 => 135.0f,
            >= 181 and <= 270 => 225.0f,
            _ => 315.0f
        };

        return new Vector3(_xRotation, endValue, 0.0f);
    }
    public void moveCamera(Transform playerTransform)
    {
        //Vector3 target = new Vector3(transform.position.x + 30, camera.transform.position.y, 
        transform.position = Vector3.SmoothDamp(transform.position, playerTransform.position, ref velocity_vec, 1f);
        if (Vector3.Distance(transform.position, playerTransform.position) < 0.01f)
        {
            transform.position = playerTransform.position;
            velocity_vec = Vector3.zero;
            camMoving = false;
        }
    }

}