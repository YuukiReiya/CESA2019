/******************************************************************/
/*      制作:IT高度専門学科2年 番場 宥輝   (2018/02/26 現在)      */
/******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyInput.Gamepad;

/// <summary>
/// 入力管理クラス
/// </summary>
public class MyInputManager : MonoBehaviour {
    
    public enum InputDevice
    {
        GamePad,
        Keyboard,
    }
    [System.NonSerialized]
    public InputDevice device;

    [System.NonSerialized]
    public float gamePad_dead = 0;
    [System.NonSerialized]
    public float gamePad_sensitivity = 0;
    [System.NonSerialized]
    public float gamePad_gravity = 0;
    [System.NonSerialized]
    public bool joyStickX_invert = false;
    [System.NonSerialized]
    public bool joyStickY_invert = false;

    /// <summary>
    /// 入力をとるコントローラー
    /// </summary>
    public static GamePad AllController { get; private set; }
    public static GamePad Controller1 { get; private set; }
    public static GamePad Controller2 { get; private set; }
    public static GamePad Controller3 { get; private set; }
    public static GamePad Controller4 { get; private set; }

    /// <summary>
    /// Awake()でコントローラーのインスタンス生成
    /// </summary>
    private void Awake()
    {
        if (!AllController) { AllController = gameObject.AddComponent<GamePad>(); }
        if (!Controller1) { Controller1 = gameObject.AddComponent<GamePad>(); }
        if (!Controller2) { Controller2 = gameObject.AddComponent<GamePad>(); }
        if (!Controller3) { Controller3 = gameObject.AddComponent<GamePad>(); }
        if (!Controller4) { Controller4 = gameObject.AddComponent<GamePad>(); }

        AllController.SetParameter(gamePad_dead);
        Controller1.SetParameter(gamePad_dead);
        Controller2.SetParameter(gamePad_dead);
        Controller3.SetParameter(gamePad_dead);
        Controller4.SetParameter(gamePad_dead);

        AllController.Controller = GamePad.Index.ALL;
        Controller1.Controller = GamePad.Index.One;
        Controller2.Controller = GamePad.Index.Two;
        Controller3.Controller = GamePad.Index.Three;
        Controller4.Controller = GamePad.Index.Four;
    }
}
