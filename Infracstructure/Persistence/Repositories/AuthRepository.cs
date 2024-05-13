using Domain.Entities;
using Domain.Interfaces;
using Infracstructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories;
public class AuthRepository : RepositoryBase<User> 
{



    public  AuthRepository(datnContext dbContext) : base(dbContext){

    }
    
}
