#### Realizado por: 

**Daniel García Navarro -->** @DanielGarciaFlorida & @DanielGarcia-1907 

**Julio Herraez Vila-->** @Juhevi01 

**Isabella McBrown García -->** @ismcga 

**Adrià Rodríguez Martínez -->** @Adria2304 

**Nicole Guerra Cantú -->** @thaanxtos 

**Carmen Guardino de la Flor -->** @dguardinoflor 


El proyecto consiste en un juego al estilo Super Mario Bross o Hollow Knight. 

## Mecánica de movimiento del jugador
El siguiente script PlayerMovement se encarga de gestionar el movimiento básico del personaje: desplazamiento horizontal, gravedad y salto. Es un sistema sencillo pero totalmente funcional que permite controlar al jugador sin necesidad de Rigidbody2D ni físicas de Unity, ya que todo se calcula manualmente mediante modificaciones directas a la posición del objeto.

En el método Start(), se asignan los valores base del movimiento del jugador, como la velocidad horizontal, la fuerza del salto y el nivel del suelo. También se reinicia la velocidad vertical para asegurar que el personaje comienza sin movimiento en el eje Y.

![](/README_Content/foto21.png)

Dentro del método Update(), primero se captura el input horizontal del jugador mediante Input.GetAxis("Horizontal"). Este valor se multiplica por la velocidad y por Time.deltaTime para asegurar un movimiento fluido y dependiente del tiempo.

![](/README_Content/foto17.png)

El script no usa físicas de Unity, por lo que detecta manualmente cuándo el jugador está tocando el suelo comparando su posición con un valor de referencia llamado groundY.
Cuando la posición del jugador es menor o igual al nivel del suelo se corrige la posición para que no atreviese el suelo y se marca al jugador "como en el suelo".
Se corrige la posición para que no atraviese el piso.

![](/README_Content/foto18.png)

El salto se ejecuta únicamente si el jugador está en el suelo y presiona la barra espaciadora. En ese momento se asigna un impulso vertical, que produce el ascenso.
El salto se consigue simplemente asignando una velocidad vertical positiva.

![](/README_Content/foto19.png)

Mientras el jugador esté en el aire, se aplica la gravedad restando valor continuamente a la velocidad vertical. Después, el personaje se mueve hacia arriba o hacia abajo según dicho valor. Este sistema permite simular una física sencilla donde el salto sube suavemente y luego cae de manera acelerada.

![](/README_Content/foto20.png)

## Mecánica del cofre
Para las habilidades que el jugador puede desbloquear abriendo el cofre, he creado este script, es simplemente prueba, faltaría pulir las habilidades, pero en principio la base del script es funcional. Creé 4 booleanas y empiezan en false y la habilidad que toque en el cofre se pondrá a true y la habilidad se activará.
También debes llamar al script del jugador para coger el parámetro de movimiento, para cambiar su valor dependiendo de lo que toque.

![](/README_Content/foto1.jpeg)

Para eso, a continuación, hice un public void donde dentro hay un switch, gracias a eso puedo hacer varios casos con las 4 habilidades, y en cada una activa la booleana a true para activar la habilidad, tambien para probar si funcionaba añadí un debug.log para ver si en la consola aparecia y confirmar.
Aquí tambien puedes modificar los valores como por ejemplo modificar el impulso si te toca el "Salto Alto".

![](/README_Content/foto2.jpeg)

El script del cofre se encarga de gestionar la interacción del jugador con un cofre que otorga habilidades. Para ello, declara varias variables públicas que permiten asignar desde el editor de Unity los elementos necesarios, como el texto de interacción y la interfaz de la ruleta. También incluye referencias internas que controlan si el jugador está cerca del cofre, si el cofre ya ha sido abierto y el acceso al script que maneja la ruleta de habilidades.

En el método Start(), el script obtiene el componente RuletaUI del objeto asociado a la interfaz de la ruleta. Esto permite que, cuando el jugador interactúe con el cofre, se pueda activar la animación o el proceso de selección aleatoria de habilidades. En conjunto, el script actúa como intermediario entre la presencia del jugador, la interfaz del cofre y la mecánica de otorgar habilidades permanentes.

![](/README_Content/foto3.jpeg)

Este fragmento del script detecta cuándo el jugador entra o sale del área de interacción del cofre.
Cuando el jugador entra en el OnTriggerEnter2D, si el cofre aún no ha sido abierto, se activa el texto de interacción y se registra la referencia al jugador.
Cuando el jugador sale del área, mediante OnTriggerExit2D, el texto se desactiva y se marca que ya no está cerca del cofre.

![](/README_Content/foto4.jpeg)

En el método Update() se comprueba si el jugador está cerca del cofre, si este aún no ha sido abierto y si el jugador ha pulsado la tecla E. Si se cumplen estas condiciones, se ejecuta OpenChest().
Este método marca el cofre como abierto, oculta el texto de interacción y comienza la corrutina StartRoulette(), la cual activa la interfaz de la ruleta, espera a que termine la animación y finalmente obtiene la habilidad seleccionada para asignársela al jugador. Después de ello, la interfaz de la ruleta se desactiva nuevamente.

![](/README_Content/foto5.jpeg)

Para el código de la ruleta, crea un array donde arrastraremos dentro los 4 paneles con las habilidades, añadiremos colores que permiten distinguir visualmente el estado normal y el estado seleccionado de cada opción, y diferentes variables numéricas que controlan la velocidad inicial del movimiento, la desaceleración y el tiempo máximo de espera entre cada cambio de posición. Además, se incluye un índice que almacena cuál opción está actualmente seleccionada.

![](/README_Content/foto6.jpeg)

Este fragmento de código implementa el funcionamiento de la ruleta mediante una corutina llamada PlayRoulette(). Al iniciarse, se establece un retraso inicial y se restablecen los colores de todos los paneles. Luego, mientras el tiempo de espera sea menor que el máximo permitido, la ruleta avanza al siguiente panel aumentando el índice seleccionado y aplicando un color distintivo a dicho panel. Entre cada cambio se detiene durante un intervalo que va aumentando progresivamente, lo que simula el efecto de desaceleración. Cuando el retraso supera el límite, la corutina finaliza, dejando resaltado el panel donde la ruleta se detuvo.

La función GetSelectedSkill() devuelve el índice de la opción final seleccionada, mientras que ResetColors() se encarga de restaurar el color original de todos los paneles antes de resaltar el actual.

![](/README_Content/foto7.jpeg)

## Sistema de vidas

Hemos logrado implementar un sistema de puntos de salud, en donde por cada golpe del enemigo se resta un corazón, y al llegar a 3 corazones vacíos el jugador "muere".

Para el sistema de vidas, primero creamos 2 arrays, donde en una arrastraremos los corazones llenos, y en el otro array arrastraremos los corazones vacíos.

![](/README_Content/foto9.jpeg)

De tal manera que el resultado sea este, así se vería en el inspector de Unity.

![](/README_Content/foto10.jpeg)

Este código gestiona un sistema de vidas utilizando corazones en pantalla. UpdateHearts() revisa cuántas vidas tiene el jugador y activa o desactiva los iconos de corazones llenos y vacíos según corresponda.
TakeDamage() reduce las vidas asegurándose de que no bajen de cero, y luego actualiza la interfaz.
Heal() hace lo mismo pero aumentando vidas sin superar el máximo.
Finalmente, FindInstance() localiza automáticamente la instancia del componente HeartsUI en la escena.

![](/README_Content/foto11.jpeg)

Este método RecibirDaño() resta la cantidad de daño a la salud del jugador. Si la salud llega a cero o menos, desactiva el SpriteRenderer y el componente de movimiento del jugador, dejando al personaje inmóvil y oculto, simulando su “muerte” en el juego.

![](/README_Content/foto12.jpeg)

Asi sería el resultado final de nuestro sistema de vidas del personaje, totalmente funcional.

![](/README_Content/video02.gif)

## Sistema de recolección de objetos e inventario

El script implementa la interacción de recolección de ítems. A su vez, se implementa un inventario, en el cual se establece una referencia en la inicialización del script de recolección del jugador, buscándolo por la Tag "Player".

Para recoger objetos, en el script, asignaremos un parametro de Sprite Renderer, donde la llamaremos en el start.

Para terminar una variable donde sea Ontriggerenter2D donde haremos que si un tag llamado "Player" que es el tag que lleva el Jugador toca el obejto, el objeto el cual ha tocado el player se destruirá o desactivará, lo cual dará la sensación que ha recogido ese objeto.

Los objetos que queremos que desaparezcan si tocan al jugador deben estar con un box collider con el "is Trigger" activado, si no lo está, el objeto no desaparecerá.
El jugador debe tener Rigibody2D, ya que sin Rigibody2D no hay OnTriggerEnter2D.

![](/README_Content/foto15.jpeg)

Y así sería el resultado, ahora el jugador puede recolectar los objetos del mapa.

![](/README_Content/video03.gif)

## Implementación de algoritmo con estrategia algorítmica 

**Script:** Enemy_Script.cs 

**Estrategia utilizada:** Algoritmo Voraz (Greedy) 

### Descripción del algoritmo 
Implementa un comportamiento de enemigo basado en la estrategia voraz, que consiste en tomar en cada frame la decisión local que más reduce la distancia al jugador. Esta estrategia garantiza que el enemigo siempre toma la mejor decisión local para acercarse al jugador 

El comportamiento se desarrolla de la siguiente manera: 

1.Se calcula la distancia horizontal entre el enemigo y el jugador. 
2.Si el jugador está dentro del rango de detección (detectionRange) pero fuera de la distancia mínima de parada (stopDistance), el enemigo calcula la dirección hacia el jugador. 
3.Se lanza un raycast hacia esa dirección para detectar posibles obstáculos cercanos (obstacleDetectionDistance). 
4.Si se detecta un obstáculo, el enemigo sube ligeramente sobre él (obstacleStepHeight) mientras mantiene la dirección hacia el jugador. 
5.Si no hay obstáculo, el enemigo se mueve normalmente hacia el jugador. 
6.El sprite se orienta siempre hacia el jugador ajustando la escala en X (scale.x). 

![](/README_Content/foto22.png)

### Análisis de costes 

En cuanto al coste temporal, el algoritmo presenta una complejidad O(1), ya que la lógica de movimiento y el cálculo del raycast se ejecutan una única vez por frame, independientemente del tamaño o la complejidad del nivel. 

Respecto al coste espacial, también es O(1), puesto que no se crean estructuras de datos adicionales y únicamente se emplean variables temporales durante la ejecución. 

La principal ventaja de la estrategia voraz utilizada es su alta eficiencia en enemigos sencillos: permite reaccionar en tiempo real ante el entorno y requiere un consumo mínimo de recursos. 

Como desventaja, esta estrategia no garantiza la obtención del camino óptimo en escenarios complejos o con múltiples obstáculos, ya que las decisiones se toman de forma local sin considerar una planificación global. 

## Implementación de método iterativa y su forma recursiva 


**Script:** Contador.cs

**Método utilizado:** Iterativo y recursivo

### Sistema de Contador de Frutas 

Se elimino el inventario anterior y se ha desarrollado un contador que identifica y contabiliza los tres tipos de frutas del juego: Manzana, Calabaza y Zanahoria. El núcleo de este sistema es un algoritmo iterativo que utiliza un bucle for para recorrer un catálogo de referencias, comparando el nombre del objeto colisionado con los datos del sistema para asignar el incremento al contador correcto de forma eficiente. 

![](/README_Content/foto23.png)

Por otro lado también se desarrolló una versión recursiva adicional en el mismo script. Ambas versiones tienen un coste temporal O(n), pero la versión iterativa es superior al tener un coste espacial O(1) (constante) frente al O(n) de la recursividad, que consume memoria en la pila de llamadas. Se eligió la versión iterativa por su mayor legibilidad y eficiencia en Unity. 

![](/README_Content/foto24.png)

### Implementación de probabilidad uniforme 

**Script:** RuletaUI.cs. 

**Probabilidad utilizada:** Uniforme 

La selección se utiliza para elegir aleatoriamente una habilidad cuando el jugador abre un cofre. La probabilidad uniforme se consigue mediante un recorrido secuencial de las habilidades, donde cada una ocupa una posición fija en la ruleta. La animación avanza por los distintos paneles y se detiene en uno de ellos, que representa la habilidad otorgada.  

La habilidad seleccionada se devuelve como un índice y se utiliza para desbloquear una de las cuatro habilidades del jugador (doble salto, aumento de velocidad, salto alto o dash). 

![](/README_Content/video1.gif)


