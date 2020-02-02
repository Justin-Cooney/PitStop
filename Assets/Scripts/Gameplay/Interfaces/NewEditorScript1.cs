using UnityEngine;
using UnityEditor;

public interface ICanBeDamaged
{
    int Health { get; }
    void ApplyDamage (int damage);
}