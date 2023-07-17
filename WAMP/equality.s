.text				#specifies that what follows are instructions
.global main	    #specifies that the label "main" is globally accessible

main:				#entry point into the program
 # Get the address of the prompt 1 message 
  la $2, prompt_1
 # Display the message 
  jal putstr
 
 # Get the first number
 jal readnum
 # Store the first number into register 5
 addi $5, $1, 0
 
 # Get the address of the prompt 2 message 
 la $2, prompt_2 
 # Display the message 
  jal putstr
 
 # Get the second number
 jal readnum
 # Store the second number into register 6
 addi $6, $1, 0
 
 # Test if the two numbers are the same
 seq $3, $5 , $6
 # Branch to different label if the numbers are different
 beqz $3, different
 
same:
 # Get the address of the same message 
 la $2, output_same_msg
 # Display the message 
 jal putstr
 # Return to the monitor 
 j exit 
 
different:
 # Get the address of the same message 
 la $2, output_same_msg
 # Display the message 
 jal putstr
 # Return to the monitor 
 j exit 
 
.data 
 # This is the first prompt 
prompt_1: 
 .asciiz "Please enter the first number: " 
# This is the second prompt 
prompt_2: 
 .asciiz "Please enter the second number: " 
 # This is the output message if numbers are the same
output_same_msg: 
 .asciiz "The numbers are the same"
# This is the output message if numbers are different
output_notsame_msg: 
 .asciiz "The numbers are different"
 
 
 
 
 