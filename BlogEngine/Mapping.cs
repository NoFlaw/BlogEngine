using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BlogEngine.Models.ViewModels;
using BlogEntities.Models;

namespace BlogEngine
{
    public class Mapping : Profile
    {
        public override string ProfileName
        {
            get
            {
                return base.ProfileName;
            }
        }

        protected override void Configure()
        {
                //  CreateMap<CalculatedProduct, FavoriteViewModel>()
                //.ForMember(d => d.Description, o => o.MapFrom(s => s.ShortDescription))
                //.ForMember(d => d.DiscountPrice, o => o.MapFrom(s => s.ProductPrice))
                //.ForMember(d => d.IsDiscounted, o => o.ResolveUsing<IsDiscountedValueResolver>())
                //.ForMember(d => d.MerchantId, o => o.MapFrom(s => s.BusinessEntity.BusinessEntityID))
                //.ForMember(d => d.MerchantName, o => o.MapFrom(s => s.BusinessEntity.BusinessName))
                //.ForMember(d => d.Name, o => o.MapFrom(s => s.Name))
                //.ForMember(d => d.Price, o => o.MapFrom(s => s.RetailPrice))
                //.ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId))
                //.ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType))
                //.ForMember(d => d.CanAddToCart, o => o.Ignore())
                //.ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ImageFile))
                //.ForMember(d => d.Market, o => o.Ignore())
                //.ForMember(d => d.SelectedSkuId, o => o.MapFrom(s => s.SelectedSku.SkuId))
            
        }
    }
}