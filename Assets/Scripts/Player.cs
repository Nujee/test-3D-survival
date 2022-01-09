using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // связанное с физикой самого перса
    [SerializeField] private float _speedForce;

    private bool _isAlive = true;
    private Animator _animator;
    public float horizontalSpeed = 15;
    private Rigidbody _rigidbody;

    //кэш других объектов, связанных с персом
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private Transform _bombStartPosition;

    private float _reloadTime = 2;
    private bool _isreloaded = true;

    private AudioSource _audioSource;

    public float SpeedForce { get => _speedForce; set => _speedForce = value; }

    private void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if (!_isAlive) return;

        if (Input.GetMouseButtonDown(0) && _isreloaded)
        {
            _isreloaded = false;
            Invoke("Reload", _reloadTime);
            _animator.SetBool("Fire", true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            DropBomb();
        }

        //RaycastHit hit;

        //var rayCast = Physics.Raycast(transform.position + new Vector3(0, 1, 1), Vector3.forward, out hit);
        //if (rayCast)
        //{
        //    Debug.Log(hit.collider.gameObject.name);
        //}
        //Debug.DrawRay(transform.position + new Vector3(0, 1, 1), Vector3.forward, Color.red);

        if (Input.GetKeyDown(KeyCode.O))
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        MoveLogic();
    }

    private void MoveLogic()
    {
        var verticalMovement  = transform.forward * Input.GetAxis("Vertical") * SpeedForce * Time.fixedDeltaTime;
        var horizontalMovement = transform.right * Input.GetAxis("Horizontal") * SpeedForce * Time.fixedDeltaTime;

        _rigidbody.AddForce(verticalMovement + horizontalMovement);

        var h = horizontalSpeed * Input.GetAxis("Mouse X");
        _rigidbody.MoveRotation(_rigidbody.rotation * (Quaternion.Euler(new Vector3(0, h, 0) * Time.fixedDeltaTime)));
    }

    private void Fire()
    {
        var bul = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        bul.Init(50);
        _audioSource.Play();
        _animator.SetBool("Fire", false);
    }

    private void DropBomb()
    {
        var bomb = Instantiate(_bomb, _bombStartPosition.position, transform.rotation).GetComponent<Rigidbody>();
        bomb.AddForce(transform.forward, ForceMode.Impulse);
    }

    private void Reload()
    {
        _isreloaded = true;
    }

    private void Death()
    {
        _isAlive = false;
        _animator.SetBool("Death", true);
    }
}
