using AutoMapper;
using NPCIL.DbModels;
using NPCIL.Models;
using System;

namespace NPCIL.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TblAddMenu, MenuModel>()
                .ForMember(dest => dest.MenuId, opt => opt.MapFrom(src => src.MenuSno))
                .ForMember(dest => dest.MenuName_eng, opt => opt.MapFrom(src => src.MenuNameEng))
                .ForMember(dest => dest.MenuName_hind, opt => opt.MapFrom(src => src.MenuNameHind))
                .ForMember(dest => dest.MenuPosition, opt => opt.MapFrom(src => src.MenuPosition.GetValueOrDefault()))
                .ForMember(dest => dest.MenuType, opt => opt.MapFrom(src => src.MenuType.GetValueOrDefault()))
                .ForMember(dest => dest.MenuImg, opt => opt.Ignore()) // Custom handling required for IFormFile
                .ForMember(dest => dest.MenuDesc_eng, opt => opt.MapFrom(src => src.MenuDescEng))
                .ForMember(dest => dest.MenuDesc_hind, opt => opt.MapFrom(src => src.MenuDescHind))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.FileImage))
                .ForMember(dest => dest.file_StartDate, opt => opt.MapFrom(src => Parsing.ParseDateTime(src.FileStartdate.HasValue ? src.FileStartdate.Value.ToString("yyyy-MM-dd") : null)))
                .ForMember(dest => dest.file_EndDate, opt => opt.MapFrom(src => Parsing.ParseDateTime(src.FileEnddate.HasValue ? src.FileEnddate.Value.ToString("yyyy-MM-dd") : null)))
                .ForMember(dest => dest.link_urlname, opt => opt.MapFrom(src => src.LinkUrlname))
                .ForMember(dest => dest.linkType, opt => opt.MapFrom(src => src.LinkType.GetValueOrDefault()))
                .ForMember(dest => dest.event_year, opt => opt.MapFrom(src => src.Eventyear))
                .ForMember(dest => dest.tabActive, opt => opt.MapFrom(src => src.TabActive.GetValueOrDefault().ToString()))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => Parsing.ParseInt(src.ParentId.HasValue ? src.ParentId.Value.ToString() : null)))
                .ForMember(dest => dest.mOrder, opt => opt.MapFrom(src => src.MenuOrder.GetValueOrDefault()))
                .ForMember(dest => dest.Controller, opt => opt.MapFrom(src => src.Controller))
                .ForMember(dest => dest.Sequence, opt => opt.MapFrom(src => src.MenuOrder));

            CreateMap<MenuModel, TblAddMenu>()
                .ForMember(dest => dest.MenuSno, opt => opt.MapFrom(src => src.MenuId))
                .ForMember(dest => dest.MenuNameEng, opt => opt.MapFrom(src => src.MenuName_eng))
                .ForMember(dest => dest.MenuNameHind, opt => opt.MapFrom(src => src.MenuName_hind))
                .ForMember(dest => dest.MenuPosition, opt => opt.MapFrom(src => src.MenuPosition))
                .ForMember(dest => dest.MenuType, opt => opt.MapFrom(src => src.MenuType))
                .ForMember(dest => dest.MenuImg, opt => opt.Ignore()) // Custom handling required for IFormFile
                .ForMember(dest => dest.MenuDescEng, opt => opt.MapFrom(src => src.MenuDesc_eng))
                .ForMember(dest => dest.MenuDescHind, opt => opt.MapFrom(src => src.MenuDesc_hind))
                .ForMember(dest => dest.FileImage, opt => opt.MapFrom(src => src.ImagePath))
                .ForMember(dest => dest.FileStartdate, opt => opt.MapFrom(src => Parsing.ParseDateTime(src.file_StartDate)))
                .ForMember(dest => dest.FileEnddate, opt => opt.MapFrom(src => Parsing.ParseDateTime(src.file_EndDate)))
                .ForMember(dest => dest.LinkUrlname, opt => opt.MapFrom(src => src.link_urlname))
                .ForMember(dest => dest.LinkType, opt => opt.MapFrom(src => src.linkType))
                .ForMember(dest => dest.Eventyear, opt => opt.MapFrom(src => src.event_year))
                .ForMember(dest => dest.TabActive, opt => opt.MapFrom(src => Parsing.ParseInt(src.tabActive)))
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => Parsing.ParseInt(src.ParentId)))
                .ForMember(dest => dest.MenuOrder, opt => opt.MapFrom(src => src.mOrder))
                .ForMember(dest => dest.Controller, opt => opt.MapFrom(src => src.Controller))
                .ForMember(dest => dest.MenuOrder, opt => opt.MapFrom(src => src.Sequence)); 
        }
    }
}
