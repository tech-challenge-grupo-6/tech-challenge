using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace DatabaseAdapters.Repositories
{
  public class ProdutoCategory : IProdutoRepository
  {
    private DatabaseContext _dbContext;

    public ProdutoCategory(DatabaseContext dbContext)
    {
      _dbContext = dbContext;
    }
  }
}