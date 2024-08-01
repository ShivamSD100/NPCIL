using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPCIL.DbModels;
using NPCIL.Models;
using System.Collections.Generic;
using System.Linq;

namespace NPCIL.Helper
{
    public class PageBindingOptionsResolver : IValueResolver<TblAddMenu, MenuModel, List<SelectListItem>>
    {
        private readonly NPCIL_DBContext _dbContext;

        public PageBindingOptionsResolver(NPCIL_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SelectListItem> Resolve(TblAddMenu source, MenuModel destination, List<SelectListItem> destMember, ResolutionContext context)
        {
            var options = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "" }
        };

            foreach (var db in _dbContext.PageDataBinds.ToList())
            {
                options.Add(new SelectListItem { Value = db.id.ToString(), Text = db.DataBindTag });
            }

            return options;
        }
    }
}
