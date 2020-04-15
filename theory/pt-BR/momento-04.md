## Formação do bloco (17/23)
Na Blockchain, a *hash* de cada bloco aponta para o bloco anterior. Todas as transações que um bloco possui são identificadas criptograficamente por uma *hash*. No cabeçalho do bloco, as transações são identificadas por uma *hash* única denominada *Merkle Root Hash*, que representa a raiz de uma árvore de transações conhecida como *Markle Tree*.

O bloco inicial, conhecido como bloco gênesis, não possui registro de transações de outros blocos; por isso, o campo de hash do bloco anterior normalmente apresenta valor 0 nesse campo.

Outros campos são a marcação de tempo, mais conhecida como *timestamp*, que proporciona a ordenação temporal contínua dos blocos e eventos na cadeia, e um valor denominado *nonce*.

<figure>
  <img src="/assets/o-bloco-genesis.png" alt="a interação de blocos da cadeia com o bloco gênesis">
</figure>

Imagine, por exemplo, que para alterar uma informação no Bloco 1, teríamos que alterar o Bloco 2, que teria sua Hash alterada e impactaria o Bloco 3, e assim por diante. Ou seja, algo impraticável.

Você pode estar pensando: mas, com o poder computacional existente, essa tarefa não seria fácil?

Alterar valores e recalcular hashes é fácil computacionalmente; por isso, para evitar fraudes, a Blockchain exige um trabalho adicional para inclusão de novos blocos, denominado __PoW__ - Proof of Work (em português, Prova de Trabalho).

Você conhecerá mais sobre este conceito, as funções do *nonce* e do *difficulty target* mais adiante, quando abordaremos o trabalho dos mineradores para incluir um novo bloco na Blockchain.

<figure>
  <img src="/assets/impacto-alteracoes-no-hash.png" alt="o impacto de alterar informações no meio de uma cadeia da blockchain.">
</figure>

> Existem outras formas de prova de trabalho (PoW), tal como a Proof of Stake, mas, neste curso, você vai conhecer a clássica PoW.

## O Hash
As funções de *hash* (em português, funções de dispersão) são essenciais na Blockchain, pois têm como principal objetivo compilar dados de qualquer tamanho para um tamanho fixo. Os valores retornados por uma função de hash são chamados de valores ou códigos *hash* (em inglês, *digest*). Qualquer modificação dos dados submetidos a uma função de *hash* irá modificar a *hash* gerada.

Dessa forma, na tecnologia da Blockchain, os dados de um bloco são vinculados a uma função de *hash*, gerando a *hash* do bloco, que será utilizada pelo bloco seguinte, formando o encadeamento dos blocos. Portanto, qualquer modificação no bloco irá modificar a *hash* que o representa e resultará numa bifurcação do encadeamento dos blocos, evidenciando uma alteração na cadeia.

Observe a representação do trabalho das funções:

| Entrada Mensagem               | Função Hash Criptografada | Saída Mensagem                                                   |
|--------------------------------|---------------------------|------------------------------------------------------------------|
| O cachorro                     | KECCAK-256                | 50cc4c46ccb7e3b5cbb72c7eed7ee304a5f6bcf3a885f1155ea254b6135e3350 |
| O cachorro e o gato            | KECCAK-256                | 3c17e97f85b1982e9d025bdf0291cb59df0ffd6656777e464729fea4ce61c291 |
| O cachorro corre atrás do gato | KECCAK-256                | 124a954944233e614e03753ffbfbcb1f5aa93c3c2d18de16a0153076d7033b28 |

> Dica: Acesse https://emn178.github.io/online-tools/ para testar como funciona essa transformação de mensagens em *hashes*

Os algoritmos de *hash* são conhecidos por serem unidirecionais (em inglês, *one-way*). Ou seja, não é possível descobrir os dados originais a partir de uma *hash*. Por isso, as hashes na Blockchain garantem a confidencialidade dos dados originais, além do fato de o cálculo da *hash* de um bloco ser uma tarefa computacionalmente barata e rápida.

Um algoritmo de *hash* muito utilizado nas implementações de Blockchains é o SHA-256 (*Secure Hash Algorithm*), que produz uma saída de 256 bits para qualquer dado de origem.

A saída desse algoritmo é um conjunto de 32 caracteres, isto é: Cada caractere possui o tamanho de 8 bits, logo, 8 bits x 32 caracteres = 256 bits

Você pode estar pensando: O que significa a saída do algoritmo de 256 bits?

Isto significa que há 2²⁵⁶ possíveis valores de saída, o que equivale a:

115.792.089.237.316.195.423.570.985.008.687.907.853.269.984.665.640.564.039.457.584.007.913.129.639.936 
__possíveis valores__

Portanto, é muito difícil dois dados de entrada diferentes apresentarem a mesma *hash*.

Na verdade, mesmo que haja a possibilidade, os algoritmos de *hash* modernos possuem formas de tratar tais questões e evitar essa coincidência.

## Livro-razão (ledger)
O __conjunto de transações__ dos blocos é __registrado__ no __livro-razão__ (*ledger*), como um livro contábil.

Essa, aliás, é uma das grandes inovações da tecnologia Blockchain, muito utilizada nas criptomoedas. O controle das transações não é centralizado, ou seja, não há uma instituição bancária ou qualquer outra instituição que organize o registro de todas as informações de transações.

O uso de um livro-razão distribuído se destaca em relação ao controle centralizado, uma vez que centralização apresenta as seguintes desvantagens (NISTIR, 2018):

* Alto risco de perda ou destruição de dados
O usuário da rede deve confiar que o controlador central está fazendo cópias de segurança (backups) de todas as transações do sistema.

* Validação única
Os usuários da rede precisam confiar que o controlador central está validando cada transação recebida.

* Registro único
Os usuários da rede precisam confiar que o controlador central está registrando todas as transações recebidas.

* Risco de alteração
Os usuários da rede precisam confiar que o controlador central não está alterando transações passadas.

## Registro no livro-razão
Não se pode afirmar que o controle centralizado é ruim ou que sempre tem o objetivo de alterar transações passadas. Atualmente, grande parte do mercado financeiro mundial possui tal controle, cujo interesse é manter as transações íntegras e sob seu monitoramento.

Diferentemente dos sistemas centralizados, na Blockchain cada nó da rede distribuída possui uma cópia do livro-razão. Dessa forma, qualquer modificação do livro-razão seria facilmente reconhecida pelos demais nós, já que que cada nó possui uma cópia local e pode comparar e identificar alterações indevidas.

Por isso, uma das características principais da tecnologia Blockchain é a __segurança__, o que minimiza o risco de fraudes.

<figure>
  <img src="/assets/criptografia-e-registro-de-transacoes.jpg" alt="passos para validação e registro de uma transação na blockchain.">
</figure>

* Transação 1
O registro mostra que Alice recebeu 25 moedas digitais. O campo Entrada ou Inputs aponta para a origem do “dinheiro” a ser utilizado pela transação. Em computação, normalmente 0 representa o primeiro item ou saída do bloco anterior.

* Transação 2
Na segunda transação, há saída de 17 moedas para Bob, restando 8 para a Alice (25-17= 8, ou seja, o troco). A transação é assinada digitalmente por Alice, de modo que os demais nós da rede podem validar a autenticidade da transação.

* Transação 3
Em seguida, Bob transfere 8 moedas para Carol, restando-lhe 9 moedas (17-8= 9) e assina digitalmente a transação.

* Transação 4
Na 4ª transação, Alice transfere mais 6 moedas para Davi, restando-lhe 2 moedas ( 8-6=2) e novamente assina digitalmente a transação. O número 1 indica que Alice já assinou realizou/assinou uma transação anterior.

## Consenso
Em um livro-razão distribuído, as atualizações são construídas e registradas por cada nó da rede.
Os nós votam nessas atualizações, garantindo que a maioria concorde com o novo registro. Essa votação, que visa obter um acordo sobre a nova situação do livro-razão, é denominada __consenso__. Uma vez que o consenso é alcançado, o livro-razão distribuído é atualizado e todos os nós da rede irão armazenar sua última versão.

Para melhor compreender o consenso, imagine que uma transação, que chamaremos de número 4, necessita ser incluída no livro-razão. Cada nó da rede possui uma lista de transações pendentes. Como se trata de uma rede distribuída, uma vez recebida a transação, um nó irá transmiti-la para toda a rede para ser aceita, validada pela maioria dos nós (consenso, que será detalhado posteriormente) e, então, passará a integrar o livro-razão.

Veja um exemplo:

1. Entrada da transação

<figure>
  <img src="/assets/consenso-parte1.jpg" alt="Entrada da transação.">
</figure>

2. Transmissão nó a nó

<figure>
  <img src="/assets/consenso-parte2.jpg" alt="Transmissão nó a nó.">
</figure>

3. Registro no livro-razão

<figure>
  <img src="/assets/consenso-parte3.jpg" alt="Registro no livro-razão.">
</figure>

## Mineradores
Os usuários podem submeter transações para inclusão na Blockchain por meio de algum nó da rede. Os nós que realizam essa inclusão são denominados __mineradores__ (*miners*).

Eles são um grupo de nós da rede Blockchain que mantém a estrutura da cadeia de blocos, adicionando novos blocos com transações que estavam pendentes de validação ou informações recém-validadas.

Numa próxima aula, você vai entender o papel dos mineradores.

## Redes públicas e privadas
As transações, que você acabou de ver, podem acontecer em redes públicas ou em redes privadas.

Como você pôde perceber a Blockchain tem grande potencial para sanar problemas relacionadas à falta de confiança, transparência e segurança. A respeito desta última, podemos separar a Blockchain em 2 grandes grupos: de redes públicas e de redes privadas. Essas redes tem características comuns e pontos de divergências.

##### Semelhanças
Ambas são redes descentralizadas com negociação *peer-to-peer*, cada participante mantém uma réplica do *ledger* (livro-razão) assinada digitalmente. Ambas mantém a sincronia do *ledger* por meio de um protocolo chamado __consenso__ e garantem a imutabilidade.

##### Diferenças
Existe a restrição de quem pode participar da rede, executar o protocolo de __consenso__ e manter o ledger compartilhado, todavia na Blockchain pública qualquer pessoa pode baixá-la para um computador e ver todo o histórico da Blockchain, enviar e receber criptomoedas, armazenar informações e criar contratos inteligentes, a mineração também é pública.

A principal vantagem da tecnologia de contabilidade distribuída está na descentralização. A Blockchain é imutável e igual para todos, resistente a ataques DDoS e livre de censura, não há um único ponto de ataque e os *crackers* não podem alterar as informações, e quanto mais pessoas se juntam à Blockchain, mais segura ela se torna. Exemplos são as redes Bitcoin e Ethereum.

Na blockchain privada entretanto, há a restrição de permissões, por exemplo, os proprietários podem decidir manter controle total sobre a rede, e, consequentemente, eles desfrutam de alto grau de flexibilidade e podem ajustar algumas regras como: níveis de permissão, níveis de exposição, inclusão ou exclusão de membros, além do controle de frequência das atualizações. Blockchains privadas exigem portanto um alto nível de confiança entre os membros e podem ser excelentes instrumentos para as empresas aumentarem a eficiência e a segurança.

Já existem instituições financeiras utilizando a Blockchain em um sistema de votação dos seus conselheiros a fim de garantir o consenso dos votos, com esse sistema o banco pode garantir a segurança da votação e publicar o resultado em seu portal da transparência, se necessário.