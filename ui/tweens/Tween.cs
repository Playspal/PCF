using UnityEngine;

using System;
using System.Collections;

using com.playspal.core.system.services.deffered;

namespace com.playspal.core.ui.tweens
{
    public class Tween
    {
        private float _definedValue1;
        private float _definedValue2;

        private float _valueCurrent;
        private float _valueTarget;
        private float _valueDelta;

        private float _time = 1.0f;

        public bool Loop = false;

        public Action<float> OnTick;
        public Action<float> OnComplete;

        public Tween() { }

        public Tween(float current, float target, float time)
        {
            Run(current, target, time);
        }

        internal void Run(float current, float target, float time)
        {
            _time = time;

            _definedValue1 = current;
            _definedValue2 = target;

            _valueCurrent = current;
            _valueTarget = target;
            _valueDelta = Mathf.Abs(_valueTarget - _valueCurrent);

            Process();
        }

        private void Process()
        {
            float elapsed = Core.DeltaSecondsFixed;

            float timeDelta = elapsed / _time;
            float step = _valueDelta * timeDelta;

            if (_valueCurrent < _valueTarget)
            {
                _valueCurrent += step;
            }

            if (_valueCurrent > _valueTarget)
            {
                _valueCurrent -= step;
            }

            if (Mathf.Abs(_valueCurrent - _valueTarget) > step)
            {
                OnTick.InvokeIfNotNull(_valueCurrent);
            }

            else
            {
                if (!Loop)
                {
                    OnTick.InvokeIfNotNull(_valueTarget);
                    OnComplete.InvokeIfNotNull(_valueTarget);

                    return;
                }
                else
                {
                    if(_valueTarget == _definedValue1)
                    {
                        _valueTarget = _definedValue2;
                    }

                    else
                    {
                        _valueTarget = _definedValue1;
                    }
                }
            }

            new DefferedMethod(Process, 0);
        }
    }
}
