using System;

namespace Bme121
{
    class YahtzeeDice
    {
        static Random rGen = new Random( );
        int dice1 = 0;
        int dice2 = 0;
        int dice3 = 0;
        int dice4 = 0;
        int dice5 = 0;
       
       
        
        public void Roll( )// Each die gets assigned a random value from 1-6, simulating rolling dies.
        { 
            if (dice1 == 0) dice1 = rGen.Next(1,7);
            if (dice2 == 0) dice2 = rGen.Next(1,7);
            if (dice3 == 0) dice3 = rGen.Next(1,7);
            if (dice4 == 0) dice4 = rGen.Next(1,7);
            if (dice5 == 0) dice5 = rGen.Next(1,7);
        }

        public void Unroll( string faces ) // Relative to the users response certain dice get their face value reset and rerolled.
        { 
            if (faces == "all") // If user rerolls all the dice.
            {
                dice1 = dice2 = dice3 = dice4 = dice5 = 0;
            }
            else
            {
                int u = int.Parse(faces.ToString() ); // If user wants to reroll the dice of a specific face value.
                if (dice1 == u ) { dice1 = 0; }
                if (dice2 == u ) { dice2 = 0; }
                if (dice3 == u ) { dice3 = 0; }
                if (dice4 == u ) { dice4 = 0; }
                if (dice5 == u ) { dice5 = 0; }
            }
        }
                    
        public int Sum( ) // Calculates sum of all the dice; used in 3, 4 of a kind, and chance.
        { 
        return dice1+dice2+dice3+dice4+dice5;
        }

        public int Sum( int face ) // Calculates sum of all the dice of a specific face value; used in upper score.
        { 
            int[ ] dice = new int [5] {dice1, dice2, dice3, dice4, dice5 };
            int v = face;
            int sum = 0;
            for (int i = 0; i < dice.Length; i++)
            {
                if (dice[i] == v)
                {
                   sum = sum + dice[i];
                }
            }
            return sum;
        }

        public bool IsRunOf( int length ) // Used to see if there is a small sequence (4 in a row) or large sequence (5 in a row)
        { 
            int[ ] dice = new int [5] {dice1, dice2, dice3, dice4, dice5 };
            Array.Sort( dice );
            
            bool large = false;
            bool small = false;
            int counter = 0;
            
            // The two possible cases for there to be a large sequence
            if ( (dice[0] == 1) && (dice[1] == 2) && (dice [2] == 3) && (dice[3] == 4) && (dice [4] == 5) ) {large = true;}
            if ( (dice[0] == 2) && (dice[1] == 3) && (dice [2] == 4) && (dice[3] == 5) && (dice [4] == 6) ) {large = true;}
            if (large == true) {counter = 5;}
                
            // If there are is one duplicate, it moves it to the end of the array and ignores it.
            for (int i = 0; i < dice.Length - 1; i++)
            {
                int repeat = 0;
                if (dice[i] == dice [i+1])
                {
                    repeat = dice[i];

                    for (int j = i; j < dice.Length - 1; j++)
                    {
                        dice[j] = dice[j+1];
                    }
                
                    dice [4] = repeat;
                }
            }
            // The three possible cases for there to be a small sequence.
            if( dice[0] == 1 && dice[1] == 2 && dice[2] == 3 && dice[3] == 4) {small = true;}
            if( dice[0] == 2 && dice[1] == 3 && dice[2] == 4 && dice[3] == 5) {small = true;}
            if( dice[0] == 3 && dice[1] == 4 && dice[2] == 5 && dice[3] == 6) {small = true;}
            if (small == true) {counter = 4;}
            
            if (counter == length) {return true;}
            else {return false;}
        }

        public bool IsSetOf( int size ) // Used to see if there are 3 of a kind or 4 of a kind or Yahtzee. 
        { 
            int[ ] dice = new int [5] {dice1, dice2, dice3, dice4, dice5 };
            Array.Sort( dice );
            int counter = 1;
            // Counts how many times a face value is repeated and checks if its either 3, 4 or 5.
            for (int i = 0; i < dice.Length - 1; i++)
            {
                if (dice[i] == dice[i+1])
                {
                    counter++;
                }
            }
            if (counter == size){return true;}
            else{return false;}
        }

        public bool IsFullHouse( ) // Used to see if there is a full house (2 of one face value and three of another).
        { 
            int[ ] dice = new int [5] {dice1, dice2, dice3, dice4, dice5 };
            Array.Sort( dice );
            
            // The two possible cases for a full house to happen.
            if(dice[0] == dice[1] && dice[1] == dice[2] && dice[3] == dice[4] && dice[2] != dice [3]) {return true;}
            if(dice[0] == dice[1] && dice[2] == dice[3] && dice[3] == dice[4] && dice[1] != dice [2]) {return true;}
            else{return false;}
        }
        
        public override string ToString () // Displays the face values of the dice in an organized way.
        {
            int[ ] dice = new int [5] {dice1, dice2, dice3, dice4, dice5 };
            Array.Sort( dice );
            return string.Format("{0} {1} {2} {3} {4}", dice[0], dice[1], dice[2], dice[3], dice[4]);
        }
    }
    
}
