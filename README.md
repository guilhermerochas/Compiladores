# Compiladores
Conteudo e Material relacionado a Aula de Compiladores

## Sobre

Na maior parte dos casos, um Compilador é um programa que processa e analisa um ou mais arquivos a fim de traduzi-los para a 
linguagem de maquina que é entendida pelo processador. Nesse processo, o compilador faz uma analise lexica, síntatica e semantica 
do conteudo do arquivo para garantir que o processo de tradução não apresente falhas. <br />
Em alguns casos o compilador apresenta tambem a otimização em tempo de otimização, para garantir que o tamanho do arquivo executavel
e o tempo de tradução. <br />
Por conta da necessidade de varios processos a separação por modulos (ou "separation of concerns"), gerando assim uma arquitetura melhor
do projedo do compilador. Os modulos mais importantes dentro desse processo são 4 no total:
 - Análise Léxica -> Verificando o "erro de ortografia", em outras palavras, validando os tokens verificando se, por exemplo, eles 
 pertencem a uma lista ou tabela para aquela linguagem.
 - Análise Sintatica -> Na qual, através de uma arvore binária, é analisado o posicionamento dos tokens que foram previamente validados.
 - Análise Semântica -> Apos a analise sintatica o compilador verifica processos como a validação do armazenamento de memoria ou
 tranformação de valores, geralmente sendo coisas que não fazem sentido.
 - Tradução -> Por final, o compilador faz a tradução do arquivo para a linguagem de maquina, interpretando e traduzindo os tokens para 
 um executavel que possa ser reconhecido e entendido pelo sistema operacional e arquitetura do processador presente.

Existe um processo a mais que seria fazer a otimização, mesmo que seja um processo importante principalmente para programas com várias
linhas, ela não é totalmente necessaria. O processo de compilação pode ser feito com VLIW (Very Long Instruction Word), onde uma instrução
é repartida em varias unidades basicas que podem ser processadas em paralelo, e EPIC (Explicitly Parallel Instruction Computing), que é um 
set de instruções que utilizam pontos flutuantes e utiliza carregamento especulativo, predicação e paralelismo explicito.
### Tokens
Dentro do texto apresentado foi falado sobre Tokens, um token é um segmento de simbolo ou texto que é manipulado por um analisador léxico,
fornecendo significado ao texto e representando um atributo, podendo representar um bloco de execução, um valor de soma ou a separação de 
unidades. 
