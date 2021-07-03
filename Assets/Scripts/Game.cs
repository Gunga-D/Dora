using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private WavesRegulator _wave;
    [SerializeField] private Hero _hero;

    private void Awake()
    {
        _hero.ReloadedTheGame += OnReloadTheGame;
    }

    private void OnReloadTheGame()
    {
        _wave.NullifyWaves();
    }

    private void OnDisableHeroEvent()
    {
        _hero.ReloadedTheGame -= OnReloadTheGame;
    }
}
