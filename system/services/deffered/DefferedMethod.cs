using System;

namespace com.playspal.core.system.services.deffered
{
    public class DefferedMethod
    {
        public static readonly bool STOP = true;
        public static readonly bool NEXT = false;

        protected float _delay;
        protected float _delayDefined;

        protected DefferedMethodType _type;

        private Action _callback;

        public DefferedMethod() { }

        public DefferedMethod(Action callback, float timer = 0, DefferedMethodType type = DefferedMethodType.DelayFrames)
        {
            _callback = callback;

            Initialization(timer, type);
        }

        protected void Initialization(float timer, DefferedMethodType type)
        {
            _delayDefined = timer;
            _delay = timer;
            _type = type;

            DefferedMethods.Register(this);
        }

        public virtual DefferedMethodState Execute()
        {
            if (_delay <= 0)
            {
                _callback.InvokeIfNotNull();

                return DefferedMethodState.Closed;
            }

            else
            {
                _delay -= _type == DefferedMethodType.DelayFrames ? 1 : Core.DeltaTime;

                return DefferedMethodState.Alive;
            }
        }
    }
}
