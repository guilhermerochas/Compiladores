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

MOV CX,20

PREENCHE:
 MOV DX,20
 LINHA:
  INT 10H 
  INC DX
  CMP DX,61
  JNZ LINHA
 INC CX
 CMP CX,101
 JNZ PREENCHE