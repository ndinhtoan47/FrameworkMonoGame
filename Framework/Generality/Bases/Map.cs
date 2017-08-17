

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

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
                i.Update(deltaTime);
            }
        }
        public void Draw(SpriteBatch sp)
        {
            foreach (Tile i in _tiles)
            {
                i.Draw(sp);
            }
        }
        public int[,] LoadFileMap(string path)
        {
            List<int[]> map = new List<int[]>();
            try
            {
                StreamReader reader = new StreamReader(path);
                char[] chararray = null;
                string line = reader.ReadLine();
                int count = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ') count++;
                }
                while (line != null)
                {
                    chararray = line.ToCharArray();
                    int[] temp = new int[count];
                    int index = 0;
                    for (int i = 0; i < chararray.Length; i++)
                    {
                        if (chararray[i] != ' ' && index < count)
                        {
                            temp[index] = (int)chararray[i] - 48;
                            index++;
                        }
                    }
                    map.Add(temp);
                    line = reader.ReadLine();
                }
            }
            catch (Exception e)
            {

            }
            int x = map.Count;
            int y = map[0].Length;
            int[,] result = new int[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    result[i, j] = map[i][j];
                }
            }
            return result;
        }
    }
}
