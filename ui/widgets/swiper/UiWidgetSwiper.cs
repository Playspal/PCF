using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections.Generic;

using com.playspal.core.utils.helpers;
using com.playspal.core.ui.widgets.levels;

namespace com.playspal.core.ui.widgets.swiper
{
    public class UiWidgetSwiper : UiObject
    {
        private RectTransform _container;

        private List<UiObject> _items = new List<UiObject>();

        private bool _isDrag = false;
        private bool _isSwipeInProgress = false;

        private float _dragMouseStartPosition = 0f;
        private float _dragMouseLastFramePosition = 0f;

        private float _containerTargetPosition = 0f;
        private float _containerCurrentPosition = 0f;

        private int _pageCurrent = 0;

        public Action<int> OnPageChanged;

        private int _pagesTotal
        {
            get
            {
                return _items.Count;
            }
        }

        public UiWidgetSwiper(GameObject screen)
        {
            SetScreen(screen);

            _container = UnityUiHelper.CreateEmpty("container");
            _container.SetParent(ScreenTransform);
            _container.localScale = new Vector3(1, 1, 1);
            _container.anchoredPosition = Vector2.zero;
        }

        public void AddChildsGroup(List<UiObject> childs)
        {
            foreach(UiObject child in childs)
            {
                AddChild(child);
            }
        }

        public void AddChild(UiObject child)
        {
            _items.Add(child);

            child.SetParent(_container);
        }

        public void SetPage(int value)
        {
            _pageCurrent = value;

            _containerCurrentPosition = _containerTargetPosition = 0;
            _container.anchoredPosition = new Vector2(_containerCurrentPosition, _container.anchoredPosition.y);

            foreach(UiObject item in _items)
            {
                item.SetPositionOutOfScreen();
            }

            if (value > 0)
            {
                _items[value - 1].SetPosition(-UiRoot.DefinedScreenWidth, 0);
            }

            if (value >= 0 && value < _items.Count)
            {
                _items[value].SetPosition(0, 0);
            }

            if (value < _items.Count - 1)
            {
                _items[value + 1].SetPosition(UiRoot.DefinedScreenWidth, 0);
            }

            OnPageChanged.InvokeIfNotNull(_pageCurrent);
        }

        private void OnMousePressHandler()
        {
            if(_isSwipeInProgress)
            {
                return;
            }

            _isDrag = true;

            _dragMouseStartPosition = Input.mousePosition.x;
            _dragMouseLastFramePosition = 0;
        }

        private void OnMouseReleaseHandler()
        {
            _isDrag = false;
        }

        private void SwipeRight()
        {
            if (_pageCurrent == 0)
            {
                return;
            }

            _pageCurrent--;

            _isDrag = false;
            _isSwipeInProgress = true;

            _containerTargetPosition = UiRoot.DefinedScreenWidth;
        }

        private void SwipeLeft()
        {
            if (_pageCurrent == _pagesTotal - 1)
            {
                return;
            }

            _pageCurrent++;

            _isDrag = false;
            _isSwipeInProgress = true;

            _containerTargetPosition = -UiRoot.DefinedScreenWidth;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMousePressHandler();
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnMouseReleaseHandler();
            }

            if(_isDrag)
            {
                float delta = Input.mousePosition.x - _dragMouseStartPosition;
                float speed = Input.mousePosition.x - _dragMouseLastFramePosition;

                float x = _containerTargetPosition + delta * 4;

                _containerCurrentPosition += (x - _containerCurrentPosition) * 0.25f;

                if (_dragMouseLastFramePosition != 0)
                {
                    if (delta > UnityEngine.Screen.width * 0.5f || speed > 20) SwipeRight();
                    if (delta < -UnityEngine.Screen.width * 0.5f || speed < -20) SwipeLeft();
                }

                _dragMouseLastFramePosition = Input.mousePosition.x;
            }

            UpdateContainer();
        }

        private void UpdateContainer()
        {
            float containerSpeed = (_containerTargetPosition - _containerCurrentPosition) * 0.25f;

            if (Mathf.Abs(containerSpeed) < 1)
            {
                _containerCurrentPosition = _containerTargetPosition;
                _container.anchoredPosition = new Vector2(_containerCurrentPosition, _container.anchoredPosition.y);


                if (_isSwipeInProgress)
                {
                    _isSwipeInProgress = false;

                    SetPage(_pageCurrent);
                }
            }

            else
            {
                _containerCurrentPosition += containerSpeed;
                _container.anchoredPosition = new Vector2(_containerCurrentPosition, _container.anchoredPosition.y);
            }
        }
    }
}
