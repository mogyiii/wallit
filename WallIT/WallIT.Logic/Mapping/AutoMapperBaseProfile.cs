using AutoMapper;
using System;
using WallIT.DataAccess.Entities;
using WallIT.Logic.Identity;
using WallIT.Shared.DTOs;

namespace WallIT.Logic.Mapping
{
    public class AutoMapperBaseProfile : Profile
    {
        public AutoMapperBaseProfile()
        {
            CreateMap<CreditCardEntity, CreditCardDTO>().ReverseMap();

            CreateMap<UserEntity, UserDTO>();
            CreateMap<UserDTO, UserEntity>()
                .ForMember(dest => dest.UserName, m => m.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedUserName, m => m.MapFrom(src => src.Email.ToUpper()));

            CreateMap<UserDTO, AppIdentityUser>()
                .ForMember(dest => dest.LockoutEnd, m => m.MapFrom(src => src.LockoutEnd))
                .ForMember(dest => dest.UserName, m => m.MapFrom(src => src.Email))
                .ForMember(dest => dest.NormalizedUserName, m => m.MapFrom(src => src.Email.ToUpper()));
            CreateMap<AppIdentityUser, UserDTO>()
                .ForMember(dest => dest.LockoutEnd, m => m.MapFrom(src => src.LockoutEnd.HasValue ? (DateTime?)DateTime.Parse(src.LockoutEnd.ToString()) : null));

            CreateMap<UserEntity, AppIdentityUser>()
                .ForMember(dest => dest.LockoutEnd, m => m.MapFrom(src => src.LockoutEnd));
            CreateMap<AppIdentityUser, UserEntity>()
                .ForMember(dest => dest.LockoutEnd, m => m.MapFrom(src => src.LockoutEnd.HasValue ? (DateTime?)DateTime.Parse(src.LockoutEnd.ToString()) : null));

            CreateMap<UserClaimEntity, UserClaimDTO>()
                .ForMember(dest => dest.UserId, m => m.MapFrom(src => src.User != null ? src.User.Id : (int?)null));
            CreateMap<UserClaimDTO, UserClaimEntity>()
                .ForMember(dest => dest.User, m => m.MapFrom(src => src.UserId.HasValue ?  new UserEntity { Id = src.UserId.Value } : null));

            CreateMap<UserClaimDTO, AppIdentityUserClaim>().ReverseMap();

            //Record
            //CreateMap<RecordEntity, RecordDTO>().ReverseMap();
            CreateMap<RecordEntity, RecordDTO>()
                .ForMember(dest => dest.RecordCategoryId, m => m.MapFrom(src => src.RecordCategory != null ? src.RecordCategory.Id : (int?)null));
            CreateMap<RecordDTO, RecordEntity>()
                .ForMember(dest => dest.RecordCategory, m => m.MapFrom(src => src.RecordCategoryId.HasValue ? new RecordCategoryEntity { Id = src.RecordCategoryId.Value } : null));

            //Subject
            CreateMap<SubjectEntity, SubjectDTO>()
                .ForMember(dest => dest.UserId, m => m.MapFrom(src => src.User != null ? src.User.Id : (int?)null))
                .ForMember(dest => dest.CreditCardId, m => m.MapFrom(src => src.CreditCard != null ? src.CreditCard.Id : (int?)null));
            CreateMap<SubjectDTO, SubjectEntity>()
                .ForMember(dest => dest.User, m => m.MapFrom(src => src.UserId.HasValue ? new UserEntity { Id = src.UserId.Value } : null))
                .ForMember(dest => dest.CreditCard, m => m.MapFrom(src => src.CreditCardId.HasValue ? new CreditCardEntity { Id = src.CreditCardId.Value } : null));

            //RecordCategory
            CreateMap<RecordCategoryEntity, RecordCategoryDTO>()
                .ForMember(dest => dest.ParentCategoryId, m => m.MapFrom(src => src.ParentCategory != null ? src.ParentCategory.Id : (int?)null))
            .ForMember(dest => dest.SubjectId, m => m.MapFrom(src => src.Subject != null ? src.Subject.Id : (int?)null));
            CreateMap<RecordCategoryDTO, RecordCategoryEntity>()
                .ForMember(dest => dest.ParentCategory, m => m.MapFrom(src => src.ParentCategoryId.HasValue ? new UserEntity { Id = src.ParentCategoryId.Value } : null))
                .ForMember(dest => dest.Subject, m => m.MapFrom(src => src.SubjectId.HasValue ? new SubjectEntity { Id = src.SubjectId.Value } : null));

            //RecordPlanned
            CreateMap<RecordPlannedEntity, RecordPlannedDTO>()
                .ForMember(dest => dest.RecordCategoryId, m => m.MapFrom(src => src.RecordCategory != null ? src.RecordCategory.Id : (int?)null));
            CreateMap<RecordPlannedDTO, RecordPlannedEntity>()
                .ForMember(dest => dest.RecordCategory, m => m.MapFrom(src => src.RecordCategoryId.HasValue ? new RecordCategoryEntity { Id = src.RecordCategoryId.Value } : null));
            //CreditCard 
            CreateMap<CreditCardEntity, CreditCardDTO>()
                .ForMember(dest => dest.UserId, m => m.MapFrom(src => src.User != null ? src.User.Id : (int?)null));
            CreateMap<CreditCardDTO, CreditCardEntity>()
                .ForMember(dest => dest.User, m => m.MapFrom(src => src.UserId.HasValue ? new UserEntity { Id = src.UserId.Value } : null));
        }
    }
}
