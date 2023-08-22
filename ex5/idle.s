.text
.global idle

#idle task
idle:
	addi $1, $0, '-'
	sw $3, 0x73009($0)
	
	j idle
