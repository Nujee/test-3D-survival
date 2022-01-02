using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHealth : MonoBehaviour
{
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private int _curHP = 0;
    //[SerializeField] private Color _deathColor = Color.black;

    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        _curHP = _maxHP;
    }

    public void TakeDamage(int damage)
    {
        _curHP -= damage;
        /*
        if (_curHP <= 0)
        {
            Die();
        }
        */
    }

    public void TakeHeal(int heal)
    {
        _curHP += heal;

        if (_curHP >= _maxHP)
        {
            _curHP = _maxHP;
        }
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
