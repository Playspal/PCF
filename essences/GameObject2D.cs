using UnityEngine;

namespace com.playspal.core.essences
{
    public class GameObject2D
    {
        public bool IsActive = true;

        protected GameObject _model;
        protected Transform _modelTransform;

        public Transform Parent
        {
            get
            {
                return _modelTransform.parent;
            }
        }

        public virtual void Instantiate(string path, string name = "")
        {
            _model = GameObject.Instantiate(Resources.Load(path) as GameObject);
            _modelTransform = _model.transform;

            if (!string.IsNullOrEmpty(name))
            {
                _model.name = name;
            }
        }

        public virtual void SetModel(GameObject model)
        {
            _model = model;
            _modelTransform = _model.transform;
        }

        public virtual void SetActive(bool value)
        {
            if (value == IsActive)
            {
                return;
            }

            IsActive = value;

            _model.SetActive(IsActive);
        }

        public virtual void SetParent(Transform parent)
        {
            _modelTransform.SetParent(parent);
        }

        public virtual void SetPosition(float x, float y)
        {
            _modelTransform.localPosition = new Vector3(x, y, _modelTransform.localPosition.z);
        }

        public virtual void SetPosition(float x, float y, float z)
        {
            _modelTransform.localPosition = new Vector3(x, y, z);
        }

        public virtual void SetDepth(float value)
        {
            _modelTransform.localPosition = new Vector3(_modelTransform.localPosition.x, _modelTransform.localPosition.y, value);
        }

        public virtual void SetScale(float value)
        {
            _modelTransform.localScale = new Vector3(value, value, value);
        }

        public virtual void SetScale(float x, float y)
        {
            _modelTransform.localScale = new Vector3(x, y, 1);
        }

        protected GameObject Find(string name)
        {
            Transform temp = _modelTransform.Find(name);
            return temp != null ? temp.gameObject : null;
        }
    }
}
