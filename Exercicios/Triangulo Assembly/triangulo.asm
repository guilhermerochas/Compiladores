MOV AH,00H
MOV AL,13H
INT 10H

MOV AH,0CH
MOV AL,15
MOV BH,00
MOV CX,20
MOV DX,20

COLUNA:
 MOV DX,20
 INT 10H 
 MOV DX,60
 INT 10H
 INC CX
 CMP CX,101
 JNZ COLUNA
 
MOV DX,20

LINHA:
 MOV CX,20
 INT 10H 
 MOV CX,100
 INT 10H
 INC DX
 CMP DX,61
 JNZ LINHA