MOV AH,02H
MOV BH,0 
MOV DL,10
MOV DH,10
INT 10H 

VOLTA:
 MOV AH,00H
 INT 16H
     
 MOV AH,0AH    
 MOV CX,1
  
  CMP AL,8
  JZ DELETA
 INT 10H
 
 MOV AH,02H
 INC DL
 INT 10H

 CMP AL,13
JNZ VOLTA

DELETA:    
 CMP DL,10
 JZ VOLTA

 MOV AH,02H
 DEC DL
 INT 10H
 
 MOV AH,0AH
 MOV AL,0
 MOV CX,1
 INT 10H
JMP VOLTA  

ret