using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicButton : MonoBehaviour
{
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = .025f;

    private bool _isPressed = false;
    private Vector3 _startPosition;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
    }

    void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        print("Button Pressed");
    }

    void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        print("Button Released");
    }

    private float GetValue()
    {
        float value = Vector3.Distance(_startPosition, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return (Mathf.Clamp(value, -1f, 1f));
    }
}
