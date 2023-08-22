.text
.global main

main:
	jal checkForRead #jump to check
	
	add $2, $0, $1 #save character to $2
	
	andi $3, $2, 0x60 #check if lower case
	
	seqi $4, $3, 0x60 #if lowercase set equal $4 equal to one
	
	beqz $4, uppercase #if uppercase branch
	
	jal checkForPrint #go to print
	
	j main

#set uppercase to #
uppercase:
	addi $2, $0, '#' #make value #
	
	jal checkForPrint #go to print
	
	j main
	
#check if serial port one is ready to read
checkForRead:
	
	lw $11, 0x70003($0) #get the first serial port status
	
	andi $11, $11, 0x1 #check if the RDR bit is set
	
	beqz $11, checkForRead #if not, loop and try again
	
	#serial port now has a character
	lw $1, 0x70001($0) #get it into $1
	
	jr $ra #return
	
#check if serial port one is ready to print
checkForPrint:
	lw $11, 0x70003($0) #get the first serial port status
	
	andi $11, $11, 0x2 #check if the TDS bit is set
	
	beqz $11, checkForPrint #if not, loop and try again
	
	#serial port is now ready so
	sw $2, 0x70000($0) #transmit character
	
	jr $ra #return
