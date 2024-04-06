<h3>Compte rendu de l'activité " Injection des dépendances"<h3>
<h4>Diagramme de classe<h4>
<img src="./Captures/img.png" />

<h4>Injection de dépendances</h4>
<p>Pour faire l'injection des dépendances j'ai procédé selon les 4 méthodes suivantes:</p>
<li>Instanciation statique</li>
<li>Instanciation dynamique</li>
<li>Version XML (Framework Spring)</li>
<li>Version annotations (Framework Spring)</li>

<h4>Instanciation statique<h4>
<p>Utilisation de l'operateur new</p>
<img src="./Captures/Presentation.png" alt="Presenation" />

<h4>Instanciation dynamique</h4>
<p>Utilisation d'un fichier txt (config.txt) qui contient le nom des classes
que l'on souhaite instancier et on utilise les méthodes forName() et newInstance()
pour instancier la classe lue à partir du fichier config.txt</p>
<img src="./Captures/Presentation2.png" alt="Presenation2" />

<h4>Version XML (Framework Spring)</h4>
<p>La création du fichier xml (applicationContext.xml) qui va permettre l'instanciation de l'objet qui sera 
accessible via l'ID "dao" et l'injection de ce dernier dans l'objet de type (MetierImp) 
qui sera instancier par la suite </p>
<img src="./Captures/PresXML.png" alt="PresenationXML" />

<h4>Version annotations (Framework Spring)</h4>
<p>l'utilisation de l'annotation @Component qui va permettre l'instanciation
des classes en question puis l'utilisation de @Autowired et @Qualifier pour injecter la dependances </p>
<img src="./Captures/PresAnnotation.png" alt="PresAnnotation" />