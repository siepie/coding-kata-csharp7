﻿
# String Calculator Kata for learning new features C# 7
* Modified version of the well known String Calculator Kata (http://osherove.com/tdd-kata-1/), 
   purpose is to use out variables, local functions and tuples 

## Before you start:
* Try not to read ahead.
* Do one task at a time. The trick is to learn to work incrementally.
* Make sure you only test for correct inputs. there is no need to test for invalid inputs for this kata 

## The assignment

1. Create a simple String calculator with a method Calculate(string numbers)
 
   a. The method can take 0, 1 or 2 numbers, and will return their sum and difference 
       (for an empty string it will return 0) for example “” or “1” or “1,2”    
   
   b. Start with the simplest test case of an empty string and move to 1 and two numbers    
   
   c. Remember to solve things as simply as possible so that you force yourself to write tests you did not think about    
   
   d. Remember to refactor after each passing test
 
2. Allow the method to handle an unknown amount of numbers
 
3. Allow the method to handle new lines between numbers (instead of commas).
    
    a. the following input is ok:  “1\n2,3”  (will return 6 and 0)
    
    b. the following input is handled as 1 number:  “1,\n” (will return 1 and 1)
 
4. Support different delimiters
    
    a. to change a delimiter, the beginning of the string will contain a separate line that looks like this:   
        “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return 3 and -1 where the default delimiter is ‘;’ .
        
    b. the first line is optional. all existing scenarios should still be supported
 
5. Calling Calculate with a negative number will throw an exception “negatives not allowed” - 
     and the negative that was passed.if there are multiple negatives, show all of them in the exception message
 
  
 ## -------------------------------------------------------------------------------------------
 ## If you still have time, continue...
 ## -------------------------------------------------------------------------------------------
 
 6.  Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2 and 2 - 1001 = 1
 
 7.  Delimiters can be of any length with following format: “//[delimiter]\n” for example: “//[***]\n1***2***3” should return 6 and 0
 
 8.  Allow multiple delimiters like this:  “//[delim1][delim2]\n” for example “//[*][%]\n1*2%3” should return 6 and 0.
 
 9.  make sure you can also handle multiple delimiters with length longer than one char
 

