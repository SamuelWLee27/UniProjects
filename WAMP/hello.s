.text				#specifies that what follows are instructions
.global main			#specifies that the label "main" is globally accessible

main:				#entry point into the program
	sw $0, 0x73004($0)	#enable individual control of SSD segments
	
	addi $2, $0, 0		#initialise loop counter to zero
loop:
	sgei $8, $2, 12		#has the loop finished?
	bnez $8, main		#if so, go to "main"
		
	jal write		#write the pattern to the SSD
	jal delay		#delay so it can actually be seen
	
	addi $2, $2, 2		#increment loop counter
	j loop			#go around again

write:					
	lw $1, 0x73007($0)	#transfer the Upper Right SSD contents to the Upper Left SSD
	sw $1, 0x73006($0)	
	lw $1, 0x73008($0)	#transfer the Lower Left SSD contents to the Upper Right SSD
	sw $1, 0x73007($0)	
	lw $1, 0x73009($0)	#transfer the Lower right SSD contents to the Lower Left SSD
	sw $1, 0x73008($0)	
	lw $1, hello($2)	#load the new pattern to the Lower Right SSD
	sw $1, 0x73009($0)	

	jr $ra			#return

delay:
	addui $9, $0, 0xFFFF 	#a big number to count down from
	slli $9, $9, 2		#make it even bigger
delayLoop:
	subui $9, $9, 1		#around we go...
	bnez $9, delayLoop
	jr $ra			#return

.data				#specifies that what follows are data with initial values
hello:				#SSD patterns to encode "HELLO 102"
	.word 0x6D #S
	.word 0x77 #A
	.word 0x37 #M
	.word 0x07 
	.word 0x00 
	.word 0x00 
	.word 0x00 
	.word 0x00 
	.word 0x00            
	.word 0x00
	.word 0x00
	.word 0x00
