.text
.global print

print:	#print number from parameter to serial port 1
	
	addi $6, $0, 10000 #num to divide by to get first ascii number

	lw $3, 0($sp) #get parameter
	
	addi $5, $0, 5 #start loop counter at 5
	
	#save ra to stack
	subi $sp, $sp, 1
	sw $ra, 0($sp)
	
	jal getASCII #jump to getASCII
	
	#load ra and romove from stack
	lw $ra, 0($sp)
	addi $sp, $sp, 1
	
	
	jr $ra #return
	
getASCII:	#loops through number given by parameter

	
	
	div $7, $3, $6 #divide by num in $6 for next number
	
	remi $4, $7, 10 #get modulus 10 of number to get first digit
	
	divi $6, $6, 10 #divide $6 by 10 to get next num in loop
	
	addi $4, $4, 0x30 #add hexidecimal 30 for ascii number
	
	#save ra and parameter to stack plus local varibles
	subi $sp, $sp, 5
	sw $4, 0($sp)
	sw $3, 1($sp)
	sw $6, 2($sp)
	sw $5, 3($sp)
	sw $ra, 4($sp)
	
	jal putc #print character to serial port 1
	
	#load ra, local varibles and parameter from stack and remove from stack
	lw $4, 0($sp)
	lw $3, 1($sp)
	lw $6, 2($sp)
	lw $5, 3($sp)
	lw $ra, 4($sp)
	addi $sp, $sp, 5
	
	subi $5, $5, 1 #minus one off loop counter
	
	bnez $5, getASCII #loop 5 times
	
	jr $ra #return
	
	


		

