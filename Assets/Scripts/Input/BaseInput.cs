using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct InputData
{
    public bool Accelerate;
    public bool Brake;

    public static InputData operator +(InputData x, InputData y)
    {
        return new InputData
        {
            Accelerate = x.Accelerate ? x.Accelerate : y.Accelerate,
            Brake = x.Brake ? x.Brake : y.Brake,
        };
    }
}


public interface IInput
{
    InputData GenerateInput();
}

public abstract class BaseInput : MonoBehaviour, IInput
{
    /// <summary>
    /// Override this function to generate an XY input that can be used to steer and control the car.
    /// </summary>
    public abstract InputData GenerateInput();
}
