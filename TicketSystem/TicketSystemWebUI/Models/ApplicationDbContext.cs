using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystemLibrary;
using TicketSystemWebUI.Models;

namespace TicketSystemWebUI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) {

        }

        public DbSet<TaskModelView> TaskModel { get; set; }
    }
}
