using System;
using System.Collections.Generic;
using UnityEngine;

namespace TBP.LibrarySystem
{
    public enum Biome {}
    public enum TileType {}

    public class LibraryObject
    {
        public string ID;
    }

    public class Item : LibraryObject
    {
        public string description;
        public Sprite icon;
        public string iconID;
    }

    public class Library
    {
        public Dictionary<Type, Dictionary<string, LibraryObject>> content = new Dictionary<Type, Dictionary<string, LibraryObject>>();
        
        public Dictionary<TileType, Dictionary<Biome, WorldTile>> worldTiles = new Dictionary<TileType, Dictionary<Biome, WorldTile>>();
        
        public Library()
        {

        }
    }
}
