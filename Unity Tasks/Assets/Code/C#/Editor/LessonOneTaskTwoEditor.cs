using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(LessonOneTaskTwo))]
public class LessonOneTaskTwoEditor : Editor
{
    #region [ Fields ]
    private LessonOneTaskTwo _target;
    private SerializedProperty _textProp;
    private SerializedProperty _intProp;
    private SerializedProperty _floatProp;
    private SerializedProperty _boolProp;
    #endregion
    
    #region [ UXML ]
    private VisualElement _root;
    private Label _taskCompletedLabel;
    private Label _variableDisplayLabel;
    #endregion
    
    

    private void OnEnable()
    {
        _textProp = serializedObject.FindProperty("text");
        _intProp = serializedObject.FindProperty("integerNumber");
        _floatProp = serializedObject.FindProperty("rationalNumber");
        _boolProp = serializedObject.FindProperty("boolean");
    }
    
    public override bool UseDefaultMargins() => false;
    public override VisualElement CreateInspectorGUI()
    {
        _target = target as LessonOneTaskTwo;
        
        _root = LoadVisualTreeAssetAndGetRoot();
        RegisterElements();

        SetDefaultValues();
        _root.schedule.Execute(UpdateUI).Every(200);
        
        return _root;
    }
    
    private VisualElement LoadVisualTreeAssetAndGetRoot()
    {
        VisualTreeAsset taskUI = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Code/UXML/Lesson 1 Task 2.uxml"); 
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
        
        _textProp.stringValue = "";
        _intProp.intValue = 0;
        _floatProp.floatValue = 0;
        _boolProp.boolValue = false;
        
        serializedObject.ApplyModifiedProperties();
    }
    
    private void UpdateUI()
    {
        serializedObject.Update();
        
        _variableDisplayLabel.text =
            "Variable Display\n" +
            $"      Text: <color=#c1f2eb>{_textProp.stringValue}</color> \n" +
            $"      Integer Number: <color=#c1f2eb>{_intProp.intValue}</color> \n" +
            $"      Rational Number: <color=#c1f2eb>{_floatProp.floatValue}</color> \n" +
            $"      Boolean: <color=#c1f2eb>{_boolProp.boolValue}</color>";
        
        bool stringPopulated = !string.IsNullOrEmpty(_textProp.stringValue);
        bool intPopulated = _intProp.intValue != 0;
        bool floatPopulated = !Mathf.Approximately(_floatProp.floatValue, 0);
        bool boolPopulated = _boolProp.boolValue;
        
        bool taskCompleted = stringPopulated && intPopulated && floatPopulated && boolPopulated;
        
        _taskCompletedLabel.text = taskCompleted ? 
            "Task Completed: <color=#b2f759>True</color>" : 
            "Task Completed: <color=#f96c4f>False</color>";
    }
}
