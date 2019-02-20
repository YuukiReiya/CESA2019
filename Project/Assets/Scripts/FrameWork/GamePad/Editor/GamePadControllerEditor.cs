using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Utility;

[CustomEditor(typeof(GamePadController))]
public class GamePadControllerEditor : Editor
{
    GamePadController.Property property = GamePadController.Property.SENSITIVITY;

    //  Property
    float gravity = 1;
    float dead = 0.3f;
    float sensitivity = 0.5f;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        property = (GamePadController.Property)EditorGUILayout.EnumPopup(new GUIContent("設定項目", "入力デバイスの種類"), property);

        
        switch(property)
        {
            //  感度
            case GamePadController.Property.SENSITIVITY:
                {
                    sensitivity = EditorGUILayout.FloatField(new GUIContent("感度", "スティックを倒した時の移動量。"), sensitivity);
                    break;
                }
            //  死域
            case GamePadController.Property.DEAD:
                {
                    dead        = EditorGUILayout.FloatField(new GUIContent("死域", "この値以下の入力値を無視する。"), dead);
                    break;
                }
            //  ニュートラルに戻る速度
            case GamePadController.Property.GRAVITY:
                {
                    gravity     = EditorGUILayout.FloatField(new GUIContent("ニュートラル", "入力(押したキー) がニュートラルに戻る速さ。"), gravity);
                    break;
                }
        }


        if(GUILayout.Button("値を書き換える"))
        {
            Overwrite();
        }

        if(GUILayout.Button("値のリセット"))
        {
            Reset();
            Overwrite();
        }
    }

    /// <summary>
    /// 値をデフォルトに戻す
    /// </summary>
    void Reset()
    {
        gravity = 1;
        dead = 0.3f;
        sensitivity = 0.5f;
    }

    /// <summary>
    /// 設定値の書き換え
    /// </summary>
    void Overwrite()
    {
        MyInput.InputManagerSetter.ims.Clear();
        MyInput.Gamepad.GamePadProperty.PropertySet(
            gravity,
            dead,
            sensitivity,
            false,
            true
            );
    }
}
