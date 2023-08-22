.text
.global main

main:
	# Copy the current value of $cctrl into $2
	movsg $2, $cctrl
	# Mask (disable) all interrupts
	andi $2, $2, 0x000f
	# Enable IRQ1 and IRQ3 and IE (global interrupt enable)
	ori $2, $2, 0xa2
	# Copy the new CPU control value back to $cctrl
	movgs $cctrl, $2
	
	#enable button interrupts
	addi $2, $0, 3
	sw $2, 0x73004($0)	

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
	remi $2, $2, 100
	#Put counter into ssd
	remi $3, $2, 10
	divi $2, $2, 10
	sw $3, 0x73009($0)
	sw $2, 0x73008($0)
	
	j loop

handler:
	# Get the value of the exception status register
	movsg $13, $estat
	# Check if not user interrupt
	andi $13, $13, 0xffd0
	# If its a user interrupt go to handle_interrupt
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
	sw $0, 0x7f000($0)
	sw $0, 0x73005($0)
	# Return from the interupt (rfe)
	rfe
handle_interrupt_parallel:
	#check if button was pressed
	lw $13, 0x73001($0)
	#if pressed go save to handle_interrupt
	bnez $13, handle_interrupt
	# Acknowledge the interrupt
	sw $0, 0x73005($0)
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
	

