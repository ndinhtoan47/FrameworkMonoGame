
using Framework.Generality.Bases;
using System.Collections.Generic;
namespace Framework.Generality.Managers
{
    public static class GameManager
    {
        public enum GameState
        {
            Playing,
            Paused,
            Over,
            None,
        };
        static private ulong _objId = 0;
        static private ObjectManager _objects = new ObjectManager();


        static public ulong GetId()
        {
            _objId++;
            return _objId;
        }
        // object manager
        static public void AddObject(Object obj)
        {
            _objects.Add(obj);
        }
        static public void RemoveObject(Object obj)
        {
            _objects.Remove(obj);
        }
        static public List<Object> GetAllObject()
        {
            return _objects.GetAllObject();
        }
        static public Object.Essential EssentialObject(Object obj)
        {
            return _objects.EssentalObject(obj);
        }
    }
}
