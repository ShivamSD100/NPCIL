using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPCIL.DbModels;
using NPCIL.Models;
using System.Collections.Generic;
using System.Linq;

namespace NPCIL.Helper
{
    public class MenuOptionsResolver : IValueResolver<TblAddMenu, MenuModel, List<SelectListItem>>
    {
        private readonly NPCIL_DBContext _dbContext;

        public MenuOptionsResolver(NPCIL_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<SelectListItem> Resolve(TblAddMenu source, MenuModel destination, List<SelectListItem> destMember, ResolutionContext context)
        {
            var options = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Select" }
        };

            foreach (var m in _dbContext.TblAddMenu.ToList())
            {
                options.Add(new SelectListItem { Value = m.MenuSno.ToString(), Text = m.MenuNameEng.ToString() });
            }

            return options;
        }
    }
}
