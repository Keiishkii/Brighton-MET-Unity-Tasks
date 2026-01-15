using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(LessonOneTaskOne))]
public class LessonOneTaskOneEditor : Editor
{
    #region [ Fields ]
    private LessonOneTaskOne _target;
    private SerializedProperty _taskCompletedProp;
    #endregion
    
    #region [ UXML ]
    private VisualElement _root;
    private Label _taskCompletedLabel;
    #endregion



    private void OnEnable()
    {
        _taskCompletedProp = serializedObject.FindProperty("taskCompleted");
    }
    
    public override bool UseDefaultMargins() => false;
    public override VisualElement CreateInspectorGUI()
    {
        _target = target as LessonOneTaskOne;
        
        _root = LoadVisualTreeAssetAndGetRoot();
        RegisterElements();

        SetDefaultValues();
        _root.schedule.Execute(UpdateUI).Every(200);
        
        return _root;
    }
    
    private VisualElement LoadVisualTreeAssetAndGetRoot()
    {
        VisualTreeAsset taskUI = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Code/UXML/Lesson 1 Task 1.uxml"); 
        _root = taskUI.CloneTree();
        
        return _root;
    }

    private void RegisterElements()
    {
        _taskCompletedLabel = _root.Q<Label>("TaskCompletedLabel");
    }

    private void SetDefaultValues()
    {
        serializedObject.Update();
        _taskCompletedProp.boolValue = false;
        serializedObject.ApplyModifiedProperties();
    }

    private void UpdateUI()
    {
        serializedObject.Update();
        
        _taskCompletedLabel.text = _taskCompletedProp.boolValue ? 
            "Task Completed: <color=#b2f759>True</color>" : 
            "Task Completed: <color=#f96c4f>False</color>";
    }
}
