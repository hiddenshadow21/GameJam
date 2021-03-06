﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    void Update()
    {
        LockCameraToPlayer();
    }

    private void LockCameraToPlayer()
    {
        Vector3 pos = player.transform.position;
        pos.z = -10;
        transform.position = pos;
    }
}
