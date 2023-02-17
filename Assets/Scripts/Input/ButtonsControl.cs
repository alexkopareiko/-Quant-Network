using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsControl : MonoBehaviour
{
    [Header("Images")]
    [SerializeField] Image gasImg;
    [SerializeField] Image brakeImg;

    [Header("Sprites")]
    [SerializeField] Sprite gasSprite;
    [SerializeField] Sprite brakeSprite;
    [SerializeField] Sprite gasPressedSprite;
    [SerializeField] Sprite brakePressedSprite;

    [Header("Vars")]
    public bool accelerate;
    public bool brake;

    public void Accelerate(bool check)
    {
        accelerate = check;
        gasImg.sprite = check ? gasPressedSprite : gasSprite;
    }

    public void Brake(bool check)
    {
        brake = check;
        brakeImg.sprite = check ? brakePressedSprite : brakeSprite;
    }
}
