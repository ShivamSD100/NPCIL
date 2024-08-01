using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPCIL.DbModels;
using NPCIL.Models;
using System.Collections.Generic;

namespace NPCIL.Helper
{
    public class TabActiveOptionsResolver : IValueResolver<TblAddMenu, MenuModel, List<SelectListItem>>
    {
        public List<SelectListItem> Resolve(TblAddMenu source, MenuModel destination, List<SelectListItem> destMember, ResolutionContext context)
        {
            return new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Yes" },
            new SelectListItem { Value = "0", Text = "No" }
        };
        }
    }
}
