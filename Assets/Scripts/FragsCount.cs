using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FragsCount : MonoBehaviour
{
    [SerializeField] private Text _fragsCount;
    private int _currentFrags = 0;

    public int CurrentFrags { get => _currentFrags; set => _currentFrags = value; }

    private void Update()
    {
        _fragsCount.text = "Frags :" + CurrentFrags;
    }
}
