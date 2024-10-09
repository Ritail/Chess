 using UnityEngine;

 namespace Chess
 {
     [CreateAssetMenu(fileName = "Queen", menuName = "Piece/Queen")]
     public class Queen : Pièce
     {
         public override Vector2Int[] availableMouvments()
         {
             throw new System.NotImplementedException();
         }
     }
 }