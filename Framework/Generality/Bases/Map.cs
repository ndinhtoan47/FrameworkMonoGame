

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace Framework.Generality.Bases
{
    public class Map
    {
        private List<Tile> _tiles;
        private int[,] _map;
        private int _size;

        public Map()
        {
            _tiles = new List<Tile>();
        }

        public void Init(int[,] map, int size)
        {
            _map = map;
            _size = size;
            if (_map != null)
            {
                int i = _map.GetLength(0);
                int j = _map.GetLength(1);
                for (int y = 0; y < i; y++)
                {
                    for (int x = 0; x < j; x++)
                    {
                        _tiles.Add(new Tile(_map[y, x], new Vector2(x * _size, y * _size), _size));
                    }
                }
            }
        }
        public void LoadContents(ContentManager contents)
        {
            foreach (Tile i in _tiles)
            {
                i.LoadContents(contents);
            }
        }
        public void Update(float deltaTime, ContentManager contents)
        {
            foreach (Tile i in _tiles)
            {
                i.Update(deltaTime, contents);
            }
        }
        public void Draw(SpriteBatch sp)
        {
            foreach (Tile i in _tiles)
            {
                i.Draw(sp);
            }
        }
    }
}
