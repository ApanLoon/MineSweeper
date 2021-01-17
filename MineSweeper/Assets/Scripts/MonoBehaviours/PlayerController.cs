using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof (PlayerInput))]
[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    protected float MouseSensitivity = .004f;
    protected float ThrustStrength = 40f;
    protected float BreakStrength = 20f;
    protected float StrafeStrength = 20f;
    protected PlayerInput PlayerInput;
    protected Rigidbody Rigidbody;

    protected Vector3 Thrust;
    protected Vector3 Strafe;
    protected Vector3 Rotation;

    private void Start()
    {
        PlayerInput = GetComponent<PlayerInput>();
        Rigidbody = GetComponent<Rigidbody>();

        GameEventManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void Update()
    {
        transform.eulerAngles = Rotation;
    }

    private void FixedUpdate()
    {
        if (Thrust.sqrMagnitude > Mathf.Epsilon)
        {
            Rigidbody.AddForce (Thrust, ForceMode.Force);
        }
        if (Strafe.sqrMagnitude > Mathf.Epsilon)
        {
            Rigidbody.AddForce (Strafe, ForceMode.Force);
        }
    }

    protected void OnGameStateChanged (GameState gameState)
    {
        PlayerInput.enabled = gameState == GameState.Playing;
        Cursor.visible = gameState != GameState.Playing;
    }

    public void OnThrust (InputValue input)
    {
        float value = input.Get<float>();
        Thrust = transform.forward * value * (value > 0 ? ThrustStrength : BreakStrength);
    }

    public void OnStrafe (InputValue input)
    {
        float value = input.Get<float>();
        Strafe = transform.right * value * StrafeStrength;
    }

    public void OnOpenSector (InputValue input)
    {
        bool value = input.Get<float>() > 0.5f;
        Debug.Log($"OnOpenSector: {value}");
    }
    
    public void OnShieldSector (InputValue input)
    {
        bool value = input.Get<float>() > 0.5f;
        Debug.Log($"OnShieldSector: {value}");
    }

    public void OnAim (InputValue input)
    {
        Vector2 value = input.Get<Vector2>() * MouseSensitivity;
        Rotation.x += value.y;
        Rotation.y += value.x;
    }
}
