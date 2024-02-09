# EasySave - Application de Sauvegarde Console .NET Core 3.0

## Description
EasySave est une application de sauvegarde conçue pour offrir une solution simple et efficace pour sauvegarder des données depuis un répertoire source vers un répertoire de destination spécifié. Elle est développée en C# sur la plateforme .NET Core 3.0.

### Fonctionnalités de la Version 1.0

- Création de jusqu'à 5 travaux de sauvegarde.
- Définition d'un travail de sauvegarde avec un nom, un répertoire source, un répertoire cible et un type (complet, différentiel).
- Utilisable par des utilisateurs anglophones et francophones.
- Exécution séquentielle de tous les travaux ou d'un travail spécifique par ligne de commande.
- Sauvegarde depuis des disques locaux, externes ou des lecteurs réseaux.
- Sauvegarde de tous les éléments du répertoire source (fichiers et sous-répertoires).
- Fichier Log journalier et fichier Etat temps réel au format JSON.
- Adaptation des emplacements des fichiers pour fonctionner sur les serveurs des clients.

### Présentation de Prosoft

EasySave est développé dans le cadre de notre intégration chez ProSoft. Nous devons respecter les contraintes suivantes :

- Outils et méthodes :
  - Visual Studio 2019 16.3 ou supérieure
  - GIT Azure DevOps
  - Editeur UML : ArgoUML recommandé
- Langage, Framework :
  - Langage C#
  - Bibliothèque .NET Core 5.X
- Lisibilité et maintenabilité du code :
  - Exploitable par les filiales anglophones
  - Limiter au maximum les lignes de code dupliquées
  - Respect des conventions de nommage
- Autres :
  - Documentation utilisateur en une seule page
  - Release note obligatoire
  - Soigner les IHM pour une distribution chez les clients.

### Prochaine étape : Version 2.0

Si EasySave donne satisfaction, la direction nous demandera de développer une version 2.0 utilisant une interface graphique WPF.

## Axes d'amélioration

- Mise en place de condition d'entrée (path, etc...)
- Modification du chemin du fichier log et état en temps réel depuis l'application
- Ajouter des langues à l'application

## Installation

Pour installer EasySave, veuillez suivre les instructions suivantes...\

#Prérequis d'intallation
- Avoir Visual Studio 2019 installé sur le poste
- Avoir git bash installé sur le poste

Pour les personnes débutantes, suivez cette procédure d'installation :
[installation de EasySave v1.pdf](https://github.com/louanne622/EasySave/files/14223357/installation.de.EasySave.v1.pdf)


Sinon :\
Pour installer depuis l'invite de commande :\
```git clone https://github.com/louanne622/EasySave.git```  

## Utilisation

Pour utiliser EasySave, suivez ces étapes...

Ouvrez une ligne de commmande, placez vous dans le fichier "EasySaveConsole"\
```cd EasySaveConsoleMode```\
Lorsque vous vous situez bien dans le fichier du projet, lancez la commande pour lancer l'application:\
```dotnet run```

----------------------------------------------------------------------------------------------

# EasySave - .NET Core 3.0 Console Backup Application

## Description
EasySave is a backup application designed to provide a simple and effective solution for backing up data from a specified source directory to a destination directory. It is developed in C# on the .NET Core 3.0 platform.

### Version 1.0 Features

- Creation of up to 5 backup jobs.
- Definition of a backup job with a name, a source directory, a target directory, and a type (full, differential).
- Usable by English and French-speaking users.
- Sequential execution of all jobs or a specific job via command line.
- Backup from local, external disks, or network drives.
- Backup of all items in the source directory (files and subdirectories).
- Daily Log file and real-time State file in JSON format.
- Adaptation of file locations to work on client servers.

### Prosoft Presentation

EasySave is developed as part of our integration at ProSoft. We must adhere to the following constraints:

- Tools and methods:
  - Visual Studio 2019 16.3 or higher
  - GIT Azure DevOps
  - UML Editor: ArgoUML recommended
- Language, Framework:
  - C# Language
  - .NET Core 5.X Library
- Code readability and maintainability:
  - Usable by English-speaking subsidiaries
  - Minimize duplicated lines of code
  - Adherence to naming conventions
- Others:
  - Single-page user documentation
  - Mandatory release notes
  - Careful design of user interfaces for distribution to clients.

### Next Step: Version 2.0

If EasySave proves satisfactory, management will request the development of a version 2.0 using a WPF graphical interface.

## Areas for Improvement

- Implementation of input conditions (path, etc...)
- Modification of log file and real-time state file path from the application
- Adding languages to the application

## Installation

To install EasySave, please follow these instructions...

### Installation Prerequisites
- Have Visual Studio 2019 installed on the workstation
- Have git bash installed on the workstation

For beginners, follow this installation procedure:
[EasySave v1 installation.pdf](https://github.com/louanne622/EasySave/files/14223357/installation.de.EasySave.v1.pdf)

To install from the command prompt:\
```git clone https://github.com/louanne622/EasySave.git```  

## Usage

To use EasySave, follow these steps:

1. Open a command line.
2. Then copy and paste this line to place you inside the EasySave project folder\

```cd EasySaveConsoleMode```\
Once you're in the project file, run the command to launch the application:\
```dotnet run```



