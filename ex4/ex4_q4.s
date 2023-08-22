.text
.global main

main:
	#save $ra to stack
	subi $sp, $sp, 1
	lw $ra, 0($sp)
	# Acknowledge any old interrupts
	sw $0, 0x72003($0)
	# Copy the current value of $cctrl into $2
	movsg $2, $cctrl
	# Mask (disable) all interrupts
	andi $2, $2, 0x000f
	# Enable IRQ1 and IRQ3 and IE (global interrupt enable)
	ori $2, $2, 0xcf
	# Copy the new CPU control value back to $cctrl
	movgs $cctrl, $2
	
	#enable button interrupts
	addi $2, $0, 3
	sw $2, 0x73004($0)
	
	# Put our count value into the timer load reg
	addi $11, $0, 24
	sw $11, 0x72001($0)
	
	#set auto-restart mode
	addi $11, $0, 0x2
	sw $11, 0x72000($0)	
	
	# Copy the old handler’s address to $2
	movsg $2, $evec
	# Save it to memory
	sw $2, old_vector($0)
	# Get the address of our handler
	la $2, handler
	# And copy it into the $evec register
	movgs $evec, $2
loop:
	#get return memory value
	lw $2, return($0)
	#if return is on go to exit
	bnez $2, exit
	
	jal checkPrint #jump to check if need to print to serial port
	
	# Get counter value
	lw $2, counter($0)
	
	divi $6, $2, 100 #make it one second
	remi $2, $2, 10000
	
	#save to right most ssd
	remi $7, $6, 10
	sw $7, 0x73009($0)
	
	#save for print
	addi $5, $0, 6 #add for postion in string
	remi $3, $2, 10
	addi $3, $3, '0'
	sw $3, string($5)
	
	#save to next ssd to left and print
	divi $6, $6, 10
	remi $7, $6, 10
	sw $7, 0x73008($0)
	
	#save for print
	addi $5, $0, 5 #add for postion in string
	divi $4, $2, 10
	remi $3, $4, 10
	addi $3, $3, '0'
	sw $3, string($5)

	#save to next ssd to left and print
	divi $6, $6, 10
	remi $7, $6, 10
	sw $7, 0x73007($0)
	
	#save for print
	addi $5, $0, 3 #add for postion in string
	divi $4, $4, 10
	remi $3, $4, 10
	addi $3, $3, '0'
	sw $3, string($5)
	
	#save to next ssd to left and print
	divi $6, $6, 10
	remi $7, $6, 10
	sw $7, 0x73006($0)
	
	#save for print
	addi $5, $0, 2 #add for postion in string
	divi $4, $4, 10
	remi $3, $4, 10
	addi $3, $3, '0'
	sw $3, string($5)	
	
	j loop
	
checkPrint:
	addi $3, $0, 7
	add $4, $0, $0
	#check if lap should be printed
	lw $2, print($0)
	bnez $2, printString
	
	#return
	j returnLoop

printString:
	
	lw $11, 0x71003($0) #get the second serial port status
	andi $11, $11, 0x2 #check if the TDS bit is set
	beqz $11, printString #if not, loop and try again
	
	#serial port is now ready so
	lw $2, string($4)
	sw $2, 0x71000($0) #transmit character
	
	#sub one from loop counter
	subi $3, $3, 1
	addi $4, $4, 1
	#if loop counter is not zero loop
	bnez $3, printString
	
	#set print to 0 then return
	sw $0, print($0)
	j returnLoop
	
returnLoop:
	#return to loop
	jr $ra

handler:
	# Get the value of the exception status register
	movsg $13, $estat
	# Check if interrupt was the timer
	andi $13, $13, 0xffb0
	# If it a timer interrupt
	beqz $13, handle_interrupt
	# Check if not parallel interrupt
	andi $13, $13, 0xff70
	# If its a parallel interrupt go to handle_interrupt_parallel
	beqz $13, handle_interrupt_parallel
	# Otherwise, jump to the system handler
	lw $13, old_vector($0)
	jr $13

handle_interrupt:
	# Get counter variable
	lw $13, counter($0)
	# Add one to counter
	addi $13, $13, 1
	# Save new counter value
	sw $13, counter($0)
	# Acknowledge the interrupt
	sw $0, 0x72003($0)
	# Return from the interupt (rfe)
	rfe

handle_interrupt_parallel:
	#get button pressed value
	lw $13, 0x73001($0)
	#check if button zero
	andi $13, $13, 1
	#handle button zero if pressed
	bnez $13, handle_button_zero
	
	#get button pressed value
	lw $13, 0x73001($0)
	#check if button one
	andi $13, $13, 2
	#handle button one if pressed
	bnez $13, handle_button_one
	
	#get button pressed value
	lw $13, 0x73001($0)
	#check if button two
	andi $13, $13, 4
	#handle button two if pressed
	bnez $13, handle_button_two
	
	# Acknowledge the interrupt
	sw $0, 0x73005($0)
 	# Return from the interupt (rfe)
	rfe

handle_button_zero:
	#get if timer is inabled or not
	lw $13, 0x72000($0)
	
	#start stop/resume stop watch
	xori $13, $13, 1
	sw $13, 0x72000($0)

	# Acknowledge the interrupt
	sw $0, 0x73005($0)
 	# Return from the interupt (rfe)
	rfe

handle_button_one:
	#get if timer control value
	lw $13, 0x72000($0)
	#check if on
	andi $13, $13, 1
	#if on got to timer on handler
	bnez $13, handle_button_one_timer_on
	
	#reset timer
	sw $0, counter($0)
	
	# Acknowledge the interrupt
	sw $0, 0x73005($0)
 	# Return from the interupt (rfe)
	rfe

handle_button_one_timer_on:
	#save value for print
	addi $13, $0, 1
	sw $13, print($0)
	
	# Acknowledge the interrupt
	sw $0, 0x73005($0)
 	# Return from the interupt (rfe)
	rfe

handle_button_two:
	#get one
	addi $13, $0, 1
	#set return to 1
	sw $13, return($0)
	# Acknowledge the interrupt
	sw $0, 0x73005($0)
 	# Return from the interupt (rfe)
	rfe
	
exit:
	#remove $ra from stack
	sw $ra, 0($sp)
	addi $sp, $sp, 1
	
	#exit program
	jr $ra
.data
#adress for counter
counter:
	.word 0
#check if time to print
print:
	.word 0
#string for print
string:
	.ascii "\r"
	.ascii "\n"
	.word 0
	.word 0
	.ascii "."
	.word 0
	.word 0
#return check
return:
	.word 0
	
.bss
#address for old cpu handler
old_vector:
	.word
	

