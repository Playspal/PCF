using System.Collections;

namespace com.playspal.core.system.services.deffered
{
    public class DefferedMethods
    {
        private static DefferedMethod[] _items = new DefferedMethod[1024];
        private static int _itemsLength = 0;

        private static DefferedMethod[] _itemsCache = new DefferedMethod[1024];
        private static int _itemsCacheLength = 0;

        public static void Register(DefferedMethod item)
        {
            _itemsCache[_itemsCacheLength] = item;
            _itemsCacheLength++;
        }

        public static void Process()
        {
            // TODO: boutle neck
            int i;

            DefferedMethod[] temp = new DefferedMethod[1024];
            int tempLength = 0;

            for (i = 0; i < _itemsCacheLength; i++)
            {
                _items[_itemsLength] = _itemsCache[i];
                _itemsLength++;
            }

            _itemsCacheLength = 0;

            for (i = 0; i < _itemsLength; i++)
            {
                if (_items[i].Execute() == false)
                {
                    temp[tempLength] = _items[i];
                    tempLength++;
                }
            }

            _items = temp;
            _itemsLength = tempLength;
        }
    }
}
