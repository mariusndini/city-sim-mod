using System;
using System.Collections.Generic;
using UnityEngine;
using ICities;
using ColossalFramework;
using ColossalFramework.UI;

namespace data
{
    class Camera
    {
        static CameraController camera = GameObject.FindObjectOfType<CameraController>();

        public static void MoveCamera(float target, float x, float y, float z, float angleX, float angleY)
        {
            camera.m_targetSize = target;
            camera.m_targetPosition = new Vector3(x, y, z);
            camera.m_targetAngle = new Vector3(angleX, angleY);
            //camera.m_targetSize = 207.11f;
            //camera.m_targetPosition = new Vector3(274.4818f, 64.92877f, 1571.701f);
            //camera.m_targetAngle = new Vector3(-54.58361f, 71.16071f);
        }

    }
}
