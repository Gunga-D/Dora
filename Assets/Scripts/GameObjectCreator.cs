using UnityEngine;

public abstract class GameObjectCreator : MonoBehaviour
{
    protected T CreateGameObject<T>(T prefab) where T : MonoBehaviour
    {
        T instance = Instantiate(prefab);

        return instance;
    }
}
