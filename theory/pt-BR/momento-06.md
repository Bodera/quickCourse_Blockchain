## Módulo 2 (27/35)
Neste módulo, você conhecerá o funcionamento da Blockchain. Verá como os novos blocos são adicionados na cadeia e como os conflitos são resolvidos.

Esperamos que ao final deste módulo, você tenha entendido como a Blockchain funciona e por que o trabalho de mineração é fundamental para a garantir a segurança e a legitimidade de cada transação.

## Funcionamento da blockchain
Conforme vimos anteriormente, uma solicitação de transação é transmitida a todos os nós mineradores da rede para ser processada, validada e armazenada na rede.

A seguir uma lista para compreender melhor o funcionamento da Blockchain:
1. __Transações__ - Quando uma transação é solicitada, os mineradores a recebem e competem para resolver a equação.
2. __Mineradores__ - Cada minerador terá um grupo de transações pendentes a serem incluídas. Eles selecionam o bloco e tentam resolver o desafio.
3. __Bloco Candidato__ - Para resolver o desafio, os mineradores realizam uma prova de trabalho. O desafio consiste em incrementar o valor de *Nonce* do bloco, até que a hash do bloco apresente um determinado número de zeros iniciais. Conforme a Blockchain aumenta, o número de zeros aumenta, aumentando, assim, a dificuldade.
4. __Mineração__ - O minerador que consegue resolver o desafio transmite a solução (prova de trabalho) para a rede, a fim de que os demais mineradores a validem.
5. __Prova de trabalho concluída, Validação e Consenso__ - Os demais mineradores verificam a prova de trabalho, validando ou não o bloco.
6. __O processo se reinicia__ - As transações remanescentes entram em uma nova rodada de competição pelo novo bloco. Isso se faz dessa maneira porque a prova de trabalho foi criada para que o processo de mineração fique em torno de um bloco a cada 10 minutos.

Os mineradores vão buscar formar um novo bloco sempre que houver transações pendentes. Logo, a busca por um novo bloco se inicia quando transações são submetidas à rede.

O processo da transação, desde a sua solicitação até sua validação (identificação das partes envolvidas, análise das chaves públicas, dentre outros fatores), dura em torno de 10 minutos.

A transação requer que um bloco seja criado e, para isso, o minerador deverá resolver um enigma através da prova de trabalho (*proof of work*).

Através da prova de trabalho é que se garante a validade da transação.

Uma vez recebidas, tais transações são inseridas através da estrutura de dados da *merkle tree* e armazenadas no __bloco__ que será minerado para ser inserido na rede Blockchain. Tal bloco é denominado __bloco candidato__.

Adiante, vamos conhecer mais detalhes sobre o processo de mineração de dados, prova de trabalho e validação (consenso).

## Mineração de dados
O termo __minerar__ é uma referência ao processo de mineração de metais. Assim como encontrar uma metal precioso, como ouro, por exemplo, é uma tarefa trabalhosa, o processo de mineração envolve a resolução de cálculos complexos. Por isso, exige computadores com alto poder de processamento.

Para adquirirem capacidade suficiente para realizarem a mineração de blocos, as diversas placas de vídeo dessas máquinas (computadores) são otimizadas a fim de executar as mesmas tarefas repetidas vezes.

Além disso, somado ao *hardware*, é necessário ter um *software* (programa) específico para realizar a mineração.

Os equipamentos destinados às operações de mineração estão se tornando cada vez mais sofisticados, sendo utilizados desde CPUs convencionais a modernos data centers profissionais.

Dependendo da exigência da rede para a operação de mineração, uma máquina pode não ser suficiente para resolver o desafio e incluir um bloco. Dessa forma, pequenos mineradores podem se juntar para resolver o desafio coletivamente, e os ganhos são divididos entre todos de acordo com o processamento de cada máquina.

## Custo da mineração de dados
A atividade de mineração consome muita energia elétrica. Consequentemente, a rotina para incluir um novo bloco tem um custo elevado.

Ela é custosa pelos seguintes motivos:

* Alto custo das máquinas (hardware).  
* Necessidade de instalação de sistemas de refrigeração devido o calor gerado pelos processadores e a necessidade de temperatura controlada para otimizar o poder de processamento.  
* Necessidade de um cluster (grupo) de máquinas para aumentar poder de processamento e velocidade para obtenção da solução do bloco.  
* Necessidade de um espaço físico exclusivo para as máquinas devido o calor e o barulho gerado pelas várias ventoinhas das máquinas.  

> Como os blocos estão em uma cadeia, alterar um bloco requer alterar todos os demais. Como a mineração é custosa e leva tempo, provavelmente novos blocos serão adicionados antes que um nó mal intencionado consiga alterar toda a cadeia, minimizando, assim, a probabilidade de fraudes.

Mas, então, você pode estar se perguntando: E o que o nó minerador ganha?

Similar à vida real, eles ganham uma parte do tesouro que encontram. No mundo das moedas virtuais, eles ganham uma quantia de criptomoedas em recompensa ao trabalho de mineração. Na prática, é criada uma transação (denominada *coinbase*) que registra a recompensa a ser paga ao minerador quando ele conseguir incluir um bloco na cadeia.

Mas, de forma geral, incluir a transação em uma rede Blockchain tem um preço, denominado __custo da transação__, que constitui as taxas pagas pelos usuários que estão solicitando transações.

##### Controle de emissão de moedas

No Bitcoin, a cada 210.000 blocos, a recompensa em bitcoin é reduzida em 50%. Este processo é chamado *Halving* ou *Halvening* e ocorre em cerca de 4 anos. Por exemplo, em 2009, a cada novo bloco adicionado, o minerador recebia recompensa de 50 bitcoins. Em 2016, a recompensa já estava em 12,5 bitcoins a cada novo bloco. O limite de moedas na rede é de 21 milhões, de modo que após atingir esse numero, não haverá recompensa e os mineradores serão remunerados pelas taxas cobradas no processamento das transações.

<figure>
  <img src="/assets/inflacao-do-bitcoin.png" alt="a inflação do bitcoin ao passar dos anos">
</figure>

Acesso em 2018: [CoinTelegraph](https://br.cointelegraph.com/)

__Atenção!__  

As taxas e as recompensas em bitcoin (por exemplo) pagam o trabalho do minerador. Mas quando o limite da moeda for atingido, a remuneração se dará pela taxa da transação.

## Proof of work (PoW)
Proof of work ou prova de trabalho é a rotina computacional que está por trás da mineração. De uma maneira simplificada, a prova de trabalho mais conhecida para um novo minerador consiste em obter, do bloco candidato, uma hash que apresente um certo número de zeros iniciais.

Por exemplo, um novo bloco só pode ser aceito quando sua hash contiver 5 zeros. Este é o requisito mínimo para a hash ser válida. É a dificuldade alvo.

> 00000E6CC2661A6E263A391D88530B72C4491E43A0567BE6C5C5E5E0CF67A10D

O número de zeros, normalmente, está indicado no campo *difficult target* (ou dificuldade alvo) de um bloco.

Você pode estar se perguntando: como um minerador faz para que a *hash* do bloco candidato vá sendo modificada, de modo a cumprir o desafio? Bom, é aí que entra o campo *Nonce*.

Imagine, por exemplo, que desejamos minerar um bloco fictício cujo conteúdo se resume na frase: __“BlockChain - SENAI-SP”__. Suponha que a dificuldade (target value) seja __2__, ou seja, a hash deve apresentar __2 zeros iniciais__. Ao aplicarmos a Hash __SHA256__ à frase, obtemos o seguinte resultado: 

> 2b8b6ecf60104d0f58f9c2e6b38fffaff917880ea5fe9aa256139ee13ad2f391

Observe que essa hash não atende à solicitação (target value 2) porque não se inicia com dois zeros.

Dessa forma, vamos incrementar o Nonce para 1, de modo que a frase será __“BlockChain - SENAI-SP1”__. Vamos obter:

> 7e0330e92fab6f01d68db5fd4c6b795af062e5afa638d2548e7305b415b0a3ef.

Como você pode observar, ainda não temos os 2 zeros iniciais.

Em uma simulação computacional, para obter 2 zeros iniciais para a frase de nosso exemplo, o *nonce* foi de __1398__. Ou seja, o computador executou __1398 tentativas__ para obter uma hash válida para o desafio.

Se o desafio for de 3 zeros, o computador executa __1546 operações__. Para 4 zeros, são __42447 operações__. Para 5 zeros, são necessárias __752877 tentativas__. Ou seja, apenas 1 hash em mais de 750 mil tentativas conseguiu atender ao requisito de possuir 5 zeros iniciais.

Portanto, quanto maior o valor do desafio, mais tempo o minerador levará para conseguir obter uma __hash válida__.

__Atenção!__

As redes Blockchain aumentam o grau de dificuldade com o objetivo de aumentar a proteção. No caso de comercialização de criptomoedas, como a Bitcoin, por exemplo, aumentar o grau de dificuldade também serve para equilibrar a oferta de moedas.

## Funcionamento da PoW
Observe o processo para entender o passo a passo:

A imagem abaixo representa um bloco gênesis, que não possui registro de transações anteriores:

<figure>
  <img src="/assets/pow-e-bloco-genesis.jpg" alt="corpo do bloco gênesis">
</figure>

__Atenção!__

Na verdade, o timestamp não é registrado como “Qua, 8, Ago, 2018” e sim na marcação temporal UNIX, que é um calendário utilizado amplamente por computadores, no qual uma data é representada pela contagem de segundos decorridos desde a meia-noite de 01 de janeiro de 1970, UTC.

Por exemplo, “Qua 8 Ago, 2018, 14:40:00” é representada na marcação UNIX como: 1533750000

## Composição da HASH
Em síntese, cada *hash* é composta por: __número de bloco__, __hash anterior__, __marcação de tempo__, __dados__ e __nonce__, submetidos ao algoritmo de criptografia Hash __SHA256__, gerando, assim, a hash do bloco.

O grau de dificuldade é definido conforme a blockchain cresce. Por exemplo, na mineração do Bitcoin, a dificuldade é ajustada a cada 2016 blocos. Dessa forma, a dificuldade cresce proporcionalmente ao aumento a cadeia de blocos.

<figure>
  <img src="/assets/pow-nonce-concept.jpg" alt="o conceito prático do Nonce">
</figure>

[Nesse link](http://www.blockchain-basics.com/HashPuzzle.html) você encontra um simulador para compreender o conceito de NONCE. No campo Data, insira o texto: __BlockChain – SENAI-SP__. Em restrições, altere os Leading Zeros para 2 – dificuldade. Clique em Solve Hash Puzzle

Veja a quantidade de Nonce (tentativas) para criar a hash.

## Consenso
Como já estudamos, a Blockchain é um registro distribuído de informações, por isso não existe um controle ou autoridade central que garanta que as operações foram realizadas.

Em decorrência, a fim de garantir a veracidade e segurança de cada transação, o minerador que consegue resolver o desafio insere o bloco na sua cadeia local e o transmite para outros mineradores (que até então estavam competindo na resolução de seus desafios) para que eles validem e aceitem essa solução.

O bloco de informações somente será gravado na rede se houver a aprovação de 51% de mineradores. Este é o mecanismo de prova de trabalho mais comum utilizado em redes Blockchain, o chamado __consenso__.

Após esse bloco entrar na cadeia, o trabalho é reiniciado. Um novo conjunto de transações é montado e, consequentemente, inicia-se a mineração de um novo bloco candidato.

Há tecnologias de Blockchain que remuneram também alguns dos mineradores que se aproximaram da resolução do desafio para criar um novo bloco, a fim de compensar o esforço do minerador.

## Conflito
Você pode estar pensando:

O que impede que dois nós (mineradores) consigam resolver o desafio do bloco candidato no mesmo instante de tempo?

A resposta é: __nada impede.__

Nessa situação, dois blocos válidos são transmitidos à rede e vão atingir nós mais próximos do nó vencedor do desafio.

Imagine a situação em que dois nós A e B resolvem o desafio e divulgam seus blocos na rede.

<figure>
  <img src="/assets/conflito-parte1.png" alt="situação de conflito: introdução">
</figure>

Por questões de latência¹ e conectividade da rede², parte dos nós irá receber o bloco do nó A e a outra parte o bloco do nó B.

A Blockchain está estruturada para atuar nessas situações de conflito por uma regra muito simples: a cadeia mais longa vence, ou seja, a rede irá esperar um novo bloco.

<figure>
  <img src="/assets/conflito-parte2.png" alt="situação de conflito: resolução">
</figure>

Com o principio chamado “a cadeia mais longa vence”, quando há um conflito na rede (duas cadeias possíveis), a versão a ser considerada válida será aquela que tiver o maior numero de blocos.

¹ = o tempo que leva para os dados percorrer uma rede de ponto X a Y. [Fonte](https://brasilwork.com.br/duvidas/e-latencia-em-redes/)
² = capacidade de um computador ou programa de operar em ambiente de rede, conectando-se e trocando dados (em maior ou menor velocidade, eficiência etc.) com outros. [Fonte](https://dicionario.priberam.org/conectividade)