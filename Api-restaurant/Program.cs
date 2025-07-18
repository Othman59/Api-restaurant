using Api_restaurant.Classes;
using Api_restaurant.Data;
using Api_restaurant.Dto;
using Api_restaurant.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestaurantDb>(opt => opt.UseSqlite("Data Source=restaurant.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Restaurant API",
        Version = "v1",
        Description = "Une API pour g�rer les commandes d'un restaurant",
        Contact = new OpenApiContact
        {
            Name = "Lo�c, Abdellah , Othman, Nicolas",
            Email = "nephtyse19@hotmail.fr",
            Url = new Uri("https://github.com/abdellah59/Api-restaurant")
        }
    });
    // Activer les annotations swagger
    c.EnableAnnotations();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant API V1");
        c.RoutePrefix = "";
    });
}


// GET tous les clients
app.MapGet("/clients", async (RestaurantDb db) =>
{
    var clients = await db.Clients.ToListAsync();
    return Results.Ok(clients);
});

// GET client par ID
app.MapGet("/clients/{id}", async (int id, RestaurantDb db) =>
{
    var client = await db.Clients.FindAsync(id);
    return client is not null ? Results.Ok(client) : Results.NotFound();
});

// POST ajouter un client
app.MapPost("/clients", async (Client client, RestaurantDb db) =>
{
    db.Clients.Add(client);
    await db.SaveChangesAsync();
    return Results.Created($"/clients/{client.Id}", client);
});

// PUT modifier un client
app.MapPut("/clients/{id}", async (int id, Client updatedClient, RestaurantDb db) =>
{
    var client = await db.Clients.FindAsync(id);
    if (client is null) return Results.NotFound();

    client.Nom = updatedClient.Nom;
    client.Prenom = updatedClient.Prenom;
    client.NumeroDeRue = updatedClient.NumeroDeRue;
    client.NomDeRue = updatedClient.NomDeRue;
    client.CodePostal = updatedClient.CodePostal;
    client.Ville = updatedClient.Ville;
    client.Telephone = updatedClient.Telephone;

    await db.SaveChangesAsync();
    return Results.Ok(client);
});

// DELETE supprimer un client
app.MapDelete("/clients/{id}", async (int id, RestaurantDb db) =>
{
    var client = await db.Clients.FindAsync(id);
    if (client is null) return Results.NotFound();

    db.Clients.Remove(client);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// ENDPOINTS POUR LA GESTION DES COMMANDES

// Endpoint pour cr�er une commande

app.MapPost("/commandes", async (CommandeItemDTO dto, RestaurantDb db) =>
{
    if (dto.ArticleIds == null || !dto.ArticleIds.Any())
    {
        return Results.BadRequest("Une commande doit contenir au moins un article.");
    }

    var client = await db.Clients.FindAsync(dto.ClientsId);
    if (client == null)
        return Results.NotFound("Client introuvable");

    var articles = await db.Articles
        .Where(a => dto.ArticleIds.Contains(a.Id))
        .ToListAsync();

    if (articles.Count != dto.ArticleIds.Count)
        return Results.BadRequest("Un ou plusieurs articles sont invalides");

    var montantTotal = articles.Sum(a => a.Prix);

    var commande = new Commande
    {
        ClientId = dto.ClientsId,
        CommandeArticles = dto.ArticleIds.Select(id => new CommandeArticle
        {
            ArticleId = id
        }).ToList(),
        MontantTotal = montantTotal,
        StatutLivraison = "En cours"
    };

    db.Commandes.Add(commande);
    await db.SaveChangesAsync();

    return Results.Created($"/commandes/{commande.Id}", commande);
});

// Endpoint pour Consulter les commandes d'un client

app.MapGet("/commandes-clients/{clientId}", async (int clientId, RestaurantDb db) =>
{
    var commandes = await db.Commandes
        .Where(c => c.ClientId == clientId)
        .Include(c => c.CommandeArticles).ThenInclude(ca => ca.ArticleId)
        .ToListAsync();

    return Results.Ok(commandes);
});


// Endpoint pour Consulter les commandes par date

app.MapGet("/commandes/date/{date}", async (DateTime date, RestaurantDb db) =>
{
    var commandes = await db.Commandes
        .Where(c => c.Date.Date == date.Date)
        .Include(c => c.CommandeArticles).ThenInclude(ca => ca.ArticleId)
        .ToListAsync();

    return Results.Ok(commandes);
});

// Endpoint pot Modifier le statut de livraison

app.MapPut("/commandes/{id}/statut", async (int id, string nouveauStatut, RestaurantDb db) =>
{
    var commande = await db.Commandes.FindAsync(id);
    if (commande == null)
        return Results.NotFound();

    commande.StatutLivraison = nouveauStatut;
    await db.SaveChangesAsync();

    return Results.Ok(commande);
});

// Commandes en attente de livraison

app.MapGet("/commandes/en-attente", async (RestaurantDb db) =>
{
    var commandes = await db.Commandes
        .Where(c => c.StatutLivraison == "En cours")
        .ToListAsync();

    return Results.Ok(commandes);
});


// GET tous les articles
app.MapGet("/articles", async (RestaurantDb db) =>
{
    var articles = await db.Articles.ToListAsync();
    return Results.Ok(articles);
});

// GET articles par ID
app.MapGet("/articles/{id}", async (int id, RestaurantDb db) =>
{
    var articles = await db.Articles.FindAsync(id);
    return articles is not null ? Results.Ok(articles) : Results.NotFound();
});

// POST ajouter un article
app.MapPost("/articles", async (Article article, RestaurantDb db) =>
{
    db.Articles.Add(article);
    await db.SaveChangesAsync();
    return Results.Created($"/clients/{article.Id}", article);
});

// PUT modifier un article
app.MapPut("/articles/{id}", async (int id, Article updatedArticle, RestaurantDb db) =>
{
    var article = await db.Articles.FindAsync(id);
    if (article is null) return Results.NotFound();

    article.Nom = updatedArticle.Nom;
    article.Prix = updatedArticle.Prix;
    article.Categorie = updatedArticle.Categorie;

    await db.SaveChangesAsync();
    return Results.Ok(article);
});

// DELETE supprimer un article
app.MapDelete("/articles/{id}", async (int id, RestaurantDb db) =>
{
    var article = await db.Articles.FindAsync(id);
    if (article is null) return Results.NotFound();

    db.Articles.Remove(article);
    await db.SaveChangesAsync();
    return Results.NoContent();
});


DbInitializer.Database(app.Services);


app.Run();

