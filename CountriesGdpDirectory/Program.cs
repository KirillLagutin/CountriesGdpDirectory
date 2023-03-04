using CountriesGdpDirectory.Data;
using CountriesGdpDirectory.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddDbContext<AppDbContext>(); 

var app = builder.Build();

app.MapGet("/", () => "���������� ��� ������ �����");

///// CRUD ��� ///// ==============================================================

// ������ ���� ���
app.MapGet("/get_all_gdps", async (HttpContext context, AppDbContext db) =>
{
    var gdps = await db.GDPs.ToListAsync();

    return gdps;
});
//---------------------------------------------------------------------------------

// ������� ���
app.MapPost("/create_gdp", async (HttpContext context, AppDbContext db) =>
{
    var gdp = await context.Request.ReadFromJsonAsync<GDP>();

    if (gdp != null)
    {
        db.GDPs.Add(gdp);
        await db.SaveChangesAsync();
    }

    return gdp;
});
//---------------------------------------------------------------------------------

// �������� ��� �� Id 
app.MapGet("/get_gdp", async (HttpContext context, AppDbContext db, Guid id) =>
{
    var gdp = await db.GDPs.FindAsync(id);

    return gdp;
});
//---------------------------------------------------------------------------------

// �������� ���
app.MapPost("/update_gdp", async (HttpContext context, AppDbContext db) =>
{
    var gdp = await context.Request.ReadFromJsonAsync<GDP>();

    if (gdp != null)
    {
        db.GDPs.Update(gdp);
        await db.SaveChangesAsync();
    }

    return gdp;
});
//---------------------------------------------------------------------------------

// ������� ���
app.MapPost("/delete_gdp", async (HttpContext context, AppDbContext db, Guid id) =>
{
    var gdp = await db.GDPs.FindAsync(id);

    if (gdp != null)
    {
        db.GDPs.Remove(gdp);
        await db.SaveChangesAsync();
    }

    return Results.Ok("Element removed!");
});
//---------------------------------------------------------------------------------


///// CRUD ����� ///// ==========================================================

// ������ ���� �����
app.MapGet("/get_all_countries",
    async (HttpContext context, AppDbContext db) =>
    {
        var countries = await db.Countries.ToListAsync();

        return countries;
});
//---------------------------------------------------------------------------------

// ������� ������
app.MapPost("/create_country", async (HttpContext context, AppDbContext db) =>
{
    //var country = await context.Request.ReadFromJsonAsync<Country>();

    var country = await context.Request.ReadFromJsonAsync<Country>();

    if (country != null)
    {
        db.Countries.Add(country);
        await db.SaveChangesAsync();
    }

    return country;
});
//-----------------------------------------------------------------------------------

// �������� ������ �� Id 
app.MapGet("/get_country", async (HttpContext context, AppDbContext db, Guid id) =>
    {
        var country = await db.Countries.FindAsync(id);

        return country;
});
//-----------------------------------------------------------------------------------

// �������� ������
app.MapPost("/update_country", async (HttpContext context, AppDbContext db) =>
{
    var country = await context.Request.ReadFromJsonAsync<Country>();

    if (country != null)
    {
        db.Countries.Update(country);
        await db.SaveChangesAsync();
    }

    return Results.Ok(country);
});
//-------------------------------------------------------------------------------------

// ������� ������
app.MapPost("/delete_country", async (HttpContext context, AppDbContext db, Guid id) =>
    {
        var country = await db.Countries.FindAsync(id);

        if (country != null)
        {
            db.Countries.Remove(country);
            await db.SaveChangesAsync();
        }

        return Results.Ok("Element removed!");
    });
//--------------------------------------------------------------------------------------


app.Run();
