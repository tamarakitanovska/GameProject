# GameProject
Документација


Апликацијата која ја развивавме е игра која што е наменета за студентите на ФИНКИ, со цел на еден забавен начин да се одговараат некој од прашањата поврзани со предметите на ФИНКИ.

Основните правила кој што треба да се следат за играње на играта се слидните:
-	При истекувањето на времето се појавуваат топки на формата кои што корисникот треба да ги погоди со помош на авионот поставен на долната страна на прозорецот.

-	Авионот може да функционира на начин што корисникот ко продвижува лево, десно или право со помош на стрелките на тастатурата.


-	Постојат пет состојби за придвижување на авионот, авионот може да се придвижи два пати на позицијата лево, два пати на позицијата десно или право.

-	Корисникот при придвижување на авионот исто така потребно е при клик на маусот да испушта топки со кои што ќе се обиде да ги погоди големите топки кој се појавуваат на прозорецот.


-	Топките кои се појавуваат на прозорецот паѓаат во разни бои, секоја боја соодветствува на разичен предмет од факултетот и тоа: Оперативни системи – црна боја, Архитектура и организација на компјутери сина боја, Софтверско инженерство црвена боја, Структурно програмирање зелена боја, Маркетинг – жолта боја.

-	Доколку корисникот не успее да погоди некоја топка и истата излезе од рамките на прозорецот, на корисникот му се појавува прашање од соодветниот предмет.


-	Доколку корисникот одговори точно/неточно на прашането му се додаваат/одземаат поени соодветни на предметот од кој што е поставено прашањето и тоа: Оперативни системи +-5 поени, Архитектура и организација на компјутери +-4 поени, Софтверско инженерство +-3 поени, Структурно програмирање+-2 поени, Маркетинг+-1 поен.

-	Доколку корисникот има помалку од 0 поени, се појавува дијалог прозорец на кој има можност да одбере дали сака да започне нова игра или да заврши со играта.

-	Играта исто така има имплементирано функционалности за зачувување на состојбата на играта и отпочнување на играта од таа состојба, започнување нова игра како и паузирање на состојбата.

![](https://user-images.githubusercontent.com/39771186/41686533-b6df0044-74e4-11e8-854e-d29deb5d1f9e.png)
![](https://user-images.githubusercontent.com/39771186/41686532-b6be3350-74e4-11e8-9595-cf03105723fb.png)


Имплементација\
Решението е имплементирано на начин што предметот е претставен со помош на класата Subject. За секој предмет се чуваат прашањата како и одговорите на прашањата за тој предмет, неговото име и бојата со која е претставен. Во оваа класа има имплементирано функција getQuestionAndAnswer() која враќа речник каде клучот е прашањето, а вредноста се одговорите(прашањето се избира рандом). Класата SubjectFactiry содржи статични референци кон инстанци од класата Subject за сите предмети кои се прикажани во играта. Оваа класа имплементира метод GetSubject() кој враќа еден од предметите. Користејќи го овој метод во својот конструктор класата FallingBall(Објаснета подолу во текстот) добива референца кон некој од предметите.
![](https://user-images.githubusercontent.com/39771186/41685644-6054b410-74e1-11e8-8307-997f84fe31a0.png)
![](https://user-images.githubusercontent.com/39771186/41685645-60742098-74e1-11e8-817c-0c73ca8db965.png)
 
Апстрактната класа Ball ги претставува основните функционалности на една топка, како што се нејзиното движење, исцртување и сл. Од оваа класа наследуваат класите FallingBall и FireBall, кои соодветно ги имплементираат апстрактните функции од класата Ball.  BallController е класата преку која ги контролираме сите топки на формата, нивното појавување, проверка дали се погодени од страна на авионот и сл.
Функционирањето на авионот е обезбедено од класата Плане. Во оваа класа се чуваат листа од слики, каде секој слика дефинира соодветна позиција на авионот заедно со соодветната позадина, листа од точки(инстанци од класата Point) кој се користат при испукување на топките-истрели(инстанци од класата FireBall) и состојба. Оваа класа го имплементира дизајн патернот State, така што се чува цел број(стате) кој означува во која состојба се наоѓа авионот(нјлево,лево,средина,десно,најдесно) и врз основа на оваа состојба методите во класата враќаат соодветни вредности. 
![](https://user-images.githubusercontent.com/39771186/41685646-6094364e-74e1-11e8-996c-59e46f5c605b.png)
![](https://user-images.githubusercontent.com/39771186/41685642-601199e6-74e1-11e8-98c9-f1c3b58d841e.png)
![](https://user-images.githubusercontent.com/39771186/41685643-6034024c-74e1-11e8-861c-023438b208db.png)
  
 
Сликите кои ги користи авионот се наоѓаат во фолдерот со ресурси.

Контроли за игра:\
•	Left Arrow-Движење лево на авионот\
•	Right Arrow-Движење десно на авионот\
•	Mouse click-Пукање со авионот\
•	P-Пауза

Членови во тимот:\
-Тамара Китановска 143073\
-Лазе Ѓоргиев 161094
