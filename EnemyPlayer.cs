//Start of AI implementation. Not working so commented out for now.

/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipGame
{
    internal class EnemyPlayer
    {
        Random random = new Random();
        private const int CARRIER = 5;
        private const int BATTLESHIP = 4;
        private const int DESTROYER = 3;
        private const int SUBMARINE = 3;
        private const int PATROLBOAT = 2;

        public EnemyPlayer()
        {
            Carrier = GeneratePosistion(CARRIER, AllShipsPosition);
            Battleship = GeneratePosistion(BATTLESHIP, AllShipsPosition);
            Destroyer = GeneratePosistion(DESTROYER, AllShipsPosition);
            Submarine = GeneratePosistion(SUBMARINE, AllShipsPosition);
            PatrolBoat = GeneratePosistion(PATROLBOAT, AllShipsPosition);
        }

        public int StepsTaken { get; set; } = 0;

        public List<Position> Carrier { get; set; }//5
        public List<Position> Battleship { get; set; }//4
        public List<Position> Destroyer { get; set; }//3
        public List<Position> Submarine { get; set; }//3
        public List<Position> PatrolBoat { get; set; }//2
        public List<Position> AllShipsPosition { get; set; } = new List<Position>();
        public List<Position> FirePositions { get; set; } = new List<Position>();


        public bool IsCarrierSunk { get; set; } = false;
        public bool IsBattleshipSunk { get; set; } = false;
        public bool IsDestroyerSunk { get; set; } = false;
        public bool IsSubmarineSunk { get; set; } = false;
        public bool IsPatrolBoatSunk { get; set; } = false;
        public bool IsObliteratedAll { get; set; } = false;


        public bool CheckCarrier { get; set; } = true;
        public bool CheckPBattleship { get; set; } = true;
        public bool CheckDestroyer { get; set; } = true;
        public bool CheckSubmarine { get; set; } = true;
        public bool CheckPatrolBoat { get; set; } = true;

        public EnemyPlayer CheckShipStatus(List<Position> HitPositions)
        {

            IsCarrierSunk = Carrier.Where(C => !HitPositions.Any(H => C.x == H.x && C.y == H.y)).ToList().Count == 0;
            IsBattleshipSunk = Battleship.Where(B => !HitPositions.Any(H => B.x == H.x && B.y == H.y)).ToList().Count == 0;
            IsDestroyerSunk = Destroyer.Where(D => !HitPositions.Any(H => D.x == H.x && D.y == H.y)).ToList().Count == 0;
            IsSubmarineSunk = Submarine.Where(S => !HitPositions.Any(H => S.x == H.x && S.y == H.y)).ToList().Count == 0;
            IsPatrolBoatSunk = PatrolBoat.Where(P => !HitPositions.Any(H => P.x == H.x && P.y == H.y)).ToList().Count == 0;


            IsObliteratedAll = IsCarrierSunk && IsBattleshipSunk && IsDestroyerSunk && IsSubmarineSunk && IsPatrolBoatSunk;
            return this;
        }



        public EnemyPlayer Fire()
        {
            Position EnemyShotPos = new Position();
            bool alreadyShot = false;
            do
            {
                EnemyShotPos.x = random.Next(1, 11);
                EnemyShotPos.y = random.Next(1, 11);
                alreadyShot = FirePositions.Any(EFP => EFP.x == EnemyShotPos.x && EFP.y == EnemyShotPos.y);
            }
            while (alreadyShot);

            FirePositions.Add(EnemyShotPos);
            return this;
        }
    }
}*/
