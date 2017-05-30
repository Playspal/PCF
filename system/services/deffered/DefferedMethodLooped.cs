using System;

namespace com.playspal.core.system.services.deffered
{
    public class DefferedMethodLooped : DefferedMethod
    {
        private Func<DefferedMethodState> _callback;

        public DefferedMethodLooped(Func<DefferedMethodState> callback, float timer = 0, DefferedMethodType type = DefferedMethodType.DelayFrames)
        {
            _callback = callback;

            Initialization(timer, type);
        }

        override public DefferedMethodState Execute()
        {
            if (_delay <= 0)
            {
                _delay = _delayDefined;

                return _callback.InvokeIfNotNull();
            }

            else
            {
                _delay -= _type == DefferedMethodType.DelayFrames ? 1 : Core.DeltaTime;

                return DefferedMethodState.Alive;
            }
        }
    }
}