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

Si EasySave donne satisfaction, la direction nous demandera de développer une version 2.0 utilisant une interface graphique WPF basée sur l'architecture MVVM.

## Installation

Pour installer EasySave, veuillez suivre les instructions suivantes...\

#Prérequis d'intallation
- Avoir Visual Studio 2019 installé sur le poste
- Avoir git bash installé sur le poste

Pour les personnes débutantes, suivez cette procédure d'installation :
[Procédure d'installation du projet](https://link-url-here.org)

Sinon :\
Pour installer depuis l'invite de commande :\
```git clone https://github.com/louanne622/EasySave.git```  

## Utilisation

Pour utiliser EasySave, suivez ces étapes...

Ouvrez une ligne de commmande, placez vous dans le fichier "EasySaveConsole"\
```cd EasySave/EasySaveConsole/EasySaveConsole```\
Lorsque vous vous situez bien dans le fichier du projet, lancez la commande pour lancer l'application:\
```dotnet run```

----------------------------------------------------------------------------------------------

# EasySave - .NET Core 3.0 Console Backup Application

## Description
EasySave is a backup application designed to provide a simple and effective solution for backing up data from a specified source directory to a destination directory. It is developed in C# on the .NET Core 3.0 platform, thus offering increased portability and compatibility.

### Version 1.0 Features

- Creation of up to 5 backup jobs.
- Definition of a backup job with a name, a source directory, a target directory, and a type (full, differential).
- Usable by both English and French-speaking users.
- Sequential execution of all jobs or a specific job via command line.
- Backup from local, external disks, or network drives.
- Backup of all items within the source directory (files and subdirectories).
- Daily Log file and real-time State file in JSON format.
- Adaptation of file locations to work on client servers.

### Prosoft Presentation

EasySave is developed as part of our integration at ProSoft. We must comply with the following constraints:

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
  - Polish UI for distribution to clients.

### Next Step: Version 2.0

If EasySave proves satisfactory, management will ask us to develop a version 2.0 using a WPF graphical interface based on the MVVM architecture.

## Installation

To install EasySave, please follow the instructions below...

Copy the github repository into visual studio 2019\
To install from command prompt:\
```git clone https://github.com/louanne622/EasySave.git```

## Usage

To use EasySave, follow these steps...

Open a command line, navigate to the "EasySaveConsole" file\
```cd EasySave/EasySaveConsole/EasySaveConsole```\
Once you're in the project file, run the command:\
```dotnet run```



