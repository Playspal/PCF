using System;

namespace com.playspal.core.system.services.signals
{
    public static class Signals
    {
        private static Signal[] _signals = new Signal[1024];
        private static int _signalsCount = 0;

        /// <summary>
        /// Dispatch signal with provided name
        /// </summary>
        /// <param name="name">Signal name</param>
        public static void Dispatch(string name)
        {
            Signal signal = GetOrCreateSignal(name);
            signal.Handler.InvokeIfNotNull();
        }

        /// <summary>
        /// Subscribe on provided signal
        /// </summary>
        /// <param name="name">Signal name</param>
        /// <param name="handler">Signal handler</param>
        public static void AddListener(string name, Action handler)
        {
            Signal signal = GetOrCreateSignal(name);
            signal.Handler += handler;
        }

        /// <summary>
        /// Unsubscribe from provided signal
        /// </summary>
        /// <param name="name">Signal name</param>
        /// <param name="handler">Signal handler</param>
        public static void RemoveListener(string name, Action handler)
        {
            Signal signal = GetOrCreateSignal(name);
            signal.Handler -= handler;
        }

        // Searches for signal, creates new one if signal not found
        private static Signal GetOrCreateSignal(string name)
        {
            Signal signal = GetSignal(name);

            if(signal == null)
            {
                signal = CreateSignal(name);
            }

            return signal;
        }

        // Searches for signal
        private static Signal GetSignal(string name)
        {
            for(int i = 0; i < _signalsCount; i++)
            {
                if(_signals[i].Name == name)
                {
                    return _signals[i];
                }
            }

            return null;
        }

        // Creates new signal
        private static Signal CreateSignal(string name)
        {
            Signal signal = new Signal
            {
                Name = name
            };

            _signals[_signalsCount] = signal;
            _signalsCount++;

            return signal;
        }
    }
}