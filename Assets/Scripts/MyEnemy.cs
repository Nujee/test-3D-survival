using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private float _pursueOffsetCoef = 5;

    private NavMeshAgent _navMesh;
    private Animator _animator;
    private MyHealth _health;

    private Vector3 _patrolPosition;
    private Vector3 _currentDetectedPlayerPos;
    private Vector3 _currentDirToPlayer;
    private Quaternion _patrolRotation;


    private void Awake()
    {
        _navMesh = gameObject.GetComponent<NavMeshAgent>();
        _health = gameObject.GetComponent<MyHealth>();
        _animator = gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
        _patrolPosition = transform.position;
        _patrolRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        IdleIfOnPatrol();
    }

    private void OnTriggerStay(Collider other)
    {
        PursuePlayer(other);
    }

    private void OnTriggerExit(Collider other)
    {
        PursuePlayerTillLost(other);
        StartCoroutine(Wait());
    }

    private void PursuePlayer(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _currentDetectedPlayerPos = other.transform.position;
            _navMesh.SetDestination(_currentDetectedPlayerPos);
            _currentDirToPlayer = _currentDetectedPlayerPos - transform.position;
            _animator.SetBool("Go", true);
        }
    }

    private void PursuePlayerTillLost(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var lastPositionToCheck = _currentDetectedPlayerPos + (_currentDirToPlayer.normalized * _pursueOffsetCoef);
            _navMesh.SetDestination(lastPositionToCheck);
        }
    }
    
    private void ReturnToPatrol()
    {
        _navMesh.SetDestination(_patrolPosition);
    }

    private void IdleIfOnPatrol()
    {
        if (Vector3.Distance(transform.position, _patrolPosition) <= 1)
        {
            transform.rotation = _patrolRotation;
            _animator.SetBool("Go", false);
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(10);
        ReturnToPatrol();
    }
}
