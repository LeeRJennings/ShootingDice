using System;

namespace ShootingDice
{
    // TODO: Complete this class

    // Override the Play method to make a Player who always roles one higher than the other player
    public class OneHigherPlayer : Player
    {
        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int otherRoll = 0;
            if (other is HumanPlayer)
            {
                Console.WriteLine("What's your dice number?");
                otherRoll = int.Parse(Console.ReadLine());
            }
            else 
            {
                otherRoll = other.Roll();
            }
            
            int myRoll = otherRoll + 1;

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
