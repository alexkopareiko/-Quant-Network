using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Windows;

public class KeyboardInput : BaseInput
{

    public string TurnInputName = "Horizontal";

    public override InputData GenerateInput()
    {
        return new InputData
        {
            Accelerate = UnityEngine.Input.GetAxis(TurnInputName) > 0,
            Brake = UnityEngine.Input.GetAxis(TurnInputName) < 0,
        };
    }
}
