## Registro da transação (8/12)
A rede distribuída da Blockchain compartilha o ledger, um tipo de livro-razão¹ público, onde são feitos os registros de transações. Esse livro também pode ser chamado de livro contábil imutável (do inglês *immutable digital ledger*).

¹Termo contábil que refere-se aos registros de todos lançamentos contábeis (crédito e débito) de uma organização.

Os usuários da rede são responsáveis por manter a base de dados, que tem como características principais a __segurança__, a __distribuição__, a __integridade__ dos dados e o __histórico das transações__ registradas no bloco, que permanecem inalteradas após inseridas no ledger (por isso a expressão “livro contábil imutável”).

Cada transação registrada na Blockchain envolve um ou mais endereços (no caso de criptomoeda, a origem e o destino) e o registro de um evento, que é digitalmente assinado² para garantir a autenticidade da transação.

²Tipo de assinatura eletrônica que usa operações matemáticas com base em algoritmos de criptografia para garantir segurança e autenticidade das documentações.

Cada transação, ou conjunto de transações, forma um bloco que é adicionado a outros blocos. Esses blocos formam uma cadeia (por isso o nome Blockchain - chain, em inglês, significa cadeia). O termo cadeia refere-se ao encadeamento existente na Blockchain, uma vez que um bloco aponta para o bloco anterior.

Observe a imagem para entender melhor o conceito de registro de transação, bloco e cadeia.
<figure>
  <img src="/assets/bloco-cadeia-registro.jpg" alt="componentes do registro de uma transação blockchain">	
  <figcaption>Componentes do livro-razão.</figcaption>
</figure>

## Fluxo da informação na Blockchain
1. __Solicitação__ - Você solicita a compra daquele imóvel (ou uma transação com criptomoedas, contratos, bens etc.)
2. __Transmissão peer-to-peer__ - A solicitação é transmitida para nós chamados mineradores, os quais irão buscar validá-la e incluí-la na Blockchain.
3. __Mineração de Dados__ -  
  3.1. Os nós “mineram os dados” da transação para verificar se as suas informações, do imóvel e do vendedor estão corretas, a fim de validar a negociação.  
  3.2. Como essas informações são protegidas por chaves criptográficas, os mineradores competem para decodificá-las e disponibilizá-las na rede primeiro.  
  3.3. Para isso, é necessário investir em computadores com alto poder de processamento de cálculos, com rapidez e eficiência.  
  3.4. O trabalho da mineração é remunerado com criptomoedas.  
4. __Solução__ -   
  4.1. O primeiro computador que resolver o cálculo, disponibiliza o bloco de informações com a solução na rede, para os demais nós checarem se a solução é válida.  
  4.2. Alguns nós da rede possuem o histórico ou cópia completa de todas as transações da Blockchain. Eles são chamados fullnodes (ou nós completos).  
  4.3. Os demais nós se conectam aos fullnodes para obter as informações necessárias para que as transações sejam processadas.  
5. __Validação__ -  
  5.1. Após validado pela maioria da rede, o novo bloco de dados é adicionado à cadeia de blocos, de modo permanente e inalterável.  
  5.2. Cada novo bloco contém 2 códigos chamados hash: um que traz informações referentes ao bloco anterior e outro que representa a sua identificação, que será utilizada pelo próximo bloco.  
  5.3. Os hashes trazem segurança às informações, pois sempre que uma solução é encontrada e validada, confirma, ao mesmo tempo, o novo bloco e todos os anteriores. Quanto mais antigo for o bloco, mais seguro ele será, pois teve mais validações.  
  5.4. É muito difícil fraudar a rede Blockchain e adulterar um bloco de informações. Para isso, seria necessário que um cracker hacker adulterasse as cópias de todos os blocos em toda a rede, para que o bloco falso fosse validado pela maioria dos nós.    
6. __Conclusão__ - A transação é concluída. O imóvel passa a ser seu. Este bloco de informações fica registrado e armazenado na rede Blockchain, funcionando como um “livro-razão digital”, tornando-se um histórico para a próxima negociação.

Este bloco de informações fica registrado e armazenado na rede Blockchain, funcionando como um “livro-razão digital”, tornando-se um histórico para a próxima negociação.

## Funcionamento da blockchain
Portanto, pode-se definir Blockchain como um registro de informações em um livro-razão público composto por uma rede P2P (peer-to-peer ou ponto a ponto) e um banco de dados distribuído e descentralizado.

Em uma rede P2P, todos compartilham dados e podem assumir funções diferentes. Alguns computadores ou usuários são chamados de nó. Toda informação lançada em um sistema que utiliza a tecnologia Blockchain é difundida entre todos os nós da rede de forma criptografada.

O banco de dados é constituído por blocos que, juntos, formam uma cadeia. Cada bloco possui informações ou transações e cada modificação ou nova informação inserida é registrada em um dos blocos da cadeia. Esse histórico de informação cria o livro-razão.

Os blocos são formados por hashs que são ligados ao bloco anterior, funcionando como links com os blocos anteriores até o bloco inicial, também conhecido como bloco gênesis (o bloco que deu origem à cadeia). A hash é formada como uma chave criptografada, o que confere ao sistema segurança quanto à informação registrada.

<figure>
  <img src="/assets/blockchain-nodes.png" alt="organização de um bloco">	
  <figcaption>Como um bloco é organazidado.</figcaption>
</figure>

## Componentes da blockchain
Os itens que compõem e permitem o funcionamento da Blockchain são a __transação__, o __bloco__, o __hash__ e o livro-razão __ledger__. Todos eles estão relacionados. 

A *transação* é um registro digital. Tomando como base as transações com as criptomoedas, podemos dizer que uma transação é a solicitação de transferência de moedas entre partes.

Um *bloco* pode ser entendido como um conjunto de transações ou informações validadas.

A *função de hash* (em português, funções de dispersão) tem como principal objetivo compilar dados de qualquer tamanho para um tamanho fixo.

O conjunto de transações dos blocos é registrado no livro-razão, o *ledger*, como um livro contábil.

Vamos entender mais a fundo, o que é uma transação na Blockchain. Transação é um registro digital, normalmente composta pelos seguintes dados:

1. ID da Transação (__hash__) é...  
Identificador único da transação. É obtido por meio de uma função da hash que recebe como entrada os demais dados da transação e gera, dela, um identificador único (ID).
2. Entrada (__input__) é...  
Endereço de quem está enviando recursos. Normalmente, é uma referência a algum output de transação anterior, na qual o usuário recebeu uma certa quantia. É possível que uma transação referencie mais do que uma entrada.
3. Saídas (__outputs__) são...  
Endereço do(s) destinatário(s) que irão receber o objeto digital.
4. Quantidade (__amount__) é...  
A quantia de objeto digital a ser transferido
5. Marcação do Tempo (__timestamp__) é...  
Registro de data e horário da transação.

> Dica: acesse https://www.Blockchain.com

<figure>
  <img src="/assets/blockchain-transaction.jpg" alt="exemplo de uma operação na rede blockchain">	
  <figcaption>Evidência de transação na blockchain.</figcaption>
</figure>
