using Gameplay.Controllers;
using UnityEditor;
using UnityEngine;

namespace Gameplay.Editor
{
    [CustomEditor(typeof(SpawnSheepController))]
    public class SpawnSheepEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            SpawnSheepController spawner = (SpawnSheepController)target;
            
            if (GUILayout.Button("Spawn Sheep"))
            {
                spawner.SpawnNewSheep();
            }
        }
    }
}
