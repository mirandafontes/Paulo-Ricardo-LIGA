Gawr V1.0
Paulo Ricardo Miranda Fontes
De: 11/11/2021 (A noite)
Até: 15/11/2021 (Terminado a noite)

Preferi rushar durante o final da semana passada (11 a 15)
pois tenho provas e simulados do curso de japonês
durante o final de novembro (a prova do JLPT é no início de dezembro)

Além deste README, há também o Diario, onde eu fui escrevendo (de maneira bem informal)
o que eu estava implementando e o que estava acontecendo pelos dias. Vale uma lida também.

O que temos hoje:

    - Main Menu
    - Cena intermediare (para carregar de maneira async demais cenas de gameplay)
    - Uma cena de gameplay (servindo também como Scene template)
    - Suporte para ARM64 e ARMV7 (utilizando IL2CCP como backend)
    - Unity ADS na cena intermediare
    - Unity Analytics na cena de gameplay (pontos, tempo total e número total de cogumelos pegos)
    - Movimentação baseada em física (RigidBody)
    - Prefab para o player e cogumelos (com prefab variant)
    - Uma documentação (html) do código gerada, contendo diagramas UML, utilizando o Doxygen
        (posso fornecer depois, não coloquei dentro do projeto devido à limitação de tamanho do GitHub)
    - Assembly Definitions

O que eu gostaria de ter feito:

    - PlayerPrefs como Notifier (para desbloqueio de mais fases e controle da condição do áudio)
    - Implementar áudio e UI de controle utilizando Observer (atualizando o valor do playerprefs e notificando a UI)
    - Implementar classes de controle para a UI (será explicado mais a frente)
    - Implementar mais fases utilizando o sistema de dados/condições feito
    - Criar uma classe para gerenciar o spawn de cogumelos bons e ruins (esse dado está no scriptable do Scene Data, mas não foi utilizado)
    - Criar outra classe para automatizar alguns processos de criação da fase
    - Criar um script chamado Main (ou similar), que serviria para fazer Dependency injection e preencher as interfaces necessárias a serem utilizadas
        (Isso facilitaria a troca das classes que implementam tais interfaces, uma vez que todas elas estariam sendo criadas e relacionadas no main.
        Algo como o framework Zenject faz, mas centralizado nesta classe.)
    - Implementar testes unitários para todas as classes do model

Otimizações que ativamente busquei:

    - Desmarcar a opção de "Raycast Target" para todo e qualquer objeto que não é clicavel na UI (como bordas, background de painéis e afins)
    - Limitar o FPS para 30 (evitando que o celular esquente e consuma muita bateria)
    - Utilizar canvas simples e, caso este se tornasse complexo, dividir entre canvas menores
        (cada modificação em um elemento da UI faz o Unity redesenhar TODO o canvas. Canvas grandes demais devem ser divididos em menores)
    - Evitar o uso de Update's e FixedUpdate's (apenas onde é necessário, como identificação de Inputs)
    - Utilizar call-by-need SEMPRE que possível (ou seja, NUNCA atualizar à todo momento, apenas atualizar quando for necessário ou pedido)
    - Classe Words, contendo strings comumente utilizadas no código (assim como sua hash)
    - Comprimir corretamente todos os elementos de UI, Sprites e afins utilizados.
    - Diminuir o far view da câmera
    - Configurar corretamente as layers (para colisões e afins)

Ideia inicial do jogo (com comentários):
Você é um pequeno dinossauro que deve coletar evitar os cogumelos ambulantes
enquanto escapa dos meteoros. Sobreviva por mais tempo.

Aqui eu já tinha definido algumas interfaces básicas e modelos.
A movimentação seria feita utilizando o Command Pattern
e o PlayerEntity seria uma entidade que se movimenta - implementa IMoveableEntity -.
O uso do Command Pattern facilitaria a criação de uma pequena IA, ao definir estados de máquina
para ela sendo composto de uma lista de commands concretos. Facilitaria muito a expansão de comportamento
e adição de outras features - a exemplo do IActableEntity, que serviria para interações in-game mas que não foi
utilizada.

Além disso, a divisão dos dados (separando-os da lógica) da Cena como o scriptable SceneData e do Player (entenda este como o Entity, e não o jogador humano em si)
como a classe PlayerData facilitariam a construção desse modelo.

Ideia final do jogo:
Você é um pequeno dinossauro que deve coletar os bons cogumelos para
obter pontos, evitando os ruins.

Como jogar:
    - No celular, utilize os botões direcionais na UI
    - No editor, utilize as setas direcionais e a barra de espaço

Alguns termos e suas explicações encontram-se dentro dos códigos.
Alguns sumários (documentação XML do código) também contém explicações de lógica.

Principais classes encontram-se nas seguintes pastas:

    - Assets\Scripts\Gawr\Model (Principalmente aqui)
    - Assets\Scripts\Gawr\Handlers (Contém apenas o ControllerHandler.)

A movimentação do personagem utiliza o Command Pattern.

Interface para o Commannd:
- ICommandAction

IMoveableEntity atua como o Receiver do Command Pattern, definindo as ações para os commands concretos.
PlayerEntity implementa o IMoveableEntity.

ControllerHandler
Classe responsável pela detecção e uso dos inputs. Invoker do Command.
Ponte entre o Monobehaviour (inputs, update e afins) e os commands.

Os dados do jogador e da cena encontram-se separados da lógica do jogo
em classes como:

    - SceneData (Scriptable)
    - PlayerData (Classe de dados apenas)
    - PlayerContainerData (contém a classe acima para acesso de classes Monobehaviour. Um "facade"/fachada.)

Houve a intenção de permitir a criação rápida de outras e novas regras para o jogo
sempre que fosse necessário, permitindo uma rápida expansão das condições
de vitória/derrota e da criação de novas cenas.
Para isso, foi utilizado o TemplateMethod, uma interface e uma classe abstrata
para servir de base às novas implementações de GameOver:

    - IGameConditioner (Interface para definir assinatura das condições de vitória e derrota)

    - GameConditioner (
        Classe abstrata que implementa parcialmente a interface acima, jogando parte da implementação para
        classes herdeiras. Métodos abstratos:
            - public abstract bool WinCondition()
            - public abstract bool LoseCondition()
        atuam como a implementação do TemplateMethod.
        Possui UnityEvents para vitória e derrota.)

    - DefaultRulesCheck (herda de GameConditioner e implementa os métodos abstratos. 
        Possui as condições básicas do jogo como: não pode morrer, pegar X pontos para vencer
        e não pode acabar o tempo. Ela tem referência as classes de dados para checkup.)

    - ITimer (Interface para definir um contador. Utilizado na classe acima)

Esse modelo permitira uma rápida expansão e, caso cada condição fosse implementada 
unicamente e separadamente em uma classe que herdasse de GameConditioner, teríamos:

    - Uma classe para verificar a morte do player
    - Uma classe para verificar a quantidade de pontos
    - Uma classe para verificar se o tempo acabou

Isso facilmente possibilitaria a criação de condicionais mais complexas para o jogo
caso a classe abstrata possuisse uma lista de GameConditioner. Ela iteraria por essa
lista chegando as diversas condições.
Condições mais complexas seriam formadas nas classes filhas, onde essa lista seria novamente preenchida e iterada pela classe base.

Com uma rápida modificação, poderíamos tornar essa classe no Composite Pattern, facilitando
o acesso as suas funcionalidades, fornecendo acesso às classes externas como um único nó,
de maneira simples e uniforme.

ENTRETANTO, devido a característica da aplicação (um teste), eu optei por não
fazer assim, centrando as três condições (Tempo, pontos e não morrer) na classe
DefaultRulesCheck e não utilizando a lista de condicionais.

A identificação de colisões foi feita utilizando basicamente 2 classes com 
UnityEvent nos métodos Enter, Stay e Exit:

    - CollisionEvent (Colisão normal, entre 2 corpos com collider)
    - TriggerEvent (Ativão de trigger. Apenas contra outro collider)

Isso permite uma rápido montagem e uso nas cenas
além de uma boa flexibilidade para lidar com diversas
situações diferentes.

O controle da câmera foi feito utilizando Cinemachine.
Pensei em escrever o script para tal, mas acabei desistindo
e utilizando o próprio cinemachime (que se sai infinitamente
melhor do que eu acabaria escrevendo de qualquer forma.)

Para o loading das cenas, defini uma interface básica (ILevelLoader) e 
a implemente em LevelLoader. Ele utiliza singleton* e persiste entre
o carregamento de cenas. Para associar seus métodos ao Unity (no caso,
a UI), criei um AssociateLevelLoader.

* Eu pensei um pouco se deveria ou não utilizar o singleton para criar esta classe.
Embora ele seja um pattern, ele costuma criar alguns outros problemas de design
e atrapalha a facilidade de troca de código e etc. Mas acabei optando por mantê-lo.
Sua contraproposta também (Monostate) não seria interessante de se utilizar.

Dificuldades
Alguns problemas que encontrei enquanto desenvolvia:

    - Os assets fornecidos, ao importar para o Unity, vieram com tamanhos diversos e maiores que o sprite em si.
        Assim, no sprite editor, existia um espaço vazio de alpha. Tive que repassar quase todos os sprites
        e manualmente colocar á área adequada. Ainda assim, alguns sprites apresentam um deslocamento/offset (o de morte do dinossauro, por exemplo).

    - Preferi criar canvas simples e por consequência, acabei não criando scripts para tratar diretamente os elementos de UI.
        Utilizei scripts genéricos e simplistas para tratar algums coisas.
        Por consequência, algumas interações simples como ativar/desativar um CanvasGroup se tornaram 3 chamadas de métodos diferentes (Alpha, Raycast e Interactable)
        no UnityEvent. Assim, começou a ficar algo desagradável tratar UI. Minha sorte foi que isso já se deslocava para o final do desenvolvimento
        da cena de gameplay e, como a cena era simples, consegui terminar.
        Com toda a certeza, se eu viesse a mexer novamente no projeto, seria a primeira coisa que modificaria. 

    - Perdi 1 hora e algo tentando entender por que as colisões não aconteciam corretamente, apenas para ver que eu troquei ao adicionar o componente no GameObject
        um collider 2D por um collider 3D... Pois é...

    - Não exatamente uma dificuldade mas:
        Embora eu consiga trabalhar sozinho, a falta de alguma pessoa para revisar a lógica e código fizeram eu perder alguns minutos conversando
        comigo mesmo para garantir que o que eu estava pensando estava correto ou seria a melhor forma de implementar.
        Comprar um patinho de borracha na próxima.