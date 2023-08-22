.text
.global main

#does cooperative multitasking
main:
	#save ra to stack
	subi $sp, $sp, 1
	sw $ra, 0($sp)
	
	j start #start program

#starts program
start:	
	jal serial_job #based on main from ex3_q2
	jal parallel_job #based on main from ex3_q3
	j start
	
#runs serial program
serial_job:
	#save return address to stack
	subi $sp, $sp, 1
	sw $ra, 0($sp)	
	
	jal checkForRead #jump to check
	
	add $2, $0, $1 #save character to $2
	
	andi $3, $2, 0x60 #check if lower case
	
	seqi $4, $3, 0x60 #if lowercase set equal $4 equal to one
	
	beqz $4, uppercase #if uppercase branch
	
	jal checkForPrint #go to print
	
	j return

#set uppercase to #
uppercase:
	addi $2, $0, '#' #make value #
	
	jal checkForPrint #go to print
	
	j return #return
	
#check if serial port one is ready to read
checkForRead:
	
	lw $11, 0x70003($0) #get the first serial port status
	
	andi $11, $11, 0x1 #check if the RDR bit is set
	
	beqz $11, return #if not, jump to return
	
	#serial port now has a character
	lw $1, 0x70001($0) #get it into $1
	
	jr $ra #return
	
#check if serial port one is ready to print
checkForPrint:
	lw $11, 0x70003($0) #get the first serial port status
	
	andi $11, $11, 0x2 #check if the TDS bit is set
	
	beqz $11, return #if not, jump to return
	
	#serial port is now ready so
	sw $2, 0x70000($0) #transmit character
	
	jr $ra #return

#return to main with $ra
return:
	#remove ra from stack
	lw $ra, 0($sp)
	addi $sp, $sp, 1

	jr $ra	#return
	
#runs parrallel program
parallel_job:
	#save return address to stack
	subi $sp, $sp, 1
	sw $ra, 0($sp)	
	
 	lw $11, 0x73001($0) #get value of push button
	
	beqz $11, return #check if button is pressed if not loop
	
	lw $6, 0x73000($0) #get switch value
	
	andi $2, $11, 4 #button two is pressed
	bnez $2, exit #branch to exit if button two is pressed

	andi $2, $11, 1 #button zero is pressed
	bnez $2, display #branch to display if pressed	

	andi $2, $11, 2 #button one is pressed
	bnez $2, buttonOne #branch to button one if pressed	

	j return
	
#if button two pressed flip bits in switch value 	
buttonOne:
	xori $6, $6, 0xffff #flip bits in switch value
	
	j display #go to display
	
#display modified switch values
display:
	
	add $7, $6, $0 #save value so can use it for leds
	
	andi $8, $6, 0xf #get first number
	srli $6, $6, 4 #shift for next number
	sw $8, 0x73009($0) #transmit hex number to ssd location
	
	andi $8, $6, 0xf #get first number
	srli $6, $6, 4 #shift for next number
	sw $8, 0x73008($0) #transmit hex number to ssd location
	
	andi $8, $6, 0xf #get first number
	srli $6, $6, 4 #shift for next number
	sw $8, 0x73007($0) #transmit hex number to ssd location
	
	andi $8, $6, 0xf #get first number
	sw $8, 0x73006($0) #transmit hex number to ssd location

	remi $7, $7, 4 #if check if switch value is divisable by 4
	
	beqz $7, turnOnLED #branch to turn on led if zero
	
	sw $0, 0x7300A($0) #turn off LEDS
	
	j return #finish parellel program

#turn on LEDs
turnOnLED:
	addi $7, $0, 0xffff #get value for turned on leds
	
	sw $7, 0x7300A($0) #turn on LEDs
	
	j return #finish parellel program
	
		
#exits program
exit:	
	#remove ra for parallel job
	addi $sp, $sp, 1	
	
	#remove ra from stack
	lw $ra, 0($sp)
	addi $sp, $sp, 1
	
	jr $ra #exit program
