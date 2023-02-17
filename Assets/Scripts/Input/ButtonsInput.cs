using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsInput : BaseInput
{
    public ButtonsControl buttonsControl;

    public override InputData GenerateInput()
    {
        if (buttonsControl == null)
        {
            return new InputData
            {
                Accelerate = false,
                Brake = false,
            };
        }
        else
        {
            return new InputData
            {
                Accelerate = buttonsControl.accelerate,
                Brake = buttonsControl.brake,
            };
        }
    }


}
