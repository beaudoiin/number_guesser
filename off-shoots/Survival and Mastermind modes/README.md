# Instructions for New Variants

1. Survival Mode (User vs. Clock)

    # Objective:
   
   Find the hidden number before your "Energy" (attempts) runs out.

    # Difficulty:
    
   High. You only have 7 attempts, which is the mathematical limit for finding a number between 1 and 100 using optimal logic.

    # Tip:
    
   Use the Binary Search strategy (always guess the middle of the remaining range) to ensure you win every time.

3. Mastermind Mode (Computer vs. User)

    # Objective:
   Test the computer's efficiency.

    # Instructions:
    
   Think of a secret number between 1 and 100.
    
   The computer will display its guess.

    # Provide feedback:
    
   Type 'H' if the computer's guess is higher than your number.
   
   Type 'L' if the computer's guess is lower than your number.
   
   Type 'C' once the computer gets it correct.

    # The Logic:
   The computer uses the midpoint formula guess = (low + high)/2 to eliminate half of the possibilities with every single question.
