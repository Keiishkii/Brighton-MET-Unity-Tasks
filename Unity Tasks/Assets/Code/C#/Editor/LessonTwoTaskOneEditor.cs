using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(LessonTwoTaskOne))]
public class LessonTwoTaskOneEditor : Editor
{
    #region [ Fields ]
    private LessonTwoTaskOne _target;
    private SerializedProperty _enemyHealthProperty;
    #endregion
    
    #region [ UXML ]
    private VisualElement _root;
    private Label _taskCompletedLabel;
    private Label _variableDisplayLabel;
    #endregion



    private void OnEnable()
    {
        _enemyHealthProperty = serializedObject.FindProperty("enemyHealth");
    }
    
    
    public override bool UseDefaultMargins() => false;
    public override VisualElement CreateInspectorGUI()
    {
        _target = target as LessonTwoTaskOne;
        
        _root = LoadVisualTreeAssetAndGetRoot();
        RegisterElements();

        SetDefaultValues();
        _root.schedule.Execute(UpdateUI).Every(200);
        
        return _root;
    }
    
    private VisualElement LoadVisualTreeAssetAndGetRoot()
    {
        VisualTreeAsset taskUI = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Code/UXML/Lesson 2 Task 1.uxml"); 
        _root = taskUI.CloneTree();
        
        return _root;
    }

    private void RegisterElements()
    {
        _taskCompletedLabel = _root.Q<Label>("TaskCompletedLabel");
        _variableDisplayLabel = _root.Q<Label>("VariableDisplayLabel");
    }

    private void SetDefaultValues()
    {
        serializedObject.Update();
        
        serializedObject.ApplyModifiedProperties();
    }

    private void UpdateUI()
    {
        serializedObject.Update();

        _variableDisplayLabel.text = $"Enemy Health: {Mathf.Max(_enemyHealthProperty.intValue, 0)}";
        
        bool taskCompleted = _enemyHealthProperty.intValue <= 0;
        _taskCompletedLabel.text = taskCompleted ? 
            "Task Completed: <color=#b2f759>True</color>" : 
            "Task Completed: <color=#f96c4f>False</color>";
    }
}
