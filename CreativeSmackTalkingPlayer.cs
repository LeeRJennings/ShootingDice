using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        public List<string> _tauntList = new List<string>{
            "HAHAH!",
            "You lose!",
            "My mom plays better"
        };

        public int RandomTaunt()
        {
            int randomNumber = new Random().Next(_tauntList.Count);
            return randomNumber;
        }

        public override void Play(Player other)
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
            Console.WriteLine($"{Name} says: {RandomTaunt()}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
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