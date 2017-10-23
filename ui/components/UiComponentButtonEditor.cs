#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace com.playspal.core.ui.components
{
    [CustomEditor(typeof(UiComponentButton))]
    public class UiComponentButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            UiComponentButton button = target as UiComponentButton;

            button.IsEnabled = EditorGUILayout.Toggle(new GUIContent("Enabled", ""), button.IsEnabled);

            button._transitionType = (UiComponentButton.TransitionType)EditorGUILayout.EnumPopup("Transition Type", button._transitionType);

            switch(button._transitionType)
            {
                case UiComponentButton.TransitionType.None:
                    break;

                case UiComponentButton.TransitionType.ObjectsSwap:
                    button._objectNormal = (GameObject)EditorGUILayout.ObjectField("    Normal", button._objectNormal, typeof(GameObject), allowSceneObjects: true);
                    button._objectHover = (GameObject)EditorGUILayout.ObjectField("    Hover", button._objectHover, typeof(GameObject), allowSceneObjects: true);
                    button._objectPressed = (GameObject)EditorGUILayout.ObjectField("    Pressed", button._objectPressed, typeof(GameObject), allowSceneObjects: true);
                    button._objectDisabled = (GameObject)EditorGUILayout.ObjectField("    Disabled", button._objectDisabled, typeof(GameObject), allowSceneObjects: true);

                    button._transitionTime = EditorGUILayout.FloatField(new GUIContent("    Transition Time", ""), button._transitionTime);
                    
                    break;

                case UiComponentButton.TransitionType.Animation:
                    button._animator = (Animator)EditorGUILayout.ObjectField("    Animator", button._animator, typeof(Animator), allowSceneObjects: true);

                    button._animationTriggerNormal = EditorGUILayout.TextField("    Trigger Normal", button._animationTriggerNormal);
                    button._animationTriggerHover = EditorGUILayout.TextField("    Trigger Hover", button._animationTriggerHover);
                    button._animationTriggerPressed = EditorGUILayout.TextField("    Trigger Pressed", button._animationTriggerPressed);
                    button._animationTriggerDisabled = EditorGUILayout.TextField("    Trigger Disabled", button._animationTriggerDisabled);
                    break;
            }

            EditorGUILayout.PropertyField(serializedObject.FindProperty("_captions"), new GUIContent("Captions [?]", "Array of text fields that can be changed dynamically"), includeChildren: true);

            button._interactionDelay = EditorGUILayout.FloatField(new GUIContent("Interaction Delay [?]", "Time in seconds to prevent undesirable interactions repeat like double click"), button._interactionDelay);

            button._signalClick = EditorGUILayout.TextField(new GUIContent("Signal Click Name", ""), button._signalClick);
            button._signalPress = EditorGUILayout.TextField("Signal Press Name", button._signalPress);
            button._signalRelease = EditorGUILayout.TextField("Signal Release Name", button._signalRelease);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif