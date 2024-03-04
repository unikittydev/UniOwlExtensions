using UnityEngine;

namespace UniOwl
{
    [CreateAssetMenu(menuName = "Game/Cursor Data", fileName = "SO_CursorData")]
    public class CursorData : ScriptableObject
    {
        public Texture2D cursor;
        public Vector2 hotSpot;
    }
}