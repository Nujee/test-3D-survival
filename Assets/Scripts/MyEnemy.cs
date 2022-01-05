using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] private int _attackDamage = 1;
    [SerializeField] private float _attackThreshold = 2f;
    private Transform _target;
    private NavMeshAgent _enemyNavMesh;
    private Animator _enemyAnimator;


    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _enemyNavMesh = gameObject.GetComponent<NavMeshAgent>();
        _enemyAnimator = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, _target.position) > _attackThreshold)
        {
            Pursue();
        }
        else
        {
            Attack(_attackDamage);
        }
    }

    private void Pursue()
    {
        _enemyNavMesh.SetDestination(_target.position);
        _enemyAnimator.SetBool("Attack", false);
        _enemyAnimator.SetBool("Go", true);
    }

    private void Attack(int damage)
    {
        _enemyAnimator.SetBool("Go", false);
        _enemyAnimator.SetBool("Attack", true);
        _target.gameObject.GetComponent<MyHealth>().TakeDamage(damage);
    }

    #region OldMoveLogic

    // Стоять, пока игрок не в поле видимости.
    // Когда войдет - предледовать
    // Когда выйдет - преследовать до послденей засеченной точки и немного после в том же направлении.
    // После - какое-то время ждать
    // Затем - вернуться на "пост"

    /*
    [SerializeField] private float _pursueOffsetCoef = 5;

    private NavMeshAgent _navMesh;
    private Animator _animator;

    private Vector3 _patrolPosition;
    private Vector3 _currentDetectedPlayerPos;
    private Vector3 _currentDirToPlayer;
    private Quaternion _patrolRotation;

    private void Awake()
    {
        _navMesh = gameObject.GetComponent<NavMeshAgent>();
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
    */
    #endregion
}
