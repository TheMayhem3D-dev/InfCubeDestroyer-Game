using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LinearInterpolation : MonoBehaviour
    {
        private GameObject interpolatedObject;

        private Vector3 startPoint;
        private Vector3 endPoint;

        private float interpolationSpeed = 1.0F;
        private float startInterpolaionTimeStamp;

        public void SetInterpolatedObject(GameObject _interpolatedObject)
        {
            interpolatedObject = _interpolatedObject;
        }

        public void SetPoints(Vector3 _start, Vector3 _end)
        {
            startPoint = _start;
            endPoint = _end;
        }

        public void SetSpeed(float value)
        {
            interpolationSpeed = value;
        }

        public void StartInterpolate()
        {
            if (CanInterpolate())
            {
                startInterpolaionTimeStamp = Time.time;
            }
        }

        public void StopInterpolate()
        {
            if (CanInterpolate())
            {
                interpolatedObject.transform.position = startPoint;
                endPoint = Vector3.zero;
            }
        }


        void Update()
        {
            if (CanInterpolate())
            {
                Interpolate();
            }
        }

        private bool CanInterpolate()
        {
            return (startPoint != null && endPoint != null) && 
                (startPoint != Vector3.zero && endPoint != Vector3.zero);
        }

        private void Interpolate()
        {
            float distCovered = (Time.time - startInterpolaionTimeStamp) * interpolationSpeed;

            float fractionOfDist;
            if (interpolationSpeed >= 1f)
                fractionOfDist = distCovered / interpolationSpeed;
            else
                fractionOfDist = (distCovered / interpolationSpeed) / interpolationSpeed;

            interpolatedObject.transform.position = Vector3.Lerp(startPoint, endPoint, fractionOfDist);
        }
    }
}