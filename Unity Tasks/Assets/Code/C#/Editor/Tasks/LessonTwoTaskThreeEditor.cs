using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(LessonTwoTaskThree))]
public class LessonTwoTaskThreeEditor : Editor
{
    #region [ Fields ]
    private LessonTwoTaskThree _target;
    #endregion
    
    #region [ UXML ]
    private VisualElement _root;
    private Label _taskCompletedLabel;
    private Label _variableDisplayLabel;
    #endregion
    
    
    
    public override bool UseDefaultMargins() => false;
    public override VisualElement CreateInspectorGUI()
    {
        _target = target as LessonTwoTaskThree;
        
        _root = LoadVisualTreeAssetAndGetRoot();
        RegisterElements();

        SetDefaultValues();
        _root.schedule.Execute(UpdateUI).Every(200);
        
        return _root;
    }
    
    private VisualElement LoadVisualTreeAssetAndGetRoot()
    {
        VisualTreeAsset taskUI = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Code/UXML/Lesson 2 Task 3.uxml"); 
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
        
        bool taskCompleted = false;
        
        _taskCompletedLabel.text = taskCompleted ? 
            "Task Completed: <color=#b2f759>True</color>" : 
            "Task Completed: <color=#f96c4f>False</color>";
    }
}
