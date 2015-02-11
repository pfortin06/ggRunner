#Intro
Ce document aura pour but de situer la conception artistique du jeu.
Afin de mieu comprendre ce document, le lecteur aura préalablement lu et comprit le GDD (Game Design Document).
La raison pour lequel ce document est séparé du GDD est que le style du jeu est tiraillé entre deux thèmes.
Les thèmes seront décrits plus loin dans le document et le choix sera laissé aux artistes.
Une autre option envisageable serrait que les artistes veuillent utiliser leurs propres et désigner eux même l'environnement.  
Dans ce cas, l'option devra être discutée et ne devra pas affecter le GamePlay général du jeu. 

#Thèmes
##Informations Générales
Puisque le jeu sera conçu pour être déployé sur des appareils mobiles et puisque le débit du jeu serra relativement élevé, 
l'environnement se devra d'être très épuré et/ou devra être très contrasté. 
Les styles réalistes seront donc malheureusement plus facilement mits de coté.

À la base, nous en sommes venus à ces deux styles de thème.

##Thème 1
Ce thème se base sur un environnement du jeu déjà existant ; celui de [Miror's Edge](http://www.mirrorsedge.com/)
En Bref, les éléments clefs de se thème seront:
* Un environnement plus urbain et moderne.
* Une palette de couleur moins vaste
* Les éléments interactifs seront d'une couleur plus contrastée pour les rendres plus évidents

Voici un exemple de l'environnement de Miror's Edge :
![alt text](http://kazugeek.com/wordpress/wp-content/uploads/2012/02/MirrorsEdge-2012-02-23-23-06-43-22.jpg)
On peut clairement discerné les objects importants en rouge, jaune et bleu.

##Thème 2
Ce thème est plus coloré et utilise le style [*Low Poly Art*](https://www.google.ca/search?q=low+poly+art&rlz=1C1ASUC_enCA598CA598&espv=2&biw=832&bih=435&source=lnms&tbm=isch&sa=X&ei=OcTSVIGXEczwUvSQgdAP&ved=0CAYQ_AUoAQ)

Les éléments clefs de se thème sont:
* Un environnement plus naturel/vivant (ex: une foret ou encore un montagne)
* Une palette de couleur très vaste et très contrastée
* Limitation à des formes géométriques de base

Voici deux exemples de *Background* que nous aimerions :

**Un peu moins détaillé.**  
![alt text](https://cdn.tutsplus.com/cg/uploads/2014/01/Blender_LP_Illustration_Preview.jpg)  

**Un peu plus détaillé.**  
![alt text](http://i.imgur.com/gtxpxkC.jpg)

#Travaux Demandés
Puisque le jeu est en développement, **_certains éléments sont encore en décision et sont sujets aux changements._**
Malgré l'incertitude de ceux-ci, il peut être bon de commencer à penser à leurs conceptions sans leur donner priorité.
Il se peut aussi que de nouveaux éléments fassent apparition au cours du projet.
Bien sûr, certains éléments sont moins propices aux changements et c'est donc pour cela que je diviserai ma liste en plusieurs sections.  

Les éléments **primaires** sont les éléments les moins propices à changer. 
Ils consistent probablement le *core* du jeu et les mécaniques liées à ceux-ci sont considérées "stable".   
Les éléments **secondaires** sont les éléments les plus propices aux changements.
Ce sont les éléments que nous voulons dans le jeu, mais que les mécaniques avec l'environnement sont encore "instable".  
Les éléments **inconditionnels** sont les éléments auxquels nous avons pensé et qui reste en discution.

`La liste n'est que sommaire et il se peut qu'il ait quelques oublies`

######Primaires
* Personnage principale et ses animations (Runner)
  * Forme humaine/humanoïde
  * Animations de base
    * Sauter, courir, marcher, mourir...
* Plateforme primaire
* Plateformes secondaires
* Un ou plusieurs Arrière plan
* Élements du UI/GUI
* Élements des menus
* cinématique de transition vers le jeu

######Secondaires
* Élements nuisibles (ex: des piques)
* Animation des trois pouvoirs avec les objects
* Apparence modifié du "Runner" selon le pouvoir actif
* Élements interagissant avec les pouvoirs

######Inconditionnels
* Des attaques
  * Animations d'attaques pour chaques pouvoirs
* Des niveaux pour chaques pouvoirs
  * Animations et apparance différente pour chaque niveau
* Des ennemies
  * volant, sautant, marchant ...
* Des ajouts esthétiques au "Runner"
  * Armures, chapeaux ...
* Élements favorable (ex: powerup, speed boost)

#Maquette
Voici une maquette du GUI qui poura vous servir de guide
![alt text](https://github.com/pfortin06/ggRunner/blob/master/GUIRunner.png)  
*Ici, les boutons avec les flêches reprensentent les actions de base (sauté, accroupir) et les boutons avec les "P" les 3 pouvoirs*
