using System;
using UnityEngine;

namespace UnityRPGEditor
{
    [CreateAssetMenu(menuName ="RPG Editor/New Weapon")]
    public class WeaponData : ItemData
    {
        [field: SerializeField]
        public int Damage { get; private set; } = 5;

        [field: SerializeField]
        public DamageType DamageType { get; private set; }

        [field: SerializeField]
        public float AttackSpeed { get; private set; } = 1f;

        [field: SerializeField]
        public float Range { get; private set; } = 1.5f;

        [field: SerializeField]
        public float Durability { get; private set; }
    }

    [Flags]
    public enum DamageType
    {
        Physical = 0,
        Fire = 1, 
        Cold = 2, 
        Lightning = 4,
        Necrotic = 8,
        Void = 16,
        True = 32
    }
}
