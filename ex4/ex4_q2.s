.text
.global main

main:
	# Acknowledge any old interrupts
	sw $0, 0x72003($0)
	# Copy the current value of $cctrl into $2
	movsg $2, $cctrl
	# Mask (disable) all interrupts
	andi $2, $2, 0x000f
	# Enable timer and IE (global interrupt enable)
	ori $2, $2, 0x4f
	# Copy the new CPU control value back to $cctrl
	movgs $cctrl, $2
	
	# Put our count value into the timer load reg
	addi $11, $0, 2400
	sw $11, 0x72001($0)
	# Enable the timer and autorestart
	addi $11, $0, 0x3
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
	# Get counter value
	lw $2, counter($0)
	
	#save to right most ssd
	remi $3, $2, 10
	sw $3, 0x73009($0)
	
	#save to next ssd to left
	divi $4, $2, 10
	remi $3, $4, 10
	sw $3, 0x73008($0)
	
	#save to next ssd to left
	divi $4, $4, 10
	remi $3, $4, 10
	sw $3, 0x73007($0)
	
	#save to next ssd to left
	divi $4, $4, 10
	remi $3, $4, 10
	sw $3, 0x73006($0)
	
	
	j loop

handler:
	# Get the value of the exception status register
	movsg $13, $estat
	# Check if interrupt we don’t handle ourselves
	andi $13, $13, 0xffb0
	# If it one of ours, go to our handler
	beqz $13, handle_interrupt
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

.data
#adress for counter
counter:
	.word 0
	
.bss
#address for old cpu handler
old_vector:
	.word
	

