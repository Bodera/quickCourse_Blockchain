## Resolução de conflito (36/39)
Observe a imagem abaixo. Em algum momento, a Blockchain apresentou dois possíveis caminhos: - o azul ou o vermelho (observe que ambos os caminhos têm os blocos 50, 51 e 52). Quando o caminho azul ganhou o bloco 53, ele ficou maior que o vermelho, de modo que passou a ser a cadeia mais longa e, então, o consenso foi estabelecido na rede, passando a ser essa a cadeia válida.

Eventuais transações que estavam no caminho que deixou de ser válido voltam para o estado pendente e passarão por um novo processo de mineração.

<figure>
  <img src="/assets/cadeia-mais-longa.png" alt="conceito de caminho mais longo">	
</figure>

Observe como esse mecanismo é simples e robusto. Em uma eventual alteração de um bloco da cadeia, a prova de trabalho é um elemento que irá dificultar a mudança de todos os nós subsequentes. Mas a regra da __cadeia mais longa vence__ também é um excelente mecanismo de segurança. Uma vez que novos nós estão sendo criados, a cadeia ficará maior e a versão adulterada da cadeia será descartada pelos nós da rede.

Este processo de bifurcação também é considerado, na Blockchain, um *“fork”* (do inglês, garfo). Neste curso, não vamos nos aprofundar neste conceito.

## Quiz time!
Conforme você viu, para que um novo bloco de informações seja adicionado na Blockchain, uma solicitação de transação é transmitida a todos os nós mineradores da rede para ser processada, validada e armazenada na rede. O processamento dessas informações, desde a sua solicitação até sua validação, envolve, entre outras coisas, a identificação das partes envolvidas e a análise das chaves públicas.

__Fase 1__
1. Tarefa de custo alto, que faz referência ao processo de extração de metais. Envolve a resolução de cálculos complexos e, por isso, exige computadores com alto poder de processamento. 
__Mineração__
2. Rotina computacional que está por trás da mineração. Consiste em obter, do bloco candidato, uma hash que apresente um certo número de zeros iniciais. 
__Prova de trabalho, pow.__
3. Quantidade de zeros iniciais que uma hash deve possuir para ser válida. Com o passar do tempo, encontrar sua solução torna-se cada vez mais difícil. As redes Blockchain utilizam esse método como forma de aumentar a proteção.
__Valor Nonce, o grau de dificuldade__
4. A transação somente é finalizada e o bloco de informações incluído na rede após aprovação de 51% dos mineradores.
__Consenso__


__Fase 2__
O custo da mineração de dados é elevado e envolve:

* Máquinas com placas otimizadas para processarem rapidamente as mesmas tarefas repetidas vezes, para obtenção da solução do bloco;
* Espaço físico exclusivo para alocá-las e instalação de sistemas de refrigeração, devido o calor gerado pelos processadores;
* Softwares (programa) específicos para realizar a mineração.

Manter essa estrutura demanda um alto consumo de energia elétrica. Consequentemente, essa rotina visa, sobretudo, garantir a segurança da rede, uma vez que alterar um bloco requer alterar todos os demais, pois todos estão em cadeia. Assim, antes que um nó mal intencionado consiga alterar toda a cadeia, provavelmente novos blocos serão adicionados, minimizando a probabilidade de fraudes.
__Verdadeiro__

## Blockchain na prática
Em 2016, a IBM e a Maersk anunciaram a intenção de construir uma plataforma de logística baseada na tecnologia Blockchain para otimizar o comércio global, reduzir o custo das exportações em aproximadamente 10% (dez por cento) e aumentar o volume de negociação em até 15% (quinze por cento). Com a eliminação de documentos físicos, além de garantir acesso à informação em tempo real, a plataforma digital TradeLens imprime transparência e eficiência aos processos.

Com o objetivo de conectar, em uma rede global, toda a cadeia de suprimentos, além das empresas diretamente envolvidas no processo de compra e venda, atores como portos e terminais, alfândegas e transportadoras, desde a sua criação a plataforma tem hospedado mais de 163 milhões de negociações.

O acesso à informação em tempo real beneficia todos os atores do processo. Acompanhe:

1. __Exportador__ -Acompanhar seus produtos desde o momento em que saem de seus domínios até a entrega ao destinatário. Reduzir ou eliminar documentos físicos e intermediários. Proporcionar transparência e segurança às suas negociações. Eliminar risco de fraudes.
2. __Transportador terrestre__ - Obter informação sobre localização da carga, o que permite, entre outras coisas, o planejamento, a fim de evitar filas para carregar ou descarregar.
3. __Terminais e portos__ - Planejar e otimizar o uso de recursos humanos, máquinas, equipamentos, espaço físico para armazenamento, bem como estimar receitas e despesas. Além de facilitar a comunicação e a colaboração com as autoridades portuárias.
4. __Transportador aéreo ou marítimo__ - Ter acesso à informação sobre a localização da carga, facilidade de comunicação com terminais e portos acerca de autorizações e/ou restrições.
5. __Alfândegas (autoridades portuárias)__ - Planejar a fiscalização, mitigar riscos e ameaças, evitar negócios ilícitos, reduzir documentação impressa. Melhorar a comunicação com terminais e portos.
6. __Importador__ - Acompanhar seu pedido desde o momento em que sai do país de origem. Reduzir ou eliminar documentos físicos e intermediários. Garantir transparência e segurança às suas negociações. Eliminar risco de fraudes.

## Resumo
Neste módulo, você conheceu mais detalhes sobre como novos blocos são validados e adicionados na Blockchain.

Você viu que o trabalho de mineração é essencial para esse processo, pois o minerador que primeiro resolver o desafio (encontrar uma hash válida, composta por número de bloco, hash anterior, marcação de tempo, dados e nonce que transcreve os dados da transação), transmite a prova de seu trabalho (proof of work) para os demais nós mineradores validarem a solução encontrada. Somente após o consenso de 51% da rede, a transação é validada e o bloco incluído na cadeia.

Além disso, você viu que o trabalho de mineração requer alto investimento em energia e equipamentos com alto poder de processamento.

Todos esses elementos (desafio, prova de trabalho, consenso, alto custo computacional) visam inviabilizar a alteração indevida de blocos e garantir mais segurança nas transações.

No próximo módulo, você vai conhecer como a tecnologia Blockchain pode ser aplicada em outras situações.

Avance para continuar seus estudos.