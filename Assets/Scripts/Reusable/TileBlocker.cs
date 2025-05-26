using UnityEngine;
using UnityEngine.Tilemaps;

public class TileBlocker : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private QuestData questData;
    [SerializeField] private Vector3Int[] tilesToClear;

    private bool hasCleared = false;

   private void Update()
{
    if (!hasCleared && questData.hasBeenAcknowledged)
    {
        foreach (var pos in tilesToClear)
        {
            tilemap.SetTile(pos, null);
        }

        hasCleared = true;
    }
}

}
