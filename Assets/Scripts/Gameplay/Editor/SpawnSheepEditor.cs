using Gameplay.Controllers;
using Gameplay.Manager;
using UnityEditor;
using UnityEngine;

namespace Gameplay.Editor
{
    [CustomEditor(typeof(SheepManager))]
    public class SpawnSheepEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            SheepManager spawner = (SheepManager)target;
            
            if (GUILayout.Button("Spawn Sheep"))
            {
                spawner.SpawnNewSheep();
            }
        }
    }
}
