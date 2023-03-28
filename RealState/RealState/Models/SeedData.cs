using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealState.Data;
using System;
using System.Linq;

namespace RealState.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RealStateContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RealStateContext>>()))
        {


            // Look for any Cne
            if (!context.Cne.Any())
            {
                context.Cne.AddRange(
                    new Cne
                    {
                        type = "Compraventa"
                    },
                    new Cne
                    {
                        type = "RegularizaciónDePatrimonio"
                    }
                );
            }
            context.SaveChanges();

            Cne? compraVenta = context.Cne.Find(1);
            Cne? regularizacion = context.Cne.Find(2);
            
            
            // Look for any Localization.
            if (!context.Localization.Any())
            {
                context.Localization.AddRange(
                    new Localization
                {
                    comuna = "Las Condes",
                    manzana = 123,
                    predio = 456
                },
                    new Localization
                {
                    comuna = "Peñalolén",
                    manzana = 789,
                    predio = 123
                });
            }
            context.SaveChanges();
            Localization? lasCondes = context.Localization.Find(1);
            Localization? penalolen = context.Localization.Find(2);


            // Look for any Inscription.
            if (!context.Inscription.Any())
            {
                context.Inscription.AddRange(
                    new Inscription
                    {
                        attention_number = 1,
                        Cne = compraVenta,
                        Localization = lasCondes,
                        fojas = 1,
                        date = DateTime.Parse("2023-02-13"),
                        number = 1
                    },
                    new Inscription
                    {
                        attention_number = 2,
                        Cne = regularizacion,
                        Localization = lasCondes,
                        fojas = 2,
                        date = DateTime.Parse("2023-02-15"),
                        number = 2
                    },
                    new Inscription
                    {
                        attention_number = 3,
                        Cne = compraVenta,
                        Localization = penalolen,
                        fojas = 3,
                        date = DateTime.Parse("2023-02-20"),
                        number = 3
                    },
                    new Inscription
                    {
                        attention_number = 3,
                        Cne = regularizacion,
                        Localization = penalolen,
                        fojas = 3,
                        date = DateTime.Parse("2023-02-21"),
                        number = 3
                    }
                );
            }

            context.SaveChanges();
            
            Inscription? inscripcion1 = context.Inscription.Find(1);
            Inscription? inscripcion2 = context.Inscription.Find(2);
            Inscription? inscripcion3 = context.Inscription.Find(3);
            Inscription? inscripcion4 = context.Inscription.Find(4);
            
            // Look for any Enajenante.
            if (!context.Enajenante.Any())
            {
                context.Enajenante.AddRange(
                    new Enajenante
                    {
                        Rut = "12345678-9",
                        Percentage_right = 50,
                        Check_percentage_not_credited = 0,
                        Inscription = inscripcion1
                    },
                    new Enajenante
                    {
                        Rut = "98765432-1",
                        Percentage_right = 20,
                        Check_percentage_not_credited = 30,
                        Inscription = inscripcion1
                    },
                    new Enajenante
                    {
                        Rut = "56262262-2",
                        Percentage_right = 51,
                        Check_percentage_not_credited = 67,
                        Inscription = inscripcion2
                    },
                    new Enajenante
                    {
                        Rut = "32162562-9",
                        Percentage_right = 60,
                        Check_percentage_not_credited = 15,
                        Inscription = inscripcion3
                    },
                    new Enajenante
                    {
                        Rut = "98765432-1",
                        Percentage_right = 40,
                        Check_percentage_not_credited = 96,
                        Inscription = inscripcion3
                    },
                    new Enajenante
                    {
                        Rut = "56262262-2",
                        Percentage_right = 49,
                        Check_percentage_not_credited = 33,
                        Inscription = inscripcion4
                    }
                );
                }
            context.SaveChanges();
            
            
            // Look for any Adquiriente.
            if (!context.Adquiriente.Any())
            {
                context.Adquiriente.AddRange(
                    new Adquiriente
                    {
                        Rut = "12345678-9",
                        Percentage_right = 32,
                        Check_percentage_not_credited = 24,
                        Inscription = inscripcion1
                    },
                    new Adquiriente
                    {
                        Rut = "98765432-1",
                        Percentage_right = 16,
                        Check_percentage_not_credited = 73,
                        Inscription = inscripcion2
                    },
                    new Adquiriente
                    {
                        Rut = "56262262-2",
                        Percentage_right = 51,
                        Check_percentage_not_credited = 67,
                        Inscription = inscripcion2
                    },
                    new Adquiriente
                    {
                        Rut = "32162562-9",
                        Percentage_right = 10,
                        Check_percentage_not_credited = 74,
                        Inscription = inscripcion3
                    },
                    new Adquiriente
                    {
                        Rut = "98765432-1",
                        Percentage_right = 15,
                        Check_percentage_not_credited = 96,
                        Inscription = inscripcion4
                    },
                    new Adquiriente
                    {
                        Rut = "56262262-2",
                        Percentage_right = 25,
                        Check_percentage_not_credited = 83,
                        Inscription = inscripcion4
                    }
                );
            }
            context.SaveChanges();
        }
    }
}