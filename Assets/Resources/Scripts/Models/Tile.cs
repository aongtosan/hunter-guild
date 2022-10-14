using UnityEngine;


/* The Tile class is a class that contains the information of a tile */
public class Tile
{
    // Start is called before the first frame update
   public  const string TILE_NAME_FORMAT = "tile[{0}][{1}]";
   Vector2 id;
   int locationX;
   int locationY;
   int height;
   public int LocationX{
        set{locationX = value;}
        get{ return locationX;}
   }
   public int LocationY{
        set{locationY = value;}
        get{ return locationY;}
   }
    public int Height{
        set{height = value;}
        get{ return height;}
   }
   public Vector2 Id{
        set{id = value;}
        get{ return id;}
   }
}
