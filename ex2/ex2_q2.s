.text
.global main

main:

	#read switches and put lowest 16 bits  into $1
	jal readswitches
	
	#get 8 right most bits into $3
	andi $3, $1, 0x00ff
	
	#get 8 left most bits into $4
	andi $4, $1, 0xff00
	srli $4, $4, 8
	
	#store parameters for count in stack and ra
	subi $sp, $sp, 2
	sw $4, 0($sp)
	sw $3, 1($sp)
	
	#jump to count subroutine
	jal count
	
	#remove parameters from stack
	addi $sp, $sp, 2
	syscall #stop
