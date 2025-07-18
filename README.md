RestauSimplon – API de gestion de commandes pour restaurant

🍽️ RestauSimplon – API de gestion des commandes pour restaurant

Présentation

RestauSimplon est une API REST développée avec ASP.NET Core et Entity Framework Core, destinée à digitaliser la gestion des commandes d’un restaurant. Elle permet de gérer les articles du menu, les clients, les commandes et, en bonus, les livraisons.
Ce projet a été réalisé dans un contexte professionnel au sein d'une start-up tech.


Fonctionnalités principales

1. Gestion des Articles du Menu
Ajouter, modifier, consulter, supprimer un article

Champs requis :
Nom
Prix
Catégorie (Entrée, Plat, Dessert, Boisson)

2. Gestion des Clients
Ajouter, modifier, consulter, supprimer un client

Champs requis :
Nom
Prénom
Adresse
Téléphone

3. Gestion des Commandes
Créer une commande pour un client avec un ou plusieurs articles

Calcul automatique du montant total

Consulter les commandes :
Par client
Par date
Validation : Une commande doit contenir au moins un article

Données requises vérifiées (ex. pas de champs vides)

4. Relations entre entités
Un client peut passer plusieurs commandes

Une commande peut contenir plusieurs articles

Un article peut appartenir à plusieurs commandes

⭐ Bonus

🛵 Gestion des Livraisons

Statut de livraison : En cours, Livrée, etc.
Modifier le statut d’une commande
Consulter les commandes en attente de livraison

💻 Interface Front-End (optionnelle)

Développée en HTML/CSS ou React

Permet :
Consultation des articles, clients, commandes
Création de commandes
Interface double : employés (gestion menu) / clients (commandes)

🛠️ Technologies utilisées

Backend : ASP.NET Core
ORM : Entity Framework Core
Base de données : SQL Server / SQLite (selon environnement)
Documentation : Swagger
Contrôle de version : Git / GitHub


📊 Présentation finale

Le projet est accompagné d’un diaporama PDF expliquant :
L’architecture
Les choix techniques

Les démonstrations via Swagger et/ou front-end


🤝 Collaboration & Git
Travail collaboratif avec Git : branches, pull requests, commits réguliers

Communication via Discord

📚 Ressources utiles
ASP.NET Core Minimal APIs

Entity Framework Core

Swagger/OpenAPI

👨‍💻 Auteur

Projet développé par [Abdellah, Loic, Othman, Nicolas] dans le cadre d’un projet backend pour RestauSimplon.
