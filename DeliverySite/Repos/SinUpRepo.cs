using DeliverySite.Data;
using DeliverySite.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySite.Repos;

public class SignUpRepo
{
    private readonly ApplicationDbContext _db;

    public SignUpRepo(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task CreateRegisterAppAsync(RegisterApp registerApp)
    {
        _db.RegisterApps.Add(registerApp);
         await _db.SaveChangesAsync();
    }
}