using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInteractor))]
public class Player : MonoBehaviour
{
    protected bool _isSelected;
    protected int _currentScore = 0;

    public static Action<int> OnScoreAdded;

    [SerializeField]
    private Transform _model;

    [SerializeField]
    private float _speed = 10f;

    private Joystick _joystick;
    private Rigidbody _rb;
    private Vector3 _joystickDirection;

    public bool IsSelected { get => _isSelected; }

    public static Action OnChangeCharacter;

    private void Start()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
        _rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        IScoreAdder.OnAddScore += ScoreChange;
        IScaleUp.OnScaleUp += ScaleChange;
    }
    private void OnDisable()
    {
        IScoreAdder.OnAddScore -= ScoreChange;
        IScaleUp.OnScaleUp -= ScaleChange;
    }

    private void ScaleChange(float scale)
    {
        if (_isSelected)
        {
            _model.transform.localScale += new Vector3(scale, scale, scale);
        }
    }

    private void ScoreChange(int score)
    {
        if (_isSelected)
        {
            _currentScore += score;
            OnScoreAdded?.Invoke(_currentScore);
        }
    }

    private void HandleChangeSelectedCharacter()
    {
        _isSelected = !_isSelected;
        OnChangeCharacter?.Invoke();
    }

    protected void Update()
    {
        if (_isSelected)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleChangeSelectedCharacter();
        }
    }

    protected void Move()
    {
        _joystickDirection = new Vector3(
            _joystick.Horizontal * _speed,
            _rb.velocity.y,
            _joystick.Vertical * _speed);

        if (_joystick.Direction != Vector2.zero)
        {
            transform.forward = _joystickDirection;
        }
        _rb.velocity = _joystickDirection;

    }
}
