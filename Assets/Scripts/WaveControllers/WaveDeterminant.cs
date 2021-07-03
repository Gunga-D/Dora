using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDeterminant : MonoBehaviour
{
    [SerializeField] int _maxDifficulty;
    private int _waveNumber;

    public int Level
    {
        get
        {
            return _waveNumber;
        }
    }

    public int Difficulty
    {
        get
        {
            int difficulty = _waveNumber;
            if (difficulty > _maxDifficulty)
                difficulty = _maxDifficulty;

            return difficulty;
        }
    }

    public int EnemyLevels
    {
        get
        {
            return _waveNumber / 10;
        }
    }

    public float Duration
    {
        get
        {
            return _waveNumber * 4f;
        }
    }

    private void Start()
    {
        _waveNumber = 1;
    }

    public void IncreaseWaveNumber()
    {
        _waveNumber++;
    }

    public void RestartWaveNumber()
    {
        _waveNumber = 1;
    }
}
