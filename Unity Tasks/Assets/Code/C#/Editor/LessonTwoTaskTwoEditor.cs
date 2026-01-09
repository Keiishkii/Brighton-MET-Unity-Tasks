using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(LessonTwoTaskTwo))]
public class LessonTwoTaskTwoEditor : Editor
{
    #region [ Fields ]
    private LessonTwoTaskTwo _target;
    private SerializedProperty _enemyPresentProperty;
    private SerializedProperty _playerHealthProperty;
    private SerializedProperty _stepCountProperty;
    #endregion
    
    #region [ UXML ]
    private VisualElement _root;
    private Button _walkButton;
    private Button _healButton;
    private Button _attackButton;
    private Label _taskCompletedLabel;
    private Label _variableDisplayLabel;
    #endregion

    
    
    private void OnEnable()
    {
        _enemyPresentProperty = serializedObject.FindProperty("enemyPresent");
        _playerHealthProperty = serializedObject.FindProperty("playerHealth");
        _stepCountProperty = serializedObject.FindProperty("stepsTaken");
    }

    public override bool UseDefaultMargins() => false;
    public override VisualElement CreateInspectorGUI()
    {
        _target = target as LessonTwoTaskTwo;
        
        _root = LoadVisualTreeAssetAndGetRoot();
        RegisterElements();
        RegisterCallbacks();
        
        SetDefaultValues();
        _root.schedule.Execute(UpdateUI).Every(200);
        
        return _root;
    }
    
    private VisualElement LoadVisualTreeAssetAndGetRoot()
    {
        VisualTreeAsset taskUI = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Code/UXML/Lesson 2 Task 2.uxml"); 
        _root = taskUI.CloneTree();
        
        return _root;
    }

    private void RegisterElements()
    {
        _taskCompletedLabel = _root.Q<Label>("TaskCompletedLabel");
        _variableDisplayLabel = _root.Q<Label>("VariableDisplayLabel");
        _walkButton = _root.Q<Button>("WalkButton");
        _healButton = _root.Q<Button>("HealButton");
        _attackButton = _root.Q<Button>("AttackButton");
    }

    private void RegisterCallbacks()
    {
        _walkButton.clicked += _target.OnWalkButtonPressed;
        _healButton.clicked += _target.OnHealButtonPressed;
        _attackButton.clicked += _target.OnAttackButtonPressed;
    }

    private void SetDefaultValues()
    {
        serializedObject.Update();

        _playerHealthProperty.intValue = 100;
        
        serializedObject.ApplyModifiedProperties();
    }
    
    private void UpdateUI()
    {
        serializedObject.Update();
        
        _variableDisplayLabel.text = 
            $"Step Count: {_stepCountProperty.intValue}\n" + 
            $"Player Health: {_playerHealthProperty.intValue}" +
            $"{(_enemyPresentProperty.boolValue ? "\n\nENEMY PRESENT" : "\n\n")}";
        
        bool taskCompleted = _stepCountProperty.intValue >= 10;
        _taskCompletedLabel.text = taskCompleted ? 
            "Task Completed: <color=#b2f759>True</color>" : 
            "Task Completed: <color=#f96c4f>False</color>";
    }
}
