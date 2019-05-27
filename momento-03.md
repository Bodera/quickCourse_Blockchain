## Transações utlizando criptomoedas (9/23)
 Para negociar Bitcoin, ou qualquer outra criptomoeda, é preciso ter uma carteira digital, ou simplesmente *wallet*.

 Uma wallet de criptomoedas é um programa de software que armazena as criptomoedas e as chaves pública e privada além de interagir com várias blockchains. Com isso, os usuários podem enviar e receber criptomoedas e monitorar seu saldo e suas transações. 
 
 Os tipos de *wallets* podem variar de acordo com o projeto, mas, atualmente, existem as seguintes:
 * Desktop
 * Web
 * Mobile
 * Hardware
 * Paper
 
 A criptomoeda [Nano](https://nano.org/en) disponibiliza carteiras digitais nos modelos Web, Desktop e Mobile. E opera em multiplataforma.

## Segurança na blockchain
* Chave pública e chave privada
 A segurança e o anonimato das transações são garantidos pelas assinaturas digitais dos negociadores. Essas assinaturas são realizadas a partir das chaves pública e privada. Para entender como essas chaves funcionam, você vai conhecer o conceito de criptografia de __chaves assimétricas__ ou criptografia de __chave pública__.

 A criptografia de chave pública faz uso de um par de chaves matematicamente conectadas:

<figure>
  <img src="/assets/descricao-chave-privada.png" alt="propriedade de uma chave privada">	
</figure>

<figure>
  <img src="/assets/descricao-chave-publica.png" alt="propriedade de uma chave pública">	
</figure>

 Computacionalmente, a geração dessas chaves é uma tarefa muito simples. A chave pública é gerada a partir da chave privada. Mas, não é possível gerar a chave privada a partir da chave pública. Dessa forma, podemos publicar a nossa chave pública em uma rede sem temer que a nossa chave privada seja descoberta.

 Tudo bem, temos um par de chaves, mas como esse par é utilizado na Blockchain?

 Para produzir um endereço válido na rede, inicialmente geramos a chave privada de um usuário. A partir da chave privada, diversos algoritmos podem ser utilizados para derivar a chave pública.
 
 Uma vez que geramos a nossa chave pública, submetemos tal chave ao algoritmo de hash SHA-256, obtendo nosso endereço.
Na rede bitcoin, por exemplo, esse endereço ainda é submetido a um outro algoritmo (RIPEMD-160), que irá produzir o endereço bitcoin.

 Todo esse processo de codificação garante o anonimato nas transações em rede.
<figure>
  <img src="/assets/anonimato-transacao-p2p.png" alt="funcionamento da criptografia de chave pública">	
</figure>


## Processo de criação de chaves digitais
 A criptografia assimétrica é baseada em duas chaves: a chave privada e a chave pública. Imagine que você deseja transmitir um arquivo em uma rede, e busca garantir que apenas o destinatário possa ler seu conteúdo. Para isso, você pode fazer uso da chave pública desse destinatário para cifrar o documento, criptografando-o. Somente com a chave privada (que fica em posse do destinatário) será possível decifrar o texto. Observe a ilustração a seguir:
 
<figure>
  <img src="/assets/encoding-messages-public-key.jpg" alt="a confidencialidade como chave do anonimato.">	
</figure>

 
 A geração dessas chaves se dá a partir de números aleatórios, normalmente números primos. Podemos resumir esse processo como segue, simulando o algoritmo RSA, um dos mais aplicados:

1. Escolha dois números primos distintos, p e q.  
2. Calcule n 𝑛=𝑝∙𝑞  
3. Calcule z 𝑧=(𝑝−1)∙(𝑞−1)  
4. Obtenha um número 𝑒 (𝑒 :𝑛ú𝑚𝑒𝑟𝑜 𝑝𝑟𝑖𝑚𝑜 𝑞𝑢𝑎𝑙𝑞𝑢𝑒𝑟, então, escolha um número)  
5. Calcule 𝑒∙𝑑(𝑚𝑜𝑑 𝑧)=1  
6. O par (e,n) é a chave pública, e o par (d,n) é a chave privada.  

Acompanhe um exemplo prático:  

Suponha dois números primos: p = 29 e q = 37  
Resolvendo:  
n = p * q  
para p=29 e q=37  
n = 29 * 37  
n = 1073  

z = (p-1) * (q-1)  
z = (29-1) * (37-1)  
z = 28 * 36  
z = 1008  
 
e = número primo aleatório  
adotaremos e = 89 para exemplificar  
logo:  
e * d(mod z) = 1  
89 * d(mod 1008) = 1  
d = 1097  

Então, agora podemos montar o par de chaves:  
Chave pública = (e,n) = (89,1073)  
Chave privada = (d,n) = (1097,1073)  

## Formação do bloco
 Um bloco pode ser entendido como um conjunto de transações ou informações validadas.

 Uma vez que a transação é recebida, ela pode ser transmitida aos outros nós, para que possa ser incluída na Blockchain. As transações são incluídas na Blockchain pelos nós mineradores (miners).

 Além da lista de transações, um bloco possui as seguintes partes:
 
 //image bloco
