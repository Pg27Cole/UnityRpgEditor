using UnityEngine;
using Sirenix.OdinInspector;
using System;

namespace UnityRPGEditor
{
    public abstract class ItemData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public string Description { get; private set; }

        [field: SerializeField, PreviewField(Height = 100f)]
        public Sprite Icon { get; private set; }

        [field: SerializeField, SuffixLabel("Gold", true)]
        public int Value { get; private set; }
        
        [field: SerializeField, SuffixLabel("KG", true)]
        public int Weight { get; private set; }

        [field: SerializeField]
        public ItemRarity Rarity { get; private set; } = ItemRarity.Common;

    }
    public enum ItemRarity
    {
        Jumk = 0,
        Common = 1, 
        Uncommon = 2,
        Rare = 4,
        Epic = 8,
        Legendary = 16,
        Mythical = 32,
        Godly = 64,
        Super_cole = 128
    }
}
