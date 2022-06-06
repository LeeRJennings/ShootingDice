using System;

namespace ShootingDice
{
    public class Player
    {
        public string Name { get; set; }
        public int DiceSize { get; set; } = 6;

        public virtual int Roll()
        {
            // Return a random number between 1 and DiceSize
            return new Random().Next(DiceSize) + 1;
        }

        public virtual void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int myRoll = Roll();
            int otherRoll = 0;
            if (other is OneHigherPlayer) 
            {
                otherRoll = myRoll + 1;
            }
            else if (other is HumanPlayer)
            {
                Console.WriteLine("What's your dice number?");
                otherRoll = int.Parse(Console.ReadLine());
            }
            else
            {
                otherRoll = other.Roll();
            }

            Console.WriteLine($"{Name} rolls a {myRoll}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
            
            if (other is SmackTalkingPlayer)
            {
                Console.WriteLine($"{other.Name} says: {((SmackTalkingPlayer)other).Taunt}");
            }

            if (myRoll > otherRoll)
            {
                Console.WriteLine($"{Name} Wins!");
            }
            else if (myRoll < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie
                Console.WriteLine("It's a tie");
            }
        }
    }
}