using System;
using System.Collections;

namespace com.playspal.core.system.services.deffered
{
    public class DefferedMethod
    {
        private int _timer = 0;
        private Action _callback = null;

        public DefferedMethod(Action callback, int timer = 0)
        {
            _callback = callback;
            _timer = timer;

            DefferedMethods.Register(this);
        }

        public bool Execute()
        {
            if (_timer <= 0)
            {
                _callback.InvokeIfNotNull();

                return true;
            }

            else
            {
                _timer--;

                return false;
            }
        }
    }
}
