using Sirenix.OdinInspector.Editor;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using System.Reflection;
using System.IO;
using Sirenix.OdinInspector;

namespace UnityRPGEditor.Editor
{
    public class UnityRPGEditorWindow : OdinMenuEditorWindow    // OdinMenuEditorWindow creates a list of editable asets in a new window
    {
        [UnityEditor.MenuItem("Tools/RPG Editor Window")]
        private static void OpenEditor()
        {
            GetWindow<UnityRPGEditorWindow>();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            // create new tree
            OdinMenuTree tree = new OdinMenuTree();

            List<Type> types = new List<Type>();
            types.Add(typeof(CharacterData));
            types.Add(typeof(WeaponData));
            types.Add(typeof(SkillData));

            foreach (var type in types)
            {
                tree.AddAllAssetsAtPath(type.Name, "Assets/", type, true, true);
                tree.Add($"New {type.Name}", new CreateNewAsset(type));
            }
            return tree;
        }

        protected override void OnBeginDrawEditors()
        {
            base.OnBeginDrawEditors();

            MenuTree.DrawSearchToolbar();
        }
    }

    public class CreateNewAsset
    {
        private Type _type;
        [SerializeField, InlineEditor] private ScriptableObject _data;

        [field: SerializeField]
        public string Name { get; private set; } = "New Data";


        public CreateNewAsset(Type type)
        {
            _type = type;
            _data = ScriptableObject.CreateInstance(_type);
        }

        [Button("Create New")]
        private void CreateNew()
        {
            string path = GetProjectWindowPath();
            AssetDatabase.CreateAsset(_data, $"{path}{Name}.asset");
            AssetDatabase.SaveAssets();
        }

        // gets the active folder path from unity editor
        private string GetProjectWindowPath()
        {
            // we're using reflection to analyze a class, find a specific private function, and then call it.
            Type ProjectWindoUtilType = typeof(ProjectWindowUtil);
            MethodInfo getActiveFolderpath = ProjectWindoUtilType.GetMethod("GetActiveFolderPath", BindingFlags.Static | BindingFlags.NonPublic);
            object obj = getActiveFolderpath.Invoke(null, new object[0]);
            return $"{obj}/";
        }
    }

}
