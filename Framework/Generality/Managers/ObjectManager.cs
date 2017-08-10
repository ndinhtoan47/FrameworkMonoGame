using Framework.Generality.Bases;
using System.Collections.Generic;

namespace Framework.Generality.Managers
{
    public class ObjectManager
    {
        private List<Object> _allGameObject;

        public ObjectManager()
        {
            _allGameObject = new List<Object>();
        }

        public void Add(Object obj)
        {
            if(obj != null)
            {
                _allGameObject.Add(obj);
            }
        }
        public void Remove(Object obj)
        {
            if(obj != null)
            {
                _allGameObject.Remove(obj);
            }
        }
        public Object.Essential EssentalObject(Object obj)
        {
            return Object.Essential.NONE;
        }
        // properties
        public List<Object> GetAllObject()
        {
            return _allGameObject;
        }
    }
}
