.text
.global main

main:

	addi $2, $0, 'A' #get value for A in ascii
	
	addi $3, $0, 'a' #get value for a in ascii
	
	addi $4, $0, 26 #numbers in alphabet for loop

#loop for printing the alphabet
loop:
	#put local varibles and parameters on the stack
	subi $sp, $sp, 3
	sw $2, 0($sp)
	sw $3, 1($sp)
	sw $4, 2($sp)

	jal printToSerial #jump and link to serial port label
	
	lw $2, 0($sp)
	lw $3, 1($sp)
	lw $4, 2($sp)
	addi $sp, $sp, 3
	
	addi $2, $2, 1 #next letter in the alphabet
	
	addi $3, $3, 1 #next letter in the alphabet
	
	subi $4, $4, 1 #finished one loop
	
	bnez $4, loop #loop back to top if needed
	
	j exit

#print to serial port	
printToSerial: 
	lw $2, 0($sp) #get first letter to print
	lw $3, 1($sp) #get second letter to print
	
	#save first letter and ra on stack
	subi $sp, $sp, 3
	sw $2, 0($sp)
	sw $3, 1($sp)
	sw $ra, 2($sp)	
	
	jal check #check so can print first letter
	
	#save second letter to first spot instead of first letter on stack
	lw $3, 1($sp)
	sw $3, 0($sp)
	
	jal check #check for second letter
	
	#remove $ra off the stack
	lw $ra, 2($sp)
	addi $sp, $sp, 3
	
	jr $ra #return to the loop

#check if serial prot is ready to print then print 
check:
	lw $2, 0($sp) #get letter

	lw $11, 0x71003($0) #get status of serial port 2
	
	andi $11, $11, 0x2 #check if the TDS bit is set
	
	beqz $11, check #if not loop
	
	sw $2, 0x71000($0) #print character
	
	jr $ra #return
	
	

exit:
