using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModificationsAdder : MonoBehaviour
{
    [SerializeField] private List<EnemyModifier> _modifications = new List<EnemyModifier>();
    [SerializeField] private EnemyModifier rootModifier;

    public void Upgrade(Enemy creature, int level)
    {
        rootModifier.Initialize<Enemy>(creature);

        for (int i = 0; i < level; i++)
        {
            foreach(var modification in _modifications)
            {
                modification.Initialize<Enemy>(creature);

                rootModifier.Add(modification);
            }
        }

        rootModifier.Handle();
    }
}
