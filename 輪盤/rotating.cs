using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. 必須引入新版 Input System 的命名空間
using UnityEngine.InputSystem;

public class rotating : MonoBehaviour
{
    float rotSpeed = 0;

    // 音效播放器
    AudioSource audioSource;


    void Start()
    {
        // 影格速率設為 60FPS
        Application.targetFrameRate = 60;

        // 取得物件上的 AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        bool clicked = false;

        // 電腦滑鼠
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            clicked = true;
        }

        // iPhone 觸控
        if (Touchscreen.current != null &&
            Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            clicked = true;
        }

        if (clicked)
        {
            rotSpeed = 10;

            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        // 讓輪盤依照設定的速度旋轉
        transform.Rotate(0, 0, this.rotSpeed);

        // 讓輪盤減速
        this.rotSpeed *= 0.96f;

        // 速度很小時停止，避免音效一直播放
        if (rotSpeed < 0.05f)
        {
            rotSpeed = 0;

            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
