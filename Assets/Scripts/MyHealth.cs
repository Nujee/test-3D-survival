using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHP = 10000;
    [SerializeField] private int _curHP = 0;
    //[SerializeField] private Color _deathColor = Color.black;

    private MeshRenderer _meshRenderer;
    [SerializeField] private ParticleSystem _particleSystem;

    public int MaxHP { get => _maxHP; set => _maxHP = value; }
    public int CurHP { get => _curHP; set => _curHP = value; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        CurHP = MaxHP;
    }

    public void TakeDamage(int damage)
    {
        _particleSystem?.Play();
        CurHP -= damage;
        if (_curHP <= 0)
        {
            Die();
        }
    }

    public void TakeHeal(int heal)
    {
        CurHP += heal;

        if (CurHP >= MaxHP)
        {
            CurHP = MaxHP;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    /*
    private void Die()
    {
        StartCoroutine(ChangeColor(0.1f));
    }
    IEnumerator ChangeColor(float deathWait)
    {
        while (_meshRenderer.material.color != _deathColor)
        {
            _meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, _deathColor, 0.02f);
            yield return null;
        }

        yield return new WaitForSeconds(deathWait);

        Destroy(gameObject);
    }
    */
}
