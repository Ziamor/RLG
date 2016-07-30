using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(HealthComponent))]
public class Editor_HealthComponent : Editor
{

    HealthComponent _target;

    void OnEnable()
    {
        _target = (HealthComponent)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.Label("The Cake Maker Script!", EditorStyles.boldLabel);
        _target.max_health = EditorGUILayout.FloatField("Max Health", _target.max_health);
        _target.current_health = EditorGUILayout.FloatField("Start Health", _target.current_health);
        /*_target.isDelicious = EditorGUILayout.Toggle("Is it Delicous Cake?", _target.isDelicious); // Our bool
        _target.amountOfChocolate = EditorGUILayout.Slider("How much Chocolate?", _target.amountOfChocolate, 0.0f, 10.0f); // A slider to make thing better looking

        // There is now ay to have a cake without chocolate
        if (_target.amountOfChocolate == 0)
        {
            EditorGUILayout.HelpBox("THERE IS NO CHOCOLATE IN THIS CAKE", MessageType.Error);
        }

        _target.randomNumber = EditorGUILayout.IntField("Just a number", _target.randomNumber); // Common INT field
        _target.cakeColor = EditorGUILayout.ColorField("Color", _target.cakeColor); // Color Field
        _target.cakeT = (DoCake.cakeTypes)EditorGUILayout.EnumPopup("Cake type", _target.cakeT); // Enum Field - It needs proper casting

        if (GUILayout.Button("DO CAKE"))
        {
            _target.BakeTheCake();
        }*/
        GUILayout.EndVertical();

        //If we changed the GUI aply the new values to the script
        if (GUI.changed)
        {
            EditorUtility.SetDirty(_target);
        }
    }
}
